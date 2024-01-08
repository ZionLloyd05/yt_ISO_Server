using System.Net;
using System.Net.Sockets;
using System.Text;
using BIM_ISO8583.NET;
using ISO_Server.Models;
using ISO_Server.Services;

namespace ISO_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Initiating Server Session---------");

            InitiateServer();
        }

        public async static void InitiateServer()
        {
            // Get Host IP Address that is used to establish a connection
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1
            // If a host has multiple addresses, you will get a list of addresses
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            try
            {

                // Create a Socket that will use Tcp protocol
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // A Socket must be associated with an endpoint using the Bind method
                listener.Bind(localEndPoint);

                // Specify how many requests a Socket can listen before it gives Server busy response.
                // We will listen 10 requests at a time
                listener.Listen(10);

                while(true)
                {
                    Console.WriteLine("Waiting for a new connection request...");
                    Socket connection = listener.Accept();

                    while (connection.Connected)
                    {
                        // Incoming data from the client.
                        string incomingRequestData = null;
                        byte[] bytes = null;

                        while (true)
                        {
                            bytes = new byte[1024];
                            int bytesRec = connection.Receive(bytes);
                            incomingRequestData += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                            if (incomingRequestData.IndexOf("<EOF>") > -1)
                            {
                                break;
                            }
                        }

                        Console.WriteLine("Text received : {0}", incomingRequestData);

                        string response = await RequestHandler(incomingRequestData);

                        byte[] msg = Encoding.ASCII.GetBytes(response);
                        connection.Send(msg);
                        connection.Close();
                    }
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }

        private async static Task<string> RequestHandler(string incomingRequestData)
        {
            var isoRequest = Unpack(incomingRequestData);
            var customerAccountNumber = isoRequest[2];
            
            var amount = Convert.ToDecimal(isoRequest[8]);

            var responseCode = string.Empty;
            var isoResponse = string.Empty;

            ISO8583 iso8583 = new ISO8583();
            string[] dataElement = new string[130];

            var messageType = incomingRequestData.Substring(0, 4);

            switch (messageType)
            {
                case Actions.FINANCIALTRANSACTION:
                    Console.WriteLine("Executing a financial request - Balance Enquiry");
                    
                    var customerBalance = await CoreBankingService.GetCustomerBalanceAsync(customerAccountNumber);

                    var accountbalance = customerBalance.accountBalance;

                    if (accountbalance >= amount)
                        responseCode = Responses.SUCCESSFUL;
                    else
                        responseCode = Responses.FAILED;

                    dataElement[8] = accountbalance.ToString();
                    dataElement[39] = responseCode;

                    isoResponse = iso8583.Build(dataElement, messageType);
                                        
                    break;
                case Actions.HOLD_RELEASEFUNDS:
                    Console.WriteLine("Not supported yet");

                    dataElement[39] = Responses.FAILED;

                    isoResponse = iso8583.Build(dataElement, messageType);
                    
                    break;
                case Actions.REVERSED_FUNDS:
                    Console.WriteLine("Not supported yet");

                    dataElement[39] = Responses.FAILED;

                    isoResponse = iso8583.Build(dataElement, messageType);

                    break;
                default:
                    Console.WriteLine("Not supported yet");

                    dataElement[39] = Responses.FAILED;

                    isoResponse = iso8583.Build(dataElement, messageType);

                    break;
                    break;
            }

            return isoResponse;
        }

        private static string[] Unpack(string resData)
        {
            ISO8583 iso8583 = new ISO8583();

            string[] DE;

            DE = iso8583.Parse(resData);

            return DE;
        }
    }
}
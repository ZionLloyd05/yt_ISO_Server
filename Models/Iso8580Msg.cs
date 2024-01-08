using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Net.Sockets;
using System.Text;

namespace ISO_Server.Models
{
    public class Iso8583Msg
    {
        private const int MAX_LEN_ACCT_INQ = 478;

        private string m_mti { get; set; }

        // public List<Iso8583Field> Iso8583flds;
        public Dictionary<string, Iso8583Field> Iso8583flds;

        public string AccountIden1
        {
            get
            {
                return Iso8583flds["102"].Value;
            }
            set
            {
                // this.Iso8583flds["102"].Value = Convert.ToString(value);
                Iso8583flds["102"].Value = Convert.ToString(value);
            }
        }

        public string AccountIden2
        {
            get
            {
                return Iso8583flds["103"].Value;
            }
            set
            {
                Iso8583flds["103"].Value = Convert.ToString(value);
            }
        }

        public string AcquirerInstId
        {
            get
            {
                return Iso8583flds["32"].Value;
            }
            set
            {
                Iso8583flds["32"].Value = Convert.ToString(value);
            }
        }

        public string AccountBalance
        {
            get
            {
                return Iso8583flds["54"].Value;
            }
            set
            {
                Iso8583flds["54"].Value = Convert.ToString(value);
            }
        }

        public string AdditionalData
        {
            get
            {
                return Iso8583flds["48"].Value;
            }
            set
            {
                Iso8583flds["48"].Value = Convert.ToString(value);
            }
        }
        public string AdditionalRspData
        {
            get
            {
                return Iso8583flds["44"].Value;
            }
            set
            {
                Iso8583flds["44"].Value = Convert.ToString(value);
            }
        }

        //public AmountFees AmtFees
        //{
        //    get
        //    {
        //        return new AmountFees(Iso8583flds["46"].Value);
        //    }
        //    set
        //    {
        //        Iso8583flds["46"].Value = value.ToString();
        //    }
        //}

        public string ApprovalCode
        {
            get
            {
                return Iso8583flds["38"].Value;
            }
            set
            {
                Iso8583flds["38"].Value = value;
            }
        }

        public string CardAcceptorId
        {
            get
            {
                return Iso8583flds["42"].Value;
            }
            set
            {
                Iso8583flds["42"].Value = Convert.ToString(value);
            }
        }

        public string CardAcceptorNameLoc
        {
            get
            {
                return Iso8583flds["43"].Value;
            }
            set
            {
                Iso8583flds["43"].Value = Convert.ToString(value);
            }
        }

        public string CardAcceptorTerminalId
        {
            get
            {
                return Iso8583flds["41"].Value;
            }
            set
            {
                Iso8583flds["41"].Value = Convert.ToString(value);
            }
        }

        public int CardSeqNo
        {
            get
            {
                return Convert.ToInt32(Iso8583flds["23"].Value);
            }
            set
            {
                Iso8583flds["23"].Value = Convert.ToString(value);
            }
        }

        public DateTime DateCapture
        {
            get
            {
                DateTime dateTime = DateTime.ParseExact(Iso8583flds["17"].Value, "yyyyMMdd", null);
                return dateTime;
            }
            set
            {
                Iso8583flds["17"].Value = value.ToString("yyyyMMdd");
            }
        }

        public DateTime DateExp
        {
            get
            {
                //  DateTime dateTime = DateTime.ParseExact(this.Iso8583flds["15"].Value, "yyyyMMdd", null);
                DateTime dateTime = DateTime.ParseExact(Iso8583flds["15"].Value, "MMyy", CultureInfo.InvariantCulture);

                return dateTime;
            }
            set
            {
                Iso8583flds["15"].Value = value.ToString("MMyy");
            }
        }

        public DateTime DateStl
        {
            get
            {
                //DateTime dateTime = DateTime.ParseExact(this.Iso8583flds["14"].Value, "yyyyMMdd", null);

                DateTime dateTime = DateTime.ParseExact(Iso8583flds["14"].Value, "yyMM", CultureInfo.InvariantCulture);
                return dateTime;
            }
            set
            {
                Iso8583flds["14"].Value = value.ToString("yyMM");
            }
        }

        public string ExtendedPAN
        {
            get
            {
                return Iso8583flds["34"].Value;
            }
            set
            {
                Iso8583flds["34"].Value = Convert.ToString(value);
            }
        }

        public string PrimaryAccountNo
        {
            get
            {
                return Iso8583flds["2"].Value;
            }
            set
            {
                Iso8583flds["2"].Value = Convert.ToString(value);
            }
        }

        public string Field_125
        {
            get
            {
                return Iso8583flds["125"].Value;
            }
            set
            {
                Iso8583flds["125"].Value = value;
            }
        }

        public string Field_126
        {
            get
            {
                return Iso8583flds["126"].Value;
            }
            set
            {
                Iso8583flds["126"].Value = value;
            }
        }

        //public string Field_127
        //{
        //    get
        //    {
        //        return this.Iso8583flds["127"].Value;
        //    }
        //    set
        //    {
        //        this.Iso8583flds["127"].Value = value;
        //    }
        //}

        public string Field_93
        {
            get
            {
                return Iso8583flds["93"].Value;
            }
            set
            {
                Iso8583flds["93"].Value = value;
            }
        }

        public string Field_94
        {
            get
            {
                return Iso8583flds["94"].Value;
            }
            set
            {
                Iso8583flds["94"].Value = value;
            }
        }

        public string FowarderInstCode
        {
            get
            {
                return Iso8583flds["33"].Value;
            }
            set
            {
                Iso8583flds["33"].Value = Convert.ToString(value);
            }
        }

        public FUNCTION_CODE FunctionCode
        {
            get
            {
                FUNCTION_CODE fUNCTIONCODE = (FUNCTION_CODE)Enum.Parse(typeof(FUNCTION_CODE), Iso8583flds["24"].Value);
                return fUNCTIONCODE;
            }
            set
            {
                Iso8583flds["24"].Value = Enum.Format(typeof(FUNCTION_CODE), value, "d");
            }
        }

        public DateTime LocalDateTime
        {
            get
            {
                //DateTime dateTime = DateTime.ParseExact(this.Iso8583flds["13"].Value, "hhmmss", null);
                //DateTime dateTime = DateTime.ParseExact(this.Iso8583flds["13"].Value, "HHmmss", null);
                DateTime dateTime = DateTime.ParseExact(Iso8583flds["13"].Value, "MMyy", CultureInfo.InvariantCulture);

                return dateTime;
            }
            set
            {
                //this.Iso8583flds["13"].Value = value.ToString("hhmmss");
                Iso8583flds["13"].Value = value.ToString("MMyy");
            }
        }

        public string LocalTxnDateTime
        {
            get
            {
                //DateTime dateTime = DateTime.ParseExact(this.Iso8583flds["12"].Value, "yyyyMMddhhmmss", null);
                // DateTime dateTime = DateTime.ParseExact(this.Iso8583flds["12"].Value, "yyyyMMddHHmmss", null);
                return Iso8583flds["12"].Value;
            }
            set
            {
                //this.Iso8583flds["12"].Value = value.ToString("yyyyMMddhhmmss");
                Iso8583flds["12"].Value = value;
            }
        }

        public int MerchantType
        {
            get
            {
                return Convert.ToInt32(Iso8583flds["18"].Value);
            }
            set
            {
                Iso8583flds["18"].Value = Convert.ToString(value);
            }
        }

        public string MessageType
        {
            get
            {
                return m_mti;
            }
            set
            {
                m_mti = value;
            }
        }

        public string NetworkMgmtCode
        {
            get
            {
                return Iso8583flds["70"].Value;
            }
            set
            {
                Iso8583flds["70"].Value = Convert.ToString(value);
            }
        }
        /// <summary>
        /// altered during working for reversal
        /// </summary>
        //public decimal OriginalAmounts
        //{
        //    get
        //    {
        //        return Convert.ToDecimal(this.Iso8583flds["30"].Value);
        //    }
        //    set
        //    {
        //        //this.Iso8583flds["30"].Value = value.ToString();
        //        Iso8583Field item = this.Iso8583flds["30"];
        //        double num = double.Parse(value.ToString());
        //        item.Value = num.ToString();
        //    }
        //}

        public string OriginalAmounts
        {
            get
            {
                return Iso8583flds["30"].Value;
            }
            set
            {
                Iso8583flds["30"].Value = value.ToString();

            }
        }

        public string OriginalDataElements
        {
            get
            {
                return Iso8583flds["56"].Value;
            }
            set
            {
                Iso8583flds["56"].Value = value.ToString();
            }
        }

        //public AmountFees OriginalFees
        //{
        //    get
        //    {
        //        return new AmountFees(Iso8583flds["66"].Value);
        //    }
        //    set
        //    {
        //        Iso8583flds["66"].Value = value.ToString();
        //    }
        //}

        public int PosCondCode
        {
            get
            {
                return Convert.ToInt32(Iso8583flds["25"].Value);
            }
            set
            {
                Iso8583flds["25"].Value = Convert.ToString(value);
            }
        }

        public string PosDataCode
        {
            get
            {
                return Iso8583flds["123"].Value;
            }
            set
            {
                Iso8583flds["123"].Value = value;
            }
        }

        public int PosEntryMode
        {
            get
            {
                return Convert.ToInt32(Iso8583flds["22"].Value);
            }
            set
            {
                Iso8583flds["22"].Value = Convert.ToString(value);
            }
        }

        //public string PosEntryMode23
        //{
        //    get
        //    {
        //        return this.Iso8583flds["23"].Value;
        //    }
        //    set
        //    {
        //        this.Iso8583flds["23"].Value = Convert.ToString(value);
        //    }
        //}

        public string PosEntryMode40
        {
            get
            {
                return Iso8583flds["40"].Value;
            }
            set
            {
                Iso8583flds["40"].Value = Convert.ToString(value);
            }
        }


        public string PosPinCapCode
        {
            get
            {
                //return Convert.ToInt32(this.Iso8583flds["26"].Value);
                return Iso8583flds["26"].Value;

            }
            set
            {
                Iso8583flds["26"].Value = Convert.ToString(value);
            }
        }


        public PROCESS_CODE ProcessCode
        {
            get
            {
                PROCESS_CODE pROCESSCODE = (PROCESS_CODE)Enum.Parse(typeof(PROCESS_CODE), Iso8583flds["3"].Value);
                return pROCESSCODE;
            }
            set
            {
                Iso8583flds["3"].Value = Enum.Format(typeof(PROCESS_CODE), value, "d");
            }
        }

        public string ReplacementAmount
        {
            get
            {
                return Iso8583flds["95"].Value;
            }
            set
            {
                Iso8583flds["95"].Value = Convert.ToString(value);
            }
        }

        public string ResponseCode
        {
            get
            {
                return Iso8583flds["39"].Value;
            }
            set
            {
                Iso8583flds["39"].Value = Convert.ToString(value);
            }
        }

        public long RetrievalRefNo
        {
            get
            {
                return Convert.ToInt64(Iso8583flds["37"].Value);
            }
            set
            {
                Iso8583flds["37"].Value = Convert.ToString(value);
            }
        }

        public decimal SettlementAmount
        {
            get
            {
                return Convert.ToDecimal(Iso8583flds["5"].Value);
            }
            set
            {
                Iso8583flds["5"].Value = value.ToString();
            }
        }

        public decimal SettlementFee
        {
            get
            {
                return Convert.ToDecimal(Iso8583flds["29"].Value);
            }
            set
            {
                Iso8583flds["29"].Value = Convert.ToString(value);
            }
        }

        public decimal SettlementProcFee
        {
            get
            {
                return Convert.ToDecimal(Iso8583flds["31"].Value);
            }
            set
            {
                Iso8583flds["31"].Value = Convert.ToString(value);
            }
        }

        public string StlCurrencyCode
        {
            get
            {
                return Iso8583flds["50"].Value;
            }
            set
            {
                Iso8583flds["50"].Value = Convert.ToString(value);
            }
        }

        public string TerminalType
        {
            get
            {
                return Iso8583flds["124"].Value;
            }
            set
            {
                Iso8583flds["124"].Value = value;
            }
        }

        public long TraceAuditNo
        {
            get
            {
                return Convert.ToInt64(Iso8583flds["11"].Value);
            }
            set
            {
                Iso8583flds["11"].Value = value.ToString("000000");
            }
        }

        public string Track2Data
        {
            get
            {
                return Iso8583flds["35"].Value;
            }
            set
            {
                Iso8583flds["35"].Value = Convert.ToString(value);
            }
        }

        public string ChannelId
        {
            get
            {
                return Iso8583flds["126"].Value;
            }
            set
            {
                Iso8583flds["126"].Value = Convert.ToString(value);
            }
        }

        //public decimal TransactionAmount
        //{
        //    get
        //    {
        //        return Convert.ToDecimal(this.Iso8583flds["4"].Value);
        //    }
        //    set
        //    {
        //        Iso8583Field item = this.Iso8583flds["4"];
        //        double num = double.Parse(value.ToString());
        //        item.Value = num.ToString();
        //    }
        //}
        public string TransactionAmount
        {
            get
            {
                return Iso8583flds["4"].Value;
            }
            set
            {
                Iso8583flds["4"].Value = Convert.ToString(value);

            }
        }
        //public decimal TransactionFee
        //{
        //    get
        //    {
        //        return Convert.ToDecimal(this.Iso8583flds["28"].Value);
        //    }
        //    set
        //    {
        //        this.Iso8583flds["28"].Value = Convert.ToString(value);
        //    }
        //}
        public string TransactionFee
        {
            get
            {
                return Iso8583flds["28"].Value;
            }
            set
            {
                Iso8583flds["28"].Value = Convert.ToString(value);
            }
        }
        /// <summary>
        ///  check this property so it is not connect24 dll limiting factor
        /// </summary>
        public string TransmissionDateTime
        {
            get
            {
                return Iso8583flds["7"].Value;
            }
            set
            {
                // this.Iso8583flds["7"].Value = value.ToString("MMhhmmss");


                Iso8583flds["7"].Value = value;
            }
        }

        public string TransportDataCode
        {
            get
            {
                return Iso8583flds["59"].Value;
            }
            set
            {
                Iso8583flds["59"].Value = Convert.ToString(value);
            }
        }

        public string TxnCurrencyCode
        {
            get
            {
                return Iso8583flds["49"].Value;
            }
            set
            {
                Iso8583flds["49"].Value = Convert.ToString(value);
            }
        }


        public string Field_95
        {
            get
            {
                return Iso8583flds["95"].Value;
            }
            set
            {
                Iso8583flds["95"].Value = Convert.ToString(value);
            }
        }

        public string Field_90
        {
            get
            {
                return Iso8583flds["90"].Value;
            }
            set
            {
                Iso8583flds["90"].Value = Convert.ToString(value);
            }
        }


        public string Field_127002
        {
            get
            {
                return Iso8583flds["127.002"].Value;
            }
            set
            {
                Iso8583flds["127.002"].Value = Convert.ToString(value);
            }
        }

        public string Field_127003
        {
            get
            {
                return Iso8583flds["127.003"].Value;
            }
            set
            {
                Iso8583flds["127.003"].Value = Convert.ToString(value);
            }
        }

        public string Field_127006
        {
            get
            {
                return Iso8583flds["127.006"].Value;
            }
            set
            {
                Iso8583flds["127.006"].Value = Convert.ToString(value);
            }
        }

        public string Field_127011
        {
            get
            {
                return Iso8583flds["127.011"].Value;
            }
            set
            {
                Iso8583flds["127.011"].Value = Convert.ToString(value);
            }
        }
        public string Field_127020
        {
            get
            {
                return Iso8583flds["127.020"].Value;
            }
            set
            {
                Iso8583flds["127.020"].Value = Convert.ToString(value);
            }
        }
        public string Field_127026
        {
            get
            {
                return Iso8583flds["127.026"].Value;
            }
            set
            {
                Iso8583flds["127.026"].Value = Convert.ToString(value);
            }
        }

        public string Field_127012
        {
            get
            {
                return Iso8583flds["127.012"].Value;
            }
            set
            {
                Iso8583flds["127.012"].Value = Convert.ToString(value);
            }
        }
        public string Field_127022
        {
            get
            {
                return Iso8583flds["127.022"].Value;
            }
            set
            {
                Iso8583flds["127.022"].Value = Convert.ToString(value);
            }
        }
        public string Field_127042
        {
            get
            {
                return Iso8583flds["127.042"].Value;
            }
            set
            {
                Iso8583flds["127.042"].Value = Convert.ToString(value);
            }
        }
        //127.025.IccData

        public string Field_127_025_IccData
        {
            get
            {
                return Iso8583flds["127.025.IccData"].Value;
            }
            set
            {
                Iso8583flds["127.025.IccData"].Value = Convert.ToString(value);
            }
        }

        public void InitiateIsoFields()
        {



            Iso8583flds = new Dictionary<string, Iso8583Field>(128);

            for (int i = 0; i < 128; i++)
            {
                Iso8583flds.Add(i.ToString(), null);
                if (i == 127)
                {
                    for (int j = 0; i < 128; i++)
                    {
                        string jString = j.ToString();
                        if (jString.Length == 1)
                        {
                            jString = "00" + jString;
                        }
                        if (jString.Length == 2)
                        {
                            jString = "0" + jString;
                        }

                        Iso8583flds.Add("127." + jString, null);
                    }

                }
            }

            Iso8583flds.Add("127.025.IccData", null);


            Iso8583flds["2"] = new Iso8583Field("Primary AccountNumber No", "LLVAR", 19);
            Iso8583flds["3"] = new Iso8583Field("Process Code", "N", 6);
            Iso8583flds["4"] = new Iso8583Field("Txn Amount", "N", 12);
            Iso8583flds["5"] = new Iso8583Field("Stl Amount", "N", 16);
            Iso8583flds["7"] = new Iso8583Field("Transmission Date Time", "N", 10);
            Iso8583flds["11"] = new Iso8583Field("Trace Number", "N", 6);
            Iso8583flds["12"] = new Iso8583Field("Transmission Date Time", "N", 6);
            Iso8583flds["13"] = new Iso8583Field("Txn Local Date", "N", 4);
            Iso8583flds["14"] = new Iso8583Field("Stl Date", "N", 4);
            Iso8583flds["15"] = new Iso8583Field("Expiry Date", "N", 4);
            Iso8583flds["17"] = new Iso8583Field("Date Capture", "DTS", 8);
            Iso8583flds["18"] = new Iso8583Field("Merchant Type", "N", 4);
            Iso8583flds["22"] = new Iso8583Field("Pos Entry Mode", "N", 3);
            Iso8583flds["23"] = new Iso8583Field("Field 23", "N", 3);
            Iso8583flds["24"] = new Iso8583Field("Function Code", "N", 3);
            Iso8583flds["25"] = new Iso8583Field("Settlement Amount", "N", 2);
            Iso8583flds["26"] = new Iso8583Field("Pos Pin Cap Code", "N", 2);
            Iso8583flds["28"] = new Iso8583Field("Txn Fee", "X+N", 9);
            Iso8583flds["29"] = new Iso8583Field("Stl Fee", "AMT", 8);
            Iso8583flds["30"] = new Iso8583Field("Original Amounts", "X+N", 9);
            Iso8583flds["31"] = new Iso8583Field("Stl Processing Fee", "AMT", 8);
            Iso8583flds["32"] = new Iso8583Field("Acquiring Inst ID", "LLVAR", 11);
            Iso8583flds["33"] = new Iso8583Field("Fowarder Inst ID", "LLVAR", 11);
            Iso8583flds["34"] = new Iso8583Field("Extended PAN", "LLVAR", 28);
            Iso8583flds["35"] = new Iso8583Field("Track 2", "LLVAR", 37);
            Iso8583flds["37"] = new Iso8583Field("Retrieval Ref No", "ANP", 12);
            Iso8583flds["38"] = new Iso8583Field("Approval Code", "AN", 6);
            Iso8583flds["39"] = new Iso8583Field("Response Code", "AN", 2);
            Iso8583flds["40"] = new Iso8583Field("Field 40", "AN", 3);
            Iso8583flds["41"] = new Iso8583Field("Terminal ID", "ANS", 8);
            Iso8583flds["42"] = new Iso8583Field("Card Acceptor ID", "ANS", 15);
            Iso8583flds["43"] = new Iso8583Field("Card Acceptor Name", "ANS", 40);
            Iso8583flds["46"] = new Iso8583Field("Amount Fees", "FEE", 300);
            Iso8583flds["48"] = new Iso8583Field("Additional Data", "LLLVAR", 999);
            Iso8583flds["49"] = new Iso8583Field("Txn Ccy Code", "A/N", 3);
            Iso8583flds["50"] = new Iso8583Field("Stl Ccy Code", "LLLVAR", 3);
            Iso8583flds["54"] = new Iso8583Field("AccountNumber Balance Amounts", "LLLVAR", 120);
            Iso8583flds["56"] = new Iso8583Field("Original Data Elements", "LLLVAR", 4);
            Iso8583flds["59"] = new Iso8583Field("Transport data", "LLLVAR", 500);
            Iso8583flds["66"] = new Iso8583Field("Original Amount Fees", "FEE", 300);
            Iso8583flds["70"] = new Iso8583Field("Network Code", "N", 3);
            Iso8583flds["90"] = new Iso8583Field("Field 90", "N", 42);
            Iso8583flds["93"] = new Iso8583Field("Field 93", "LLVAR", 11);
            Iso8583flds["94"] = new Iso8583Field("Field 94", "LLVAR", 11);
            Iso8583flds["95"] = new Iso8583Field("Field 95", "AN*", 42);
            Iso8583flds["102"] = new Iso8583Field("AccountNumber Iden 1", "LLVAR", 28); //account ID
            Iso8583flds["103"] = new Iso8583Field("AccountNumber Iden 2", "LLVAR", 28);
            Iso8583flds["123"] = new Iso8583Field("POS Data Code", "LLLVAR", 15);
            Iso8583flds["124"] = new Iso8583Field("Terminal Type", "AN", 3);
            Iso8583flds["125"] = new Iso8583Field("Field 125", "LLLVAR", 999);
            Iso8583flds["126"] = new Iso8583Field("Field 126", "LLLVAR", 999);
            // this.Iso8583flds["127"] = new Iso8583Field("Field 127", "ANS", 999);
            Iso8583flds["127.002"] = new Iso8583Field("Field 127.002", "ANS", 10);
            Iso8583flds["127.003"] = new Iso8583Field("Field 127.003", "ANS*", 48);
            Iso8583flds["127.020"] = new Iso8583Field("Field 127.020", "N", 8);
            Iso8583flds["127.006"] = new Iso8583Field("Field 127.006", "AN", 2);
            Iso8583flds["127.011"] = new Iso8583Field("Field 127.011", "ANS", 10);
            Iso8583flds["127.026"] = new Iso8583Field("Field 127.026", "ANS", 9);
            Iso8583flds["127.012"] = new Iso8583Field("Field 127.012", "ANS", 3);
            Iso8583flds["127.022"] = new Iso8583Field("Field 127.022", "ANS", 14);
            Iso8583flds["127.042"] = new Iso8583Field("Field 127.026", "N", 20);
            Iso8583flds["127.025.IccData"] = new Iso8583Field("127.025.IccData", "ANS", 1202);



        }

        public Iso8583Msg()
        {
            InitiateIsoFields();
        }


        private byte BinToByte(string bin_val)
        {
            byte num = 0;
            int length = bin_val.Length - 1;
            int num1 = 0;
            while (length >= 0)
            {
                num = (byte)(num + Convert.ToByte(Convert.ToInt32(bin_val.Substring(num1, 1)) * Convert.ToInt32(Math.Pow(2, length))));
                length--;
                num1++;
            }
            return num;
        }

        public static decimal ConvertToISOAmount(decimal dec_amt)
        {
            return dec_amt * new decimal(100);
        }

        private void Decode(byte[] iso_msg)
        {
            int num;
            int i;
            int num1 = 128;
            try
            {
                if (iso_msg[0] * 256 + iso_msg[1] < 22)
                {
                    throw new Exception("Msg Decode Failed");
                }

                byte[] numArray = new byte[16];
                Array.Copy(iso_msg, 6, numArray, 0, 16);



                BitArray availableFields = GetAvailableFields(numArray);
                int num2 = 0;
                string str = Encoding.ASCII.GetString(iso_msg, 22, iso_msg.Length - 22);
                int length = 0;
                num = 0;
                for (i = 0; i < num1 - 1; i++)
                {
                    if (availableFields.Get(i))
                    {
                        num = i + 1;
                        string numString = num.ToString();
                        if (Iso8583flds[numString] != null)
                        {
                            Console.WriteLine($"While decoding  got field {num} and format is :{Iso8583flds[numString].Format}");
                            string format = Iso8583flds[numString].Format;
                            if (format != null)
                            {
                                switch (format)
                                {
                                    case "LLVAR":
                                        {
                                            length = int.Parse(str.Substring(num2, 2));
                                            num2 = num2 + 2;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "LLLVAR":
                                        {
                                            length = int.Parse(str.Substring(num2, 3));
                                            num2 = num2 + 3;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "FEE":
                                        {
                                            length = int.Parse(str.Substring(num2, 3));
                                            num2 = num2 + 3;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "AN":
                                        {
                                            length = Iso8583flds[numString].Length;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "ANS":
                                        {
                                            length = Iso8583flds[numString].Length;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "N":
                                        {
                                            // length = int.Parse(str.Substring(num2, 2));
                                            length = Iso8583flds[numString].Length;
                                            //if (this.Iso8583flds[numString].Value.Length <= 0)
                                            //{
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            //}

                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "DTL":
                                        {
                                            length = Iso8583flds[numString].Length;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "DTS":
                                        {
                                            length = Iso8583flds[numString].Length;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        } //additional cases
                                    case "X+N":
                                        {
                                            length = Iso8583flds[numString].Length;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "Z":
                                        {
                                            length = Iso8583flds[numString].Length;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "ANP":
                                        {
                                            length = Iso8583flds[numString].Length;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "A/N":
                                        {
                                            length = Iso8583flds[numString].Length;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "AN*":
                                        {
                                            length = Iso8583flds[numString].Length;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    case "ANS*":
                                        {
                                            length = Iso8583flds[numString].Length;
                                            Iso8583flds[numString].Value = str.Substring(num2, length);
                                            num2 = num2 + length;
                                            break;
                                        }
                                    default:
                                        {
                                            //goto Label0;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                //goto Label0;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return;
        }

        private BitArray GetAvailableFields(byte[] bitmap)
        {
            string str = null;
            byte num = 128;
            for (int i = 0; i < bitmap.Length; i++)
            {
                str = string.Concat(str, Convert.ToString(bitmap[i], 2).PadLeft(8, '0'));
            }

            Console.WriteLine($"string of available field  {str}");
            BitArray bitArrays = new BitArray(num, false);
            for (int j = 0; j < num; j++)
            {
                bitArrays.Set(j, str.Substring(j, 1) == "1" ? true : false);
            }
            return bitArrays;
        }

        private byte[] Encode(Iso8583Msg MsgToEncode)
        {
            Iso8583Field item;
            int i;
            byte[] numArray;
            int length;
            string str = "";
            BitArray bitArrays = new BitArray(128, false);
            string value = "";
            try
            {
                bitArrays.Set(0, true);
                bitArrays.Set(1, true);
                for (i = 2; i < 128; i++)
                {
                    string iString = i.ToString();
                    item = MsgToEncode.Iso8583flds[iString];
                    if (item != null)
                    {
                        if (item.Value != null)
                        {
                            bitArrays.Set(i, true);
                            if (item.Value.Length > item.Length)
                            {
                                item.Value = item.Value.Substring(1, item.Length);
                            }
                            string format = item.Format;
                            if (format != null)
                            {
                                switch (format)
                                {
                                    case "LLVAR":
                                        {
                                            length = item.Value.Length;
                                            string str1 = length.ToString();
                                            length = item.Length;
                                            value = string.Concat(str1.PadLeft(length.ToString().Length, '0'), item.Value);
                                            break;
                                        }
                                    case "LLLVAR":
                                        {
                                            length = item.Value.Length;
                                            value = string.Concat(length.ToString("000"), item.Value);
                                            break;
                                        }
                                    case "FEE":
                                        {
                                            length = item.Value.Length;
                                            value = string.Concat(length.ToString("000"), item.Value);
                                            break;
                                        }
                                    case "AN":
                                        {
                                            value = item.Value.PadLeft(item.Length, '0');
                                            break;
                                        }
                                    case "ANS":
                                        {
                                            value = item.Value.PadRight(item.Length, '0');
                                            break;
                                        }
                                    case "N":
                                        {
                                            value = item.Value.PadLeft(item.Length, '0').Substring(0, item.Length);
                                            break;
                                        }
                                    case "DTL":
                                        {
                                            value = item.Value;
                                            break;
                                        }
                                    case "DTS":
                                        {
                                            value = item.Value;
                                            break;
                                        }
                                    //additional cases
                                    case "X+N":
                                        {
                                            value = item.Value.PadRight(item.Length, '0');
                                            break;
                                        }
                                    case "Z":
                                        {
                                            value = item.Value.PadLeft(item.Length, '0').Substring(0, item.Length);
                                            break;
                                        }
                                    case "ANP":
                                        {
                                            value = item.Value.PadLeft(item.Length, '0').Substring(0, item.Length);
                                            break;
                                        }
                                    case "A/N":
                                        {
                                            value = item.Value.PadLeft(item.Length, '0').Substring(0, item.Length);
                                            break;
                                        }
                                    case "AN*":
                                        {
                                            value = item.Value.PadLeft(item.Length, '0').Substring(0, item.Length);
                                            break;
                                        }
                                    case "ANS*":
                                        {
                                            value = item.Value.PadLeft(item.Length, '0').Substring(0, item.Length);
                                            break;
                                        }
                                    default:
                                        {
                                            //goto Label0;

                                        }
                                        break;
                                }
                            }
                            else
                            {
                                //goto Label0;
                            }
                        Label1:
                            str = string.Concat(str, value);
                        }
                    }
                }
                Console.WriteLine($" respmse Msage string : {str}");
                ushort num = (ushort)(str.Length + 22);
                byte[] numArray1 = new byte[num];
                Console.WriteLine("MsgToEncode.MessageType " + MsgToEncode.MessageType);
                byte[] bytes = Encoding.ASCII.GetBytes(MsgToEncode.MessageType);
                Console.WriteLine("Encoding.ASCII.GetBytes(MsgToEncode.MessageType)");
                foreach (var b in bytes)
                {
                    Console.WriteLine("=" + b + "=");
                }

                byte[] numArray2 = GenerateBitmap(bitArrays);
                byte[] bytes1 = Encoding.ASCII.GetBytes(str);
                int num1 = num - 2;
                if (num1 > 256)
                {
                    numArray1[0] = (byte)Math.Floor((double)(num1 / 256));
                    num1 = num1 % 256;
                }
                numArray1[1] = (byte)num1;
                numArray1[2] = 49;
                // Array.Copy(bytes, 0, numArray1, 3, (int)bytes.Length);
                Array.Copy(bytes, 0, numArray1, 2, bytes.Length);
                Array.Copy(numArray2, 0, numArray1, 6, numArray2.Length);
                Array.Copy(bytes1, 0, numArray1, 22, bytes1.Length);
                numArray = numArray1;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception happened at encode {exception.Message} ;;;; Inerexception :{exception.InnerException}");
                throw exception;
            }
            return numArray;

        }

        private byte[] GenerateBitmap(BitArray avb_flds_bits)
        {
            int num = 16;
            int num1 = 8;
            string str = null;
            string str1 = null;
            byte[] numArray = new byte[num];
            if (avb_flds_bits.Length % num == 0)
            {
                for (int i = 0; i < avb_flds_bits.Length; i++)
                {
                    str = string.Concat(str, avb_flds_bits.Get(i) ? "1" : "0");
                }
                str = string.Concat(str.Substring(1, str.Length - 1), "0");
                int num2 = 0;
                for (int j = 0; j < str.Length; j = j + num1)
                {
                    str1 = str.Substring(j, num1);
                    numArray[num2] = BinToByte(str1);
                    num2++;
                }
            }
            return numArray;
        }

        public static string GetResponseMsg(string msg_code)
        {
            string str;
            if (msg_code == "000")
            {
                str = "Approved";
            }
            else if (msg_code == "111")
            {
                str = "Invalid Scheme type";
            }
            else if (msg_code == "114")
            {
                str = "Invalid account number";
            }
            else if (msg_code == "115")
            {
                str = "Func not supported";
            }
            else if (msg_code == "116")
            {
                str = "Insufficient funds";
            }
            else if (msg_code == "119")
            {
                str = "Txn not permitted";
            }
            else if (msg_code == "121")
            {
                str = "wdr limit exceeded";
            }
            else if (msg_code == "163")
            {
                str = "Inv Chq Status";
            }
            else if (msg_code == "180")
            {
                str = "Tfr Limit Exceeded";
            }
            else if (msg_code == "181")
            {
                str = "Chqs in different books";
            }
            else if (msg_code == "182")
            {
                str = "Not all chqs could be stopped";
            }
            else if (msg_code == "183")
            {
                str = "chqs not issued to this account";
            }
            else if (msg_code == "184")
            {
                str = "AccountNumber is closed";
            }
            else if (msg_code == "185")
            {
                str = "Inv Txn Currency or Amount";
            }
            else if (msg_code == "186")
            {
                str = "Block does not exist";
            }
            else if (msg_code == "187")
            {
                str = "Cheque Stopped";
            }
            else if (msg_code == "188")
            {
                str = "Invalid Rate Currency Combination";
            }
            else if (msg_code == "189")
            {
                str = "Cheque Book Already Issued";
            }
            else if (msg_code == "190")
            {
                str = "DD Already Paid";
            }
            else if (msg_code == "800")
            {
                str = "Network message was accepted";
            }
            else if (msg_code == "902")
            {
                str = "Invalid Txn";
            }
            else if (msg_code == "904")
            {
                str = "Format Error";
            }
            else if (msg_code == "906")
            {
                str = "Cut-over in progress";
            }
            else if (msg_code == "907")
            {
                str = "Card issuer inoperative";
            }
            else if (msg_code == "909")
            {
                str = "Malfunction";
            }
            else if (msg_code == "911")
            {
                str = "Card issuer timed out";
            }
            else if (!(msg_code == "913"))
            {
                str = !(msg_code == "419") ? "Unknown Msg Code" : "FAILED";
            }
            else
            {
                str = "Duplicate transmission";
            }
            return str;
        }


        private void HexDumpMsg(byte[] iso_msg)
        {
            string str;
            try
            {
                int num = 16;
                int length = iso_msg.Length;
                Trace.WriteLine(string.Concat("HexDumpMsg Size= ", length.ToString()));
                int num1 = 0;
                int num2 = 0;
                while (num1 < iso_msg.Length)
                {
                    num2 = num1 + 1;
                    Trace.Write(string.Concat(iso_msg[num1].ToString("X").PadLeft(2, '0'), " "));
                    if (num2 % num == 0)
                    {
                        str = Encoding.ASCII.GetString(iso_msg, num2 - num, num);
                        Trace.Write(str.Replace('\0', '.'));
                        Trace.WriteLine("");
                    }
                    else if (num2 == iso_msg.Length)
                    {
                        int num3 = num2 % num;
                        str = Encoding.ASCII.GetString(iso_msg, num2 - num3, num3);
                        str = str.Replace('\0', '.');
                        Trace.Write(new string(' ', 3 * (num - num3)));
                        Trace.Write(str);
                        Trace.WriteLine("");
                        Trace.Flush();
                    }
                    num1++;
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;

                throw exception1;//newly added
            }
        }



        public void Send(Socket sckt, Iso8583Msg iso8583Msg)
        {

            int num;


            string reqDump = "";
            string respDump = "";

            try
            {
                byte[] numArray = Encode(iso8583Msg);

                Console.WriteLine("Completed encoding");
                byte[] numArray1 = new byte[2];
                int num1 = 0;


                sckt.Send(numArray, 0, numArray.Length, SocketFlags.None);

            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception happened at send {exception.Message} ;;;; Inerexception :{exception.InnerException}");

                sckt.Close();
                throw exception;
            }

        }

        public string TextDumpMsgResponse(byte[] iso_msg, out Iso8583Msg iso8583Msg, out string messageType)
        {
            string res = "";
            iso8583Msg = new Iso8583Msg();
            messageType = string.Empty;
            try
            {
                int length = iso_msg.Length;

                Console.WriteLine($"iso_msg.Length : {length}");


                // Trace.WriteLine(string.Concat("TextDumpMsg Size= ", length.ToString()));

                byte[] numArrayTop = new byte[16];
                Array.Copy(iso_msg, 0, numArrayTop, 0, 15);
                string utfString = Encoding.UTF8.GetString(numArrayTop, 0, numArrayTop.Length);
                Console.WriteLine($"utfString for message code :===> {utfString}");
                messageType = utfString.Substring(2, 4);
                Console.WriteLine($"utfString for message code 0-4 :===> {messageType}");


                iso8583Msg.Decode(iso_msg);

                Console.WriteLine($"number of isomsg decoded {iso8583Msg.Iso8583flds.Count}");

                for (int i = 0; i < iso8583Msg.Iso8583flds.Count; i++)
                {
                    string iString = i.ToString();

                    if (i == 127)
                    {
                        for (int j = 0; i < 128; i++)
                        {
                            string jString = j.ToString();
                            if (jString.Length == 1)
                            {
                                jString = "00" + jString;
                            }
                            if (jString.Length == 2)
                            {
                                jString = "0" + jString;
                            }

                            iString = "127." + jString;

                            if (iso8583Msg.Iso8583flds[iString] != null)
                            {
                                Console.WriteLine($" Looping through decoded field {iString}  and value  {iso8583Msg.Iso8583flds[iString].Value}");
                                if (iso8583Msg.Iso8583flds[iString].Value != null)
                                {
                                    // Trace.WriteLine(string.Concat(i.ToString("000"), " ", iso8583Msg.Iso8583flds["i"].Value));

                                    res = $"{res}: {string.Concat(i.ToString("000"), " ", iso8583Msg.Iso8583flds[iString].Value)}";


                                }
                            }

                        }

                    }

                    if (iso8583Msg.Iso8583flds[iString] != null)
                    {
                        Console.WriteLine($" Looping through decoded field {iString}  and value  {iso8583Msg.Iso8583flds[iString].Value}");
                        if (iso8583Msg.Iso8583flds[iString].Value != null)
                        {
                            // Trace.WriteLine(string.Concat(i.ToString("000"), " ", iso8583Msg.Iso8583flds["i"].Value));

                            res = $"{res}: {string.Concat(i.ToString("000"), " ", iso8583Msg.Iso8583flds[iString].Value)}";


                        }
                    }
                }
                //  Trace.Flush();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;

            }


            return res;
        }

        private string TextDumpMsgResponse(byte[] iso_msg)
        {
            string res = "";
            try
            {
                int length = iso_msg.Length;
                Trace.WriteLine(string.Concat("TextDumpMsg Size= ", length.ToString()));
                Iso8583Msg iso8583Msg = new Iso8583Msg();
                iso8583Msg.Decode(iso_msg);
                for (int i = 0; i < iso8583Msg.Iso8583flds.Count; i++)
                {
                    string iString = i.ToString();
                    if (iso8583Msg.Iso8583flds[iString] != null)
                    {
                        if (iso8583Msg.Iso8583flds[iString].Value != null)
                        {
                            // Trace.WriteLine(string.Concat(i.ToString("000"), " ", iso8583Msg.Iso8583flds["i"].Value));
                            res = $"{res}: {string.Concat(i.ToString("000"), " ", iso8583Msg.Iso8583flds[iString].Value)}";
                        }
                    }
                }
                Trace.Flush();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;

            }
            return res;
        }

        private void TextDumpMsg(byte[] iso_msg)
        {
            try
            {
                int length = iso_msg.Length;
                Trace.WriteLine(string.Concat("TextDumpMsg Size= ", length.ToString()));
                Iso8583Msg iso8583Msg = new Iso8583Msg();
                iso8583Msg.Decode(iso_msg);
                for (int i = 0; i < iso8583Msg.Iso8583flds.Count; i++)
                {
                    string iString = i.ToString();
                    if (iso8583Msg.Iso8583flds[iString] != null)
                    {
                        if (iso8583Msg.Iso8583flds[iString].Value != null)
                        {
                            Trace.WriteLine(string.Concat(i.ToString("000"), " ", iso8583Msg.Iso8583flds[iString].Value));
                        }
                    }
                }
                Trace.Flush();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                // EventLog.WriteEntry("ISO8583::TextDumpMsg()", string.Concat(exception.Message, exception.StackTrace), EventLogEntryType.Error);
                //Console.WriteLine(exception.Message);
            }


        }

    }
    public enum FUNCTION_CODE
    {

        NormalRequest = 200,
        NormalResponse = 210,
        NormalAdvice = 220,
        NormalRepeat = 221,
        ReversalRequest = 400,
        ReversalAdvice = 420,
        ReversalRepeat = 421,
        ReversalResponse = 430,
        NetworkEchoTest = 831
    }
    public enum PROCESS_CODE
    {
        NormalPurchaseCA = 1000,
        NormalPurchaseSA = 2000,
        CashWithdrawalCA = 11000,
        CashWithdrawalSA = 12000,
        BalanceInquiryCA = 311000,
        BalanceInquirySA = 312000,
        MiniStatementCA = 381000,
        MiniStatementSA = 382000,
        FundTransferCA = 401010,
        FundTransferSA = 402010,
        FundTransferCACA = 402020,
        GeneralAccountInq = 821000,
        FullStatementCA = 931000,
        FullStatementSA = 932000,
        NormalAccountInq = 970000,
        FundTransferCACAReversal = 501010
    }
}



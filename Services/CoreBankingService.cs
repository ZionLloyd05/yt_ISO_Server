using ISO_Server.Models;

namespace ISO_Server.Services;

public static class CoreBankingService
{
    public static async Task<CustomerBalance> GetCustomerBalanceAsync(string accountNumber)
    {
        var balancesArray = new decimal[] { 1000, 950, 700 };

        Random random = new Random();

        var randomIndex = random.Next(0, balancesArray.Length - 1);
        
        var customerBalance = balancesArray[randomIndex];

        return await Task.FromResult(new CustomerBalance(accountNumber, customerBalance));
    }
}

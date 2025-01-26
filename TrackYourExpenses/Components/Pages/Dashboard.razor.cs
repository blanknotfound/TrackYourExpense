


using DataModel.Model;
using Microsoft.AspNetCore.Components;
using TrackYourExpenses.Model;

namespace TrackYourExpenses.Components.Pages
{
    public partial class Dashboard
    {
        private string ErrorMsg { get; set; } = string.Empty;
        private int TotalTransactions;
        private int TotalTransactionValue;
        private int LowestInflow;
        private int HighestInflow;
        private int Lowestoutflow;
        public int Highestoutflow;
        private List<Transaction> DisplayT = new();
        private string ErrorMessage { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            DisplayT = TransactionServices.GetAllTransactions();
            TotalTransactions = TransactionServices.GetTotalTransaction();
            TotalTransactionValue = UserService.getBalanceamt();
            LowestInflow = TransactionServices.GetLowestInflow();
            HighestInflow = TransactionServices.GetHighestInflow();
            Lowestoutflow = TransactionServices.GetLowestoutflow();
            Highestoutflow = TransactionServices.GetHighestOutflow();
        }
        [CascadingParameter]
        private UserState _LiveState { get; set; }

        private int Balanceamt() 
        {
            int Balance = UserService.getBalanceamt();
            return Balance;
        }
    }
}

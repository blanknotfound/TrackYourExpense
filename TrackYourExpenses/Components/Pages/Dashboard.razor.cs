


using DataModel.Model;
using Microsoft.AspNetCore.Components;
using TrackYourExpenses.Model;

namespace TrackYourExpenses.Components.Pages
{
    public partial class Dashboard
    {
        private List<Transaction> DisplayT = new();
        private string ErrorMessage { get; set; } = string.Empty;
        protected override void OnInitialized()
        {
            DisplayT = TransactionServices.GetAllTransactions();
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

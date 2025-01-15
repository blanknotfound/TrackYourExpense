

using DataModel.Model;
using Microsoft.Maui.Controls;
using TrackYourExpenses.Model;

namespace TrackYourExpenses.Components.Pages
{
    public partial class Home
    {
        private List<Transaction> DisplayT = new();
        private List<CustomTags> Tags { get; set; } = new();
        private string ErrorMessage { get; set; } = string.Empty;
        protected override void OnInitialized()
        {
            DisplayT = TransactionServices.GetAllTransactions();
            Tags = TransactionServices.GetTags();
        }
        private Transaction transaction { get; set; } = new();
        private CustomTags tag{ get; set; } = new();
        private void AddIncome()
        {
            TransactionServices.AddInflow(transaction);
            //TransactionServices.AddInflow("sams2", 10, "credit", DateTime.Now.AddDays(-5), "test2", 240);
        }
        private void AddTag()
        {
            
            if (TransactionServices.AddTags(tag))
            {
                Nav.NavigateTo("/dashboard");
            }
            else
            {
                ErrorMessage = "Data not inserted";
            }
        }
    }
}

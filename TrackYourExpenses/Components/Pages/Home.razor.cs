

using DataModel.Model;
using TrackYourExpenses.Model;

namespace TrackYourExpenses.Components.Pages
{
    public partial class Home
    {
        private List<CustomTags> Tags { get; set; } = new();
        private string ErrorMessage { get; set; } = string.Empty;

        private string _search = string.Empty;
        
        private List<Transaction> Filtered = new();
        private Transaction transaction { get; set; } = new();
        private CustomTags tag{ get; set; } = new();

        protected override void OnInitialized()
        {
            Filtered = TransactionServices.GetAllTransactions();
            Tags = TransactionServices.GetTags();
        }
        private void AddIncome()
        {
            if (TransactionServices.AddInflow(transaction))
            {
                if (transaction.Type.ToLower() == "inflow"|| transaction.Type.ToLower() == "Debt")
                {
                    int balance = UserService.getBalanceamt();
                    int Currentbalance = balance + transaction.Amount;
                    UserService.updateBalanceAmt(Currentbalance);
                }
                else if(transaction.Type.ToLower() == "outflow")
                    {
                    int balance = UserService.getBalanceamt();
                    int Currentbalance = balance - transaction.Amount;
                    UserService.updateBalanceAmt(Currentbalance);
                }
                Nav.NavigateTo("/dashboard");
            }
            else
            {
                ErrorMessage = "Data not inserted";
            }
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

        #region searchtitle
        //private bool FilterFunc(Transaction transaction)
        //{
        //    if (string.IsNullOrWhiteSpace(_search))
        //        return true;
        //    if (transaction.Title.Contains(_search, StringComparison.OrdinalIgnoreCase))
        //        return true;
        //    return false;
        //}
        private async Task FilteredTransaction()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(Search))
                {
                    Filtered = TransactionServices.GetAllTransactions();
                    ErrorMessage = string.Empty;
                    return;
                }
                Filtered = await TransactionServices.SearchTransaction(Search);

                if (!Filtered.Any())
                {
                    ErrorMessage = "No Match Users Found";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        private string Search
        {
            get => _search;

            set
            {
                if (_search == value) return;
                _search = value;
                _ = OnSearchInput(_search);
            }
        }
        private async Task OnSearchInput(string search)
        {
            Search = search;
            FilteredTransaction();
            StateHasChanged();
        }
        #endregion
    }
}


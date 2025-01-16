
using DataAccess.Services;
using DataAccess.Services.Interface;
using DataModel.Model;
using TrackYourExpenses.Model;
using TrackYourExpenses.Model.Abstraction;
using TrackYourExpenses.Services.Interface;


namespace TrackYourExpenses.Services
{
    public class TransactionServices : TransactionServicesBase, ITransaction
    {
        //declaration
        private List<Transaction> _Transaction;
        private List<CustomTags> Ctags;
        private readonly IUser _userService;
        private DateTime StartDate { get; set; } = DateTime.Now.AddDays(-30);
        private DateTime EndDate { get; set; } = DateTime.Now.AddDays(30);


        //transaction services
        public TransactionServices()
        {
            _Transaction = GetAllDetails();
            //_userService = userservice;
        }

        #region tags

        public List<CustomTags> GetTags()
        {
            var tagDetails = Gettags();
            if (tagDetails != null)
            {
                return tagDetails;
            }
            else
            {
                return new List<CustomTags>();
            }
        }
        public bool AddTags(CustomTags ctags)
        {
            Ctags = Gettags();
            Ctags.Add(new CustomTags
            {
                Name = ctags.Name,
            });
            SaveTags(Ctags);
            return true;
        }
        public CustomTags GettagsById(Guid id)
        {
            Ctags = Gettags();
            return Ctags.FirstOrDefault(x => x.Id == id);
        }
        #endregion
        #region Adding transactions
        public bool AddInflow(Transaction transaction)
        {
            //if (dueDate < DateTime.Today)
            //{
            //    throw new Exception("Due date must be in the future.");
            //}


            _Transaction.Add(new Transaction
            {
                Title = transaction.Title,
                Amount = transaction.Amount,
                Type = transaction.Type,
                Date = transaction.Date,
                tagId = transaction.tagId,
            });
            SaveTransaction(_Transaction);
            return true;
        }
        public List<Transaction> GetAllTransactions()
        {
            var tranDetails = GetAllDetails();
            if (tranDetails != null)
            {
                return tranDetails;
            }
            else
            {
                return new List<Transaction>();
            }
        }

        public async Task <List<Transaction>> SearchTransaction(string searchName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchName))
                    throw new ArgumentNullException("Search Cannot be Null or Empty", nameof(searchName));

                return await Task.FromResult(
                    _Transaction
                    .Where(t => t.Date >= StartDate && t.Date <= EndDate)
                    .Where(t => t.Title.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList());

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while searching for the Transaction.", ex);
            }
        }
        #endregion
    }
}

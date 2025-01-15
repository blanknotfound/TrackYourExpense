
using DataModel.Model;
using TrackYourExpenses.Model;
using TrackYourExpenses.Model.Abstraction;
using TrackYourExpenses.Services.Interface;


namespace TrackYourExpenses.Services
{
    public class TransactionServices : TransactionServicesBase, ITransaction
    {
        private List<Transaction> _Transaction;
        private List<CustomTags> Ctags;
        public TransactionServices()
        {
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

        public List<Transaction> AddInflow(Transaction transaction)
        {
            //if (dueDate < DateTime.Today)
            //{
            //    throw new Exception("Due date must be in the future.");
            //}

            _Transaction = GetAllDetails();
            _Transaction.Add(new Transaction
            {
                Title = transaction.Title,
                Amount = transaction.Amount,
                Type = transaction.Type,
                Date = transaction.Date,
                tagId = transaction.tagId,
                Balanceamt = transaction.Balanceamt
            });
            SaveTransaction(_Transaction);
            return _Transaction;
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
    }
}

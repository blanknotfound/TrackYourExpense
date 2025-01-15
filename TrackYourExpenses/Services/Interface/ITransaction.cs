using DataModel.Model;
using TrackYourExpenses.Model;

namespace TrackYourExpenses.Services.Interface
{
    public interface ITransaction
    {
        List<Transaction> GetAllTransactions();
        CustomTags GettagsById(Guid id);
        List<CustomTags> GetTags();
        bool AddTags(CustomTags ctags);
        List<Transaction> AddInflow(Transaction transaction);
    }
}
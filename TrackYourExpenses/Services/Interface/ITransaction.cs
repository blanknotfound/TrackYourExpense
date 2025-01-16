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
        bool AddInflow(Transaction transaction);

        Task<List<Transaction>> SearchTransaction(string searchName);
    }
}
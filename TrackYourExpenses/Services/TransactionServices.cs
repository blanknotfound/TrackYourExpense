using TrackYourExpenses.Model;
using TrackYourExpenses.Services.Interface;

namespace TrackYourExpenses.Services
{
    public abstract class TransactionServices : TransactionServicesBase
    {
        private List<Transaction> _Transaction;
        public TransactionServices()
        {
            _Transaction = GetAll();
        }

        public static List <Transaction> AddInflow(string Id,String title, Decimal amount,String type, DateTime date, String notes)
        {
            //if (dueDate < DateTime.Today)
            //{
            //    throw new Exception("Due date must be in the future.");
            //}

            List<Transaction> inflow = GetAll();
            inflow.Add(new Transaction
            {
                Title = title,
                Amount = amount,
                Type = type,
                Date = date,
                Notes = notes
            });
            SaveTransaction(inflow);
            return inflow;
        }
    }
}

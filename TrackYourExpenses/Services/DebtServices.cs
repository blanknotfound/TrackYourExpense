using DataModel.Model;
using TrackYourExpenses.Model;
using TrackYourExpenses.Model.Abstraction;
using TrackYourExpenses.Services.Interface;

namespace TrackYourExpenses.Services
{
    public class DebtServices : DebtBase,IDebtServices
    {
        private readonly List<Debt> _debts = new();
        private readonly ITransaction _transactionService;

        public DebtServices(ITransaction transactionService)
        {
            _transactionService = transactionService;
            _debts = GetAllDebts();
        }
        public List<Debt> GetDebts()
        {
            if (_debts != null)
            {
                return _debts;
            }
            else
            {
                return new List<Debt>();
            }
        }

        public Debt AddDebt(Debt debt)
        {
            var inflowTransaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Title = $"Debt from{debt.Creditor}",
                Amount = debt.Amount,
                Date = DateTime.Now,
                Type = "Debt",
                tagId = Guid.NewGuid()
            };
            _transactionService.AddInflow(inflowTransaction);

            // Create the debt
            _debts.Add( new Debt
            {
                Id = Guid.NewGuid(),
                Title = debt.Title,
                Creditor = debt.Creditor,
                Amount = debt.Amount,
                takenDate = DateTime.Now,
                DueDate = debt.DueDate,
                TransactionId = inflowTransaction.Id
            });
            SaveDebt(_debts);
            return debt;
        }

        // Mark a debt as paid and link to an outflow transaction
        public void Updatedebt(Guid debtId)
        {
            var debt = _debts.FirstOrDefault(d => d.Id == debtId);
            if (debt == null || debt.Status)
            {
                throw new InvalidOperationException("Debt not found or already paid.");
            }

            // Create a linked outflow transaction
            var Transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Title = $"Debt payment to {debt.Creditor}",
                Amount = debt.Amount,
                Date = DateTime.Now,
                Type = "Debt Paid",
                tagId = Guid.NewGuid()
            };
            if (_transactionService.AddInflow(Transaction))
            {
                // Update the debt
                debt.Status = true;
                debt.PaidDate = DateTime.Now;
                debt.TransactionId = Transaction.Id;

                SaveDebt(_debts);
            }
            else
            {
                throw new Exception ("Balance not sufficient");
            }
        }

    }
}

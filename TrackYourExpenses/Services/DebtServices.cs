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
            _debts.Add(debt);
            SaveDebt(_debts);
            return debt;
        }
    }
}

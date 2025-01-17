using TrackYourExpenses.Model;

namespace TrackYourExpenses.Services.Interface
{
    public interface IDebtServices
    {
        Debt AddDebt(Debt debt);

        List<Debt> GetDebts();

        void Updatedebt(Guid debtId);
    }
}
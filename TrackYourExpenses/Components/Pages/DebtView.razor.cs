using MudBlazor;
using TrackYourExpenses.Model;

namespace TrackYourExpenses.Components.Pages
{
    public partial class DebtView
    {
        private Debt debt { get; set; } = new();
        private List<Debt> Debts;

        protected override void OnInitialized()
        {
            // Load all debts on initialization
            Debts = DebtServices.GetDebts();
        }
        private void AddDebt()
        {
            DebtServices.AddDebt(debt);
        }
        private void ChangeStatus(Guid debtId, bool Status)
        {
            //Update the debt's status
            if (Status)
            {
                DebtServices.Updatedebt(debtId);
            }
            else
            {

            }

            // Refresh the list of debts
            Debts = DebtServices.GetDebts();
        }
    }
}
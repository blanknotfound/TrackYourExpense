using MudBlazor;
using TrackYourExpenses.Model;

namespace TrackYourExpenses.Components.Pages
{
    public partial class DebtView
    {
        private Debt debt { get; set; } = new();

        private void AddDebt()
        {
            DebtServices.AddDebt(debt);
        }
    }
}
using Microsoft.AspNetCore.Components;
using DataModel.Model;

namespace TrackYourExpenses.Components.Pages
{
    public partial class Index :ComponentBase
    {
        [CascadingParameter]
        private UserState _LiveState { get; set; }

        protected override void OnInitialized()
        {
            if (_LiveState.LiveUser == null)
            {
                Nav.NavigateTo("/login");
            }
            else
            {
                Nav.NavigateTo("/dashboard");
            }
        }
    }

}

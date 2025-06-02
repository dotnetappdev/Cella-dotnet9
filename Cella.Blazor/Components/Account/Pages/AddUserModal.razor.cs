namespace Cella.Blazor.Components.Account.Pages
{
    public partial class AddUserModal
    {
        public bool Visible { get; set; }
        public void Open()
        {
            Visible = true;
            StateHasChanged();
        }
        public void Close()
        {
            Visible = false;
            StateHasChanged();
        }
    }
}

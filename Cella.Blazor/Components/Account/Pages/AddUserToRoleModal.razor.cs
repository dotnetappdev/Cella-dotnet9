namespace Cella.Blazor.Components.Account.Pages
{
    public partial class AddUserToRoleModal
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

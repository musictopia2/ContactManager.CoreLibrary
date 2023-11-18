namespace ContactManager.CoreLibrary.Components.Desktop;
public partial class DeleteContactComponent
{
    [Inject]
    IContactManager? Manager { get; set; }
    private BasicList<ContactModel> _contacts = new();
    private ContactModel _contact = new();
    protected override async Task OnInitializedAsync()
    {
        _contacts = await Manager!.GetContactsAsync();
    }
    private async Task DeleteContactAsync()
    {
        await Manager!.DeleteContactAsync(_contact);
        _contact = new();
        _contacts = await Manager!.GetContactsAsync(); //try again.
    }
}
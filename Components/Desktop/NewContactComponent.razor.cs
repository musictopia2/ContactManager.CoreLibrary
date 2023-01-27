namespace ContactManager.CoreLibrary.Components.Desktop;
public partial class NewContactComponent
{
    [CascadingParameter]
    private InputTabOrderNavigationContainer? TabOrderNavigationContainer { get; set; }
    private ContactModel Contact { get; set; } = new ContactModel();
    [Inject]
    IContactManager? Manager { get; set; }
    private void AddedPhoneNumber(PhoneModel phone)
    {
        Contact.PhoneNumbers.Add(phone);
    }
    private async Task OnValidSubmitAsync()
    {
        await Manager!.AddContactAsync(Contact);
        Contact = new(); //i think.
        await TabOrderNavigationContainer!.FocusFirstAsync(); //i think.
    }
}
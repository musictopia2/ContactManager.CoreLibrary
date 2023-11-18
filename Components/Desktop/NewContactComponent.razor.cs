using BasicBlazorLibrary.Components.Inputs;

namespace ContactManager.CoreLibrary.Components.Desktop;
public partial class NewContactComponent
{
    private ContactModel Contact { get; set; } = new ContactModel();
    [Inject]
    IContactManager? Manager { get; set; }
    private AutoCompleteStyleModel _model = new();
    private InputEnterText? _firstElement;
    protected override void OnInitialized()
    {
        _model.Width = "30vw";
        _model.Height = "20vh";
        base.OnInitialized();
    }
    private void AddedPhoneNumber(PhoneModel phone)
    {
        Contact.PhoneNumbers.Add(phone);
    }
    private async Task OnValidSubmitAsync()
    {
        //looks like i have to clone it somehow or another.
        ContactModel contact = new();
        contact.PhoneNumbers.AddRange(Contact.PhoneNumbers);
        contact.Relationship = Contact.Relationship;
        contact.DisplayName = Contact.DisplayName;
        await Manager!.AddContactAsync(contact);
        Contact.PhoneNumbers.Clear();
        Contact.Relationship = EnumRelationship.None;
        Contact.DisplayName = "";
        //adding contact does not do any driving instructions.
        //Contact = new(); //i think.
        await _firstElement!.FocusAsync();
        //await TabOrderNavigationContainer!.FocusFirstAsync(); //i think.
        

    }
}
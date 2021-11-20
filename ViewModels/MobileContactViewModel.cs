namespace ContactManager.CoreLibrary.ViewModels;
public class MobileContactViewModel
{
    private readonly IContactManager _manager;
    private readonly IContactContainer _container;
    private readonly ICaller _caller;
    private readonly IToast _toast;
    public string Status { get; set; } = "";
    public Action? StateChanged { get; set; }
    public BasicList<string> Contacts { get; private set; } = new();
    public ContactModel? ContactChosen { get; private set; }
    public bool Processing { get; set; } = true;
    public string Title => ContactChosen is null ? "Choose Contact" : "View Contact";
    public bool CanGoBack => ContactChosen is not null;
    public MobileContactViewModel(IContactManager manager,
        IContactContainer container, 
        ICaller caller,
        IToast toast
        )
    {
        _manager = manager;
        _container = container;
        _caller = caller;
        _toast = toast;
    }
    public async Task InitAsync()
    {
        _container.Contacts = await _manager.GetContactsAsync();
        UpdateContacts();
        Processing = false;
    }
    private void UpdateContacts()
    {
        Contacts = _container.Contacts.Select(xx => xx.DisplayName).ToBasicList();
        Contacts.Sort();
    }
    public void ChooseContact(string name)
    {
        ContactChosen = _container.Contacts.Single(xx => xx.DisplayName == name);
        StateChanged?.Invoke(); //try this.
    }
    public void GoBack()
    {
        ContactChosen = null;
    }
    public async Task DownloadContactsAsync()
    {
        if (ContactChosen is not null)
        {
            throw new CustomBasicException("Should not have allowed downloading contacts because you have a contact chosen");
        }
        try
        {
            Status = "Downloading Contacts";
            StateChanged?.Invoke();
            await Task.Delay(10);
            await _manager.DownloadContactsAsync(); //hopefully this solves all this.
        }
        catch (Exception ex)
        {
            _toast.ShowWarningToast(ex.Message);
            return;
        }
        if (_container.Contacts.Count == 0)
        {
            _toast.ShowWarningToast("Failed to get downloads");
            return;
        }
        if (_container.Contacts.First().PhoneNumbers.Count == 0)
        {
            _toast.ShowWarningToast("Should have at least one phone number");
            return;
        }
        UpdateContacts();
        Status = "";
    }
    public void MakePhoneCall(PhoneModel phone)
    {
        _caller.CallSpecificNumber(phone.PhoneNumber);
    }
}
namespace ContactManager.CoreLibrary.ViewModels;
public class DesktopContactViewModel
{
    private readonly IContactManager _manager;
    public DesktopContactViewModel(IContactManager manager)
    {
        _manager = manager;
    }
    public string UploadMessageText = "";
    public EnumDesktopContactStatus Status { get; set; } = EnumDesktopContactStatus.None; //this is main page.
    public void StartAddContact()
    {
        Status = EnumDesktopContactStatus.AddContact;
    }
    public void GoBack()
    {
        Status = EnumDesktopContactStatus.None; //i think going back will go to main page (?)
    }
    public void StartUploads()
    {
        Status = EnumDesktopContactStatus.UploadContacts; //this means the button can appear to upload the contacts.
    }
    public async Task DoUploadAsync()
    {
        try
        {
            await _manager.UploadContactsAsync();
            UploadMessageText = "Upload Successfully";
        }
        catch (Exception ex)
        {
            UploadMessageText = ex.Message;
        }
    }
    public bool CanGoBack => Status != EnumDesktopContactStatus.None;
    public string Title
    {
        get
        {
            if (Status == EnumDesktopContactStatus.None)
            {
                return "Main Page";
            }
            if (Status == EnumDesktopContactStatus.AddContact)
            {
                return "Adding New Contact";
            }
            if (Status == EnumDesktopContactStatus.UploadContacts)
            {
                return "Upload Contacts";
            }
            if (Status == EnumDesktopContactStatus.EditContact)
            {
                return "Edit Contacts";
            }
            return "None";
        }
    }
}

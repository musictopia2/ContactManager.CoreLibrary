namespace ContactManager.CoreLibrary.Logic;
//this is used for both the sample and the android.  has to be this way so i can test ahead of time on desktop.
public class ContactMobileFileStorage : IContactStorage
{
    private readonly string _storagePath;
    public ContactMobileFileStorage()
    {
        if (bb1.OS == bb1.EnumOS.Android)
        {
            _storagePath = @$"{fs1.GetApplicationDataForMobileDevices()}/Contacts.json";
        }
        else if (bb1.OS == BasicDataFunctions.EnumOS.WindowsDT)
        {
            _storagePath = Path.Combine(aa1.GetApplicationPath(), "Contacts.json");
        }
        else
        {
            throw new CustomBasicException("Only windows desktop or android is supported at this time");
        }
    }
    public Task<BasicList<ContactModel>> GetContactsAsync()
    {
        if (fs1.FileExists(_storagePath) == false)
        {
            return Task.FromResult(new BasicList<ContactModel>());
        }
        var output = js1.RetrieveSavedObject<BasicList<ContactModel>>(_storagePath);
        return Task.FromResult(output);
    }
    public async Task SaveContactsAsync(BasicList<ContactModel> contacts)
    {
        await js1.SaveObjectAsync(_storagePath, contacts);
    }
}
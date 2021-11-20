namespace ContactManager.CoreLibrary.Logic;
public class BasicContactManager : IContactManager
{
    private readonly IContactContainer _contactContainer;
    private readonly IContactDownloader _contactDownloader;
    private readonly IContactStorage _contactStorage;
    public BasicContactManager(IContactContainer contactContainer,
        IContactDownloader contactDownloader,
        IContactStorage contactStorage
        )
    {
        _contactContainer = contactContainer;
        _contactDownloader = contactDownloader;
        _contactStorage = contactStorage;
    }
    public async Task AddContactAsync(ContactModel contact)
    {
        if (_contactContainer.Contacts.Count == 0)
        {
            _contactContainer.Contacts = await GetContactsAsync();
        }
        _contactContainer.Contacts.Add(contact);
        await SaveChangesAsync();
    }
    public async Task AddPhoneAsync(PhoneModel phone)
    {
        _contactContainer.CurrentContact!.PhoneNumbers.Add(phone);
        await SaveChangesAsync();
    }
    public async Task<BasicList<ContactModel>> GetContactsAsync()
    {
        return await _contactStorage.GetContactsAsync();
    }
    public ContactModel GetSingleContact(string displayName)
    {
        if (_contactContainer.Contacts.Count == 0)
        {
            throw new CustomBasicException("There are no contacts");
        }
        return _contactContainer.Contacts.Single(x => x.DisplayName == displayName);
    }
    public async Task SaveChangesAsync()
    {
        await _contactStorage.SaveContactsAsync(_contactContainer.Contacts);
    }
    public async Task DownloadContactsAsync()
    {
        _contactContainer.Contacts = await _contactDownloader.DownloadContactsAsync();
        await SaveChangesAsync();
    }
    public async Task UploadContactsAsync()
    {
        if (_contactContainer.Contacts.Count == 0)
        {
            _contactContainer.Contacts = await GetContactsAsync();
        }
        await _contactDownloader.UploadContactsAsync(_contactContainer.Contacts);
    }
}
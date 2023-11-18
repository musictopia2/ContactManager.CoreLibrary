namespace ContactManager.CoreLibrary.Logic;
public interface IContactManager
{
    Task SaveChangesAsync();
    Task AddPhoneAsync(PhoneModel phone);
    Task AddContactAsync(ContactModel contact);
    Task DeleteContactAsync(ContactModel contact);
    Task UploadContactsAsync();
    Task DownloadContactsAsync();
    Task<BasicList<ContactModel>> GetContactsAsync();
    ContactModel GetSingleContact(string displayName);
}
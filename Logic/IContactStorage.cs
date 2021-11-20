namespace ContactManager.CoreLibrary.Logic;
public interface IContactStorage
{
    Task SaveContactsAsync(BasicList<ContactModel> contacts);
    Task<BasicList<ContactModel>> GetContactsAsync();
}
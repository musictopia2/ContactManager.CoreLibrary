namespace ContactManager.CoreLibrary.Logic;
public interface IContactDownloader
{
    Task<BasicList<ContactModel>> DownloadContactsAsync();
    Task UploadContactsAsync(BasicList<ContactModel> contacts);
}
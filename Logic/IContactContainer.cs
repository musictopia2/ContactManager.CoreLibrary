namespace ContactManager.CoreLibrary.Logic;
public interface IContactContainer
{
    BasicList<ContactModel> Contacts { get; set; }
    ContactModel? CurrentContact { get; set; }
}
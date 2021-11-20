namespace ContactManager.CoreLibrary.Models;
public class ContactModel : IComparable<ContactModel>, IMappable
{
    [EnsureOneElement(ErrorMessage = "You must have at least one phone number")]
    public BasicList<PhoneModel> PhoneNumbers { get; set; } = new();
    [Required]
    [MinLength(2)]
    [MaxLength(60)]
    public string DisplayName { get; set; } = "";
    public string EmailAddress { get; set; } = "";
    public string StreetAddress { get; set; } = "";
    public string City { get; set; } = "";
    public string State { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string Notes { get; set; } = "";
    public string DrivingInstructions { get; set; } = "";
    [Range(1, 6)]
    public EnumRelationship Relationship { get; set; }
    int IComparable<ContactModel>.CompareTo(ContactModel? other)
    {
        return DisplayName.CompareTo(other!.DisplayName);
    }
}
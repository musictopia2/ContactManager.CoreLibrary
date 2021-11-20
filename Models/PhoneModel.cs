namespace ContactManager.CoreLibrary.Models;
public class PhoneModel : IMappable //try to make it mappable.
{
    [Phone]
    public string PhoneNumber { get; set; } = "";
    [Range(1, 6)]
    public EnumPhoneCategory PhoneCategory { get; set; }
    public override string ToString()
    {
        return $"{PhoneNumber} for category {PhoneCategory}";
    }
}
namespace ContactManager.CoreLibrary.Components.Mobile;
public partial class MobileViewBasicContactComponent
{
    private static string GetDisplay(EnumPhoneCategory phone) => phone.ToString().GetWords;
}
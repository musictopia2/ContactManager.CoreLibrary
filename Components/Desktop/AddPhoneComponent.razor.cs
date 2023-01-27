namespace ContactManager.CoreLibrary.Components.Desktop;
public partial class AddPhoneComponent
{
    [Parameter]
    public EventCallback<PhoneModel> AddedPhoneNumber { get; set; }
    private PhoneModel NewNumber { get; set; } = new PhoneModel();
    public AddPhoneComponent()
    {
        NewNumber.PhoneCategory = EnumPhoneCategory.HomeMainPhone; //maybe here.
    }
    private async Task OnValidSubmit()
    {
        //looks like i have to clone it now.
        PhoneModel model = NewNumber.AutoMap<PhoneModel>();

        await AddedPhoneNumber.InvokeAsync(model);
        NewNumber.PhoneNumber = ""; //hopefully this simple (?)

        NewNumber.PhoneCategory = EnumPhoneCategory.HomeMainPhone;
    }
    
}
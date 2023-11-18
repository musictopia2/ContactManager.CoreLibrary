namespace ContactManager.CoreLibrary.Components.Desktop;
public partial class AddPhoneComponent
{
    [Parameter]
    public AutoCompleteStyleModel Style { get; set; } = new();
    [Parameter]
    public EventCallback<PhoneModel> AddedPhoneNumber { get; set; }
    private PhoneModel NewNumber { get; set; } = new PhoneModel();
    public AddPhoneComponent()
    {
        NewNumber.PhoneCategory = EnumPhoneCategory.HomeMainPhone; //maybe here.
    }
    private async Task OnValidSubmit()
    {
        PhoneModel model = new();
        //looks like i have to do manually since i did not do any source generators stuff.
        //not sure what sample i would have for this though (?)
        model.PhoneNumber = NewNumber.PhoneNumber;
        model.PhoneCategory = NewNumber.PhoneCategory;


        await AddedPhoneNumber.InvokeAsync(model);
        NewNumber.PhoneNumber = ""; //hopefully this simple (?)

        NewNumber.PhoneCategory = EnumPhoneCategory.HomeMainPhone;

    }
    
}
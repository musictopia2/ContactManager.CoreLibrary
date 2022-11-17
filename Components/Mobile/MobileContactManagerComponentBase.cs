namespace ContactManager.CoreLibrary.Components.Mobile;
public abstract class MobileContactManagerComponentBase : ComponentBase
{
    [Inject]
    [AllowNull]
    protected MobileContactViewModel? DataContext { get; set; }
}
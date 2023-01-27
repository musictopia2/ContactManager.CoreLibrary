namespace ContactManager.CoreLibrary.Components.Desktop;
public partial class DesktopContactShellComponent
{
    [Inject]
    [AllowNull]
    protected DesktopContactViewModel? DataContext { get; set; }
    protected override void OnInitialized()
    {
        DataContext!.UploadMessageText = "";
        base.OnInitialized();
    }
}
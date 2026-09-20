using CommunityToolkit.Mvvm.ComponentModel;

namespace LMSPH1_PROYECT_MANAGER.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to Avalonia!";
}

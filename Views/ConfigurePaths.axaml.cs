using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LMSPH1_PROYECT_MANAGER.ViewModels.ConfigurePaths;

namespace LMSPH1_PROYECT_MANAGER.Views;

public partial class ConfigurePaths : Window
{
    public ConfigurePaths()
    {
        InitializeComponent();
    }

    private void SaveConfig_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        Close(true);
    }

    private void CanceConfig_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(false);
    }
}
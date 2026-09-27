using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LMSPH1_PROYECT_MANAGER.Views;

public partial class NewProject : Window
{
    public NewProject()
    {
        InitializeComponent();
    }

    private void CreateButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(true);
    }

    private void CancelButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(false);
    }
}
using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using SkiaSharp;

namespace LMSPH1_PROYECT_MANAGER.Views;

public partial class MainWindow : Window
{
     public string GameBase = "";
    public MainWindow()
    {
        InitializeComponent();
         Opened += async (_, _) => await obtenerFolder();
    }

    public async Task obtenerFolder()
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel is null) return;

        var storage = topLevel.StorageProvider;

        // Open file picker
        var folder = await storage.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Select game base",
            AllowMultiple = false
        });       

        if (folder.Count > 0)
        {
            GameBase = $"{folder[0].Path.AbsolutePath}{folder[0].Name}";
        }
        Console.WriteLine(GameBase);
    }


}
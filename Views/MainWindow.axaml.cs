using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using LMSPH1_PROYECT_MANAGER.Core;
using LMSPH1_PROYECT_MANAGER.Models.Confg;
using LMSPH1_PROYECT_MANAGER.Utils;
using SkiaSharp;

namespace LMSPH1_PROYECT_MANAGER.Views;

public partial class MainWindow : Window
{
     public Maker app;
    public MainWindow()
    {
        InitializeComponent();
        app = new Maker(this);
    }

   
    


}
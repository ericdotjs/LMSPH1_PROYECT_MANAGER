using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace LMSPH1_PROYECT_MANAGER.Utils
{
    public sealed class DirectoriesSetters
    {
        public string gameBaseDir {get; set;} = String.Empty; 

        public string projectsDir {get; set;} = String.Empty; 
        public string projectsReleasedDir {get; set;} = String.Empty;
        public async Task GetPaths(Visual? window){
        gameBaseDir = await PickGetFolderPath(window, "Selet Game Base diretory");
        projectsDir = await PickGetFolderPath(window, "Selet Projects Folder");     
        projectsReleasedDir = await PickGetFolderPath(window, "Selet Builds Folder");          
        }

    private async Task<string> PickGetFolderPath(Visual? window, string title)
        {
                var topLevel = TopLevel.GetTopLevel(window);
        if (topLevel is null) return string.Empty;

        var storage = topLevel.StorageProvider;
             var folder = await storage.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = title,
            AllowMultiple = false,
        });       

        if (folder.Count > 0)
        {
            Console.WriteLine($"{folder[0].Path.LocalPath}");
            return folder[0].Path.LocalPath;
        }
        
        return string.Empty;
        }
    }
}
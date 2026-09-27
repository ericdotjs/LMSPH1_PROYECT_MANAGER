using System.Threading.Tasks;
using Avalonia;
using ConfigSettings = LMSPH1_PROYECT_MANAGER.Models.Confg;
using LMSPH1_PROYECT_MANAGER.Utils;
using System.IO;
using System;
using LMSPH1_PROYECT_MANAGER.Views;
using LMSPH1_PROYECT_MANAGER.ViewModels.ConfigurePaths;
using LMSPH1_PROYECT_MANAGER.ViewModels.Project;
using LMSPH1_PROYECT_MANAGER.Models.Project;

namespace LMSPH1_PROYECT_MANAGER.Core
{
    public sealed class Maker
    {
        private Project project;
        private DirectoriesSetters directoriesSetters;
        private StorageSettings storageSettings;  
        private Visual mainWWindow;
        public Maker(Visual visual)
        {
            directoriesSetters = new DirectoriesSetters();
            storageSettings = new StorageSettings();
            mainWWindow = visual;
            project = new Project();
            _ = ScanSettingsFile();

        }
        public async Task openDialogSettingsPaths()
        {

           ConfigurePathsViewModel vm = new ConfigurePathsViewModel(
                storageSettings.config);

            var dialog = new ConfigurePaths()
            {
                DataContext = vm
            };
            bool? result = await dialog.ShowDialog<bool?>((Avalonia.Controls.Window) mainWWindow);
            if(result == true)
            {
                vm.ApplyChanges();
                storageSettings.config = vm._config;
                await storageSettings.SaveSettings(vm._config);
                await storageSettings.LoadSettings();
            }
           
        }
        public async Task openDialogNewProject()
        {
            ProjectViewModel vm = new ProjectViewModel(project);
            var dialog = new NewProject()
            {
                DataContext = vm
            };
            bool? result = await dialog.ShowDialog<bool?>((Avalonia.Controls.Window) mainWWindow);
            if(result == true)
            {
                vm.ApplyChanges();
                project = vm._project;
            }


        }
        public async Task ScanSettingsFile()
        {
            if (storageSettings.FileExists)
            {
              bool isLoaded = await storageSettings.LoadSettings();
                if (!isLoaded)
                {
                    await MangeConfig();
                }
                
            }
            else
            {
                if(!storageSettings.FolderExist)
                    Directory.CreateDirectory(storageSettings.folderSettings);
                    
                await directoriesSetters.GetPaths(mainWWindow);
                await storageSettings.SaveSettings(new ConfigSettings.Config{
                    GAME_BASE_PATH = directoriesSetters.gameBaseDir, 
                    PROJETS_PATH_DIR = directoriesSetters.projectsDir, 
                    PROJECTS_PUBLSH_DIR = directoriesSetters.projectsReleasedDir});
            }

        }

        public async Task MangeConfig()
        {
            try
            {
                await directoriesSetters.GetPaths(mainWWindow);
            }
            finally
            {
                await storageSettings.SaveSettings(new ConfigSettings.Config()
                {
                    GAME_BASE_PATH = directoriesSetters.gameBaseDir,
                    PROJETS_PATH_DIR = directoriesSetters
            .projectsDir,
                    PROJECTS_PUBLSH_DIR = directoriesSetters.projectsReleasedDir
                });
            }
        }
    }
}
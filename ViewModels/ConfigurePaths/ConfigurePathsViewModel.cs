using System;
using CommunityToolkit.Mvvm.ComponentModel;
using LMSPH1_PROYECT_MANAGER.Models.Confg;

namespace LMSPH1_PROYECT_MANAGER.ViewModels.ConfigurePaths
{
    public partial class ConfigurePathsViewModel : ViewModelBase{

        [ObservableProperty]
        public partial string GameBase {get; set;} = string.Empty;
        [ObservableProperty]
        public partial string Projects {get; set;} = string.Empty;
        [ObservableProperty]
        public partial string Publish {get; set;} = string.Empty; 
        public readonly Config _config;

        public ConfigurePathsViewModel()
        {

        }
        public ConfigurePathsViewModel(Config config)
        {
            _config = config;
            GameBase = _config.GAME_BASE_PATH;
            Projects = _config.PROJETS_PATH_DIR;
            Publish = _config.PROJECTS_PUBLSH_DIR;
        }
        public void ApplyChanges
        ()
        {
            
                _config.GAME_BASE_PATH = GameBase;
                _config.PROJETS_PATH_DIR = Projects;
                _config.PROJECTS_PUBLSH_DIR = Publish;
    
        }
    }
}
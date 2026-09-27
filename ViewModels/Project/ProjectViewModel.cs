using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using LMSPH1_PROYECT_MANAGER.Utils;
using ProjectModel = LMSPH1_PROYECT_MANAGER.Models.Project.Project;

namespace LMSPH1_PROYECT_MANAGER.ViewModels.Project
{
    public partial class ProjectViewModel : ViewModelBase
    {
        public readonly ProjectModel _project;
        [ObservableProperty]
        public partial string Name { get; set; } = string.Empty;
        [ObservableProperty]
        public partial string Description { get; set; } = string.Empty;
        [ObservableProperty]
        public partial string Author { get; set; } = string.Empty;
        [ObservableProperty]
        public partial string? Credits { get; set; }
        [ObservableProperty]
        public partial string Category { get; set; } = string.Empty;

        public ObservableCollection<string> Templates {get;} = new()
        {
            Const.CHARACTER,
            Const.ITEM
        };
        [ObservableProperty]
        public partial string? SelectedTemplate { get; set; }


        public ProjectViewModel()
        {
            SelectedTemplate = Templates[0];
        }
        public ProjectViewModel(ProjectModel project)
        {
            _project = project;
            Name = _project.projectName;
            Description = _project.projectDescription;
            Author = _project.projectAuthor;
            Category = _project.projectCategory;            
            SelectedTemplate = Templates[0];
        }

        public void ApplyChanges()
        {
          _project.projectName = Name;
          _project.projectDescription = Description;
          _project.projectAuthor = Author;
          _project.projectCategory = Category;
          _project.projectCreatedAt = _project.projectCreatedAt is null ? DateTime.Now : _project.projectCreatedAt;  
        }    

    }
}
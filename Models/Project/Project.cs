using System;
using LMSPH1_PROYECT_MANAGER.Utils;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace LMSPH1_PROYECT_MANAGER.Models.Project;

public sealed class Project
{
    public string projectName {get; set;} = string.Empty;
    public string projectDescription {get; set;} = string.Empty;
    public string projectAuthor {get; set;} = string.Empty;
    public string projectCategory {get; set;} = string.Empty;
    public string projectPath {get; set;} = string.Empty;
    public DateTime? projectCreatedAt {get; set;}
    public DateTime? projectUpdateAt {get; set;}

    public override string ToString()
    {
        return JSonManager.SerializeObject(this);
    }
}
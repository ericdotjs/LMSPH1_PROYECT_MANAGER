using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls.Documents;
using LMSPH1_PROYECT_MANAGER.Models.Confg;
using Newtonsoft.Json;

namespace LMSPH1_PROYECT_MANAGER.Utils;
public sealed class StorageSettings

{
    public string basePath = String.Empty;
    public string folderSettings = String.Empty;
    public string fileName = String.Empty;
    public string fileFullPath = String.Empty;
    public Config? config;
    public bool settingsExist = false;
    public StorageSettings()
    {
        basePath = AppDomain.CurrentDomain.BaseDirectory;
        folderSettings = $"{basePath}settings";
        fileName = "config.json";
        fileFullPath = $"{folderSettings}/{fileName}";
    }

    public bool FolderExist => Directory.Exists(folderSettings);
    public bool FileExists => Path.Exists(fileFullPath);
    public async Task SaveSettings(Config newConfig)
    {
       config = newConfig;
       string settings = JsonConvert.SerializeObject(config); 
       await File.WriteAllTextAsync(fileFullPath,settings, CancellationToken.None);
    }


    public async Task<bool> LoadSettings()
    {
       
            config = JsonConvert.DeserializeObject<Config>(await File.ReadAllTextAsync(fileFullPath, CancellationToken.None));
            if(config is null)
                    return false;

             return true;          

    }


}
using System.IO;
using UnityEngine;

public class OpenModsFolder : MonoBehaviour
{
    public void OpenFolderInExplorer()
    {
        if (!Directory.Exists(Application.dataPath + "/Mods"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Mods");
        }
        Application.OpenURL("file://" + Application.dataPath + "/Mods");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Text;

public class ModsLoader : MonoBehaviour
{
    public LuaCell[] modcells;

    private static ModsLoader i;

    private static void validateFiles()
    {
        if (!Directory.Exists(Application.dataPath + "/Mods"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Mods");
        }
    }

    public static void LoadModCellsSet(string folderName)
    {
        validateFiles();

        foreach (LuaCell luacell in ModsLoader.i.modcells)
        {
            if (File.Exists(Application.dataPath +  "/Mods/" + folderName + "/" + luacell.name + ".lua"))
            {
                string[] nameToPath = luacell.name.Split(" ");
                StringBuilder path = new StringBuilder();
                foreach (string divide in nameToPath)
                {
                    path.Append(divide.ToLower());
                }
                Script vm = new Script();
                vm.DoString(path + ".lua"));

                GameObject clone = Instantiate(cellPrefab);
                clone.GetComponent<Transform>().position = new Vector3(69420, 42069, 0);
                try
                {
                    byte[] img = File.ReadAllBytes(Application.dataPath + "/Mods/" + folderName + vm.Globals.Get("texture").String);
                    Texture2D texture2D = UnityEngine.Object.Instantiate<Texture2D>(template.texture);
                    texture2D.LoadImage(img);
                    Sprite sprite2 = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0.5f, 0.5f), (float)((texture2D.width > texture2D.height) ? texture2D.width : texture2D.height));
                    sprite2.name = "Sprite";
                    clone.GetComponent<SpriteRenderer>().sprite = sprite2;
                    sprites.Add(sprite2);
                }
                catch
                {
                    sprites.Add(template);
                }

                clone.GetComponent<LuaCell>().cellType = cellIndex;
                cellUpdateTypeDictionary.Add(cellIndex, CellUpdateType_e.TRACKED);
                cellTypes.Add(vm.Globals.Get("id").String);

                try
                {
                    int afterIndex = Array.FindIndex(CellType_e, w => w == vm.Globals.Get("updateAfter").String);
                    cellUpdateOrder.Insert(afterIndex + 1, cellIndex);
                }
                catch
                {
                    cellUpdateOrder.Add(cellIndex);
                }

                DontDestroyOnLoad(clone);

                cellPrefabsList.Add(clone);
                notifications.text += "\n\"" + vm.Globals.Get("name").String + "\" by " + vm.Globals.Get("author").String "of mod: " folderName);
                cellIndex += 1;
                ScriptsTexts.Add(File.ReadAllText(file.FullName));
            }
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        ModsLoader.i = this;

        validateFiles();

        string[] ModsPathDirectory = new Directory(Directory.GetDirectories(Application.dataPath + "/Mods");
        foreach (string mod in ModsPathDirectory) 
        { 
            ModsLoader.LoadModCellsSet(mod);  
        }
    }

    public void Reload()
    {
        debounce = false;
        notifications = GameObject.Find("Header2 (2)").GetComponent<Text>();
        buttons = GameObject.Find("Buttons");
        reload = GameObject.Find("Reload");
        status = GameObject.Find("StatusWrapper").transform.GetChild(0).gameObject;
        notifications.text = "";
        CellFunctions.cellUpdateTypeDictionary = new Dictionary<int, CellUpdateType_e>
        {
            [0] = CellUpdateType_e.TRACKED,
            [1] = CellUpdateType_e.TICKED,
            [2] = CellUpdateType_e.TICKED,
            [3] = CellUpdateType_e.TRACKED,
            [4] = CellUpdateType_e.BASE,
            [5] = CellUpdateType_e.BASE,
            [6] = CellUpdateType_e.BASE,
            [7] = CellUpdateType_e.BASE,
            [8] = CellUpdateType_e.BASE
        };
        ScriptsTexts = new List<string>();
        CellFunctions.cellUpdateOrder = new List<int> { 0, 1, 2, 3 };
        cellIndex = 9;
        sprites = new List<Sprite>();
        CellType_New = new string[0];
        buttons.SetActive(false);
        reload.SetActive(false);
        status.SetActive(true);
        Awake();
    }
}
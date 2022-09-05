using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Save;
using System.IO;

public class ExitScript : MonoBehaviour
{
    private static bool isSavesLoaded = false;

    private void OnEnable()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data.dat") && !isSavesLoaded)
        {
            SaveScr.CreateSave();
            isSavesLoaded = true;
        }
        else if (File.Exists(Application.persistentDataPath + "/Data.dat") && !isSavesLoaded)
        {
            SaveScr.LoadSave();
            isSavesLoaded = true;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}

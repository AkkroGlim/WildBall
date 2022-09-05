using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Save;
using System.IO;
using UnityEngine.Audio;

public class ExitScript : MonoBehaviour
{
    private static bool isSavesLoaded = false;
    [SerializeField] private AudioMixer am;
    private float[] amValue;
    private void OnEnable()
    {
        if (!File.Exists(Application.dataPath + "/Data.dat") && !isSavesLoaded)
        {
            SaveScr.CreateSave();
            isSavesLoaded = true;
            
        }
        else if (File.Exists(Application.dataPath + "/Data.dat") && !isSavesLoaded)
        {
            SaveScr.LoadSave();
            amValue = SaveScr.VolumeValueForLoad();
            am.SetFloat("masterVolume", amValue[0]);
            am.SetFloat("musicVolume", amValue[1]);
            am.SetFloat("soundVolume", amValue[2]);
            isSavesLoaded = true;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}

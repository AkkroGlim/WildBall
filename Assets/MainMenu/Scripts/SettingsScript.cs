using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private bool isFullScreen = true;

    Resolution[] rsl;
    List<string> resolutions;
    [SerializeField] private Dropdown dropdown;
    



    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
        dropdown.value = 12;
    }


    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }

    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }
   

    public void FullScreenToggle()
    {
       
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
}

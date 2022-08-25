using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private bool fullScreenFlag;
    private static Resolution[] rsl;
    private static List<string> resolutions;
    [SerializeField] private Dropdown dropdown;
    [SerializeField] private Toggle isFullScreenTogle;
    


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
        if (!isFullScreenTogle.isOn.Equals(Screen.fullScreen))
        {
            isFullScreenTogle.isOn = Screen.fullScreen;
            
        }
        fullScreenFlag = true;



    }

    
    public void Resolution(int r)
    {
        //Screen.SetResolution(rsl[r].width, rsl[r].height, Screen.fullScreen);
    }

    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }
   

    public void FullScreenToggle()
    {
        if (fullScreenFlag)
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
               
    }
}

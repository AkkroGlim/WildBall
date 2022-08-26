using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private bool fullScreenFlag;
    private bool resolutionFlag;
    private static Resolution[] rsl;
    private static List<string> resolutions;
    [SerializeField] private Dropdown dropdownResolution;
    [SerializeField] private Dropdown dropdownQuality;
    [SerializeField] private Toggle isFullScreenTogle;
    


    public void Awake()
    {     
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdownResolution.ClearOptions();
        dropdownResolution.AddOptions(resolutions);




    }

    private void OnEnable()
    {
        for (int q = 0; q < rsl.Length; q++)
        {
            if (Screen.currentResolution.height.Equals(rsl[q].height) && Screen.currentResolution.width.Equals(rsl[q].width))
            {
                dropdownResolution.value = q; // подумать , что можно сделать
                Debug.Log(q);
                resolutionFlag = true;
            }
        }
        
        if (!isFullScreenTogle.isOn.Equals(Screen.fullScreen))
        {
            isFullScreenTogle.isOn = Screen.fullScreen;
        }
        fullScreenFlag = true;

        dropdownQuality.value = QualitySettings.GetQualityLevel();
    }

    private void OnDisable()
    {
        fullScreenFlag = false;
        resolutionFlag = false;
    }
    public void Resolution(int r)
    {
        if (resolutionFlag)
        {
            Screen.SetResolution(rsl[r].width, rsl[r].height, Screen.fullScreen);
            
        }

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

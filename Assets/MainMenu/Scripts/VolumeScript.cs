using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Save;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private AudioMixer am;
    [SerializeField] private Slider slid;
    private static float[] slidersValue = new float[3];
    private string[] slidersName = new string[3] { "masterVolume", "musicVolume", "soundsVolume" };

    private void OnEnable()
    {
        LoadSlider();
    }

    private void OnDisable()
    {
        SaveSlider();
    }
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat(gameObject.name, sliderValue);
    }

    public void LoadSlider()
    {
        for (int i = 0; i < slidersName.Length; i++)
        {
            slidersValue = SaveScr.VolumeValueForLoad();
            if (gameObject.name.Equals(slidersName[i]))
            {
                slid.value = slidersValue[i];
            }
        }
    }

    public void SaveSlider()
    {
        for (int i = 0; i < slidersName.Length; i++)
        {
            if (gameObject.name.Equals(slidersName[i]))
            {
                slidersValue[i] = slid.value;
            }
        }
        SaveScr.VolumeValueToSave(slidersValue[0], slidersValue[1], slidersValue[2]);
    }

    
}

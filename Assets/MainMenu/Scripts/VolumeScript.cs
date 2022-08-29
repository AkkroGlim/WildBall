using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private AudioMixer am;
    [SerializeField] private Slider slid;
    private static float[] slidersValue = new float[3];
    private string[] slidersName = new string[3] {"masterVolume", "musicVolume", "soundsVolume" };

    private void OnEnable()
    {
        for( int i = 0; i < slidersName.Length; i++)
        {
            if (gameObject.name.Equals(slidersName[i]))
            {
                slid.value = slidersValue[i];
            }
        }

    }

    private void OnDisable()
    {
        for (int i = 0; i < slidersName.Length; i++)
        {
            if (gameObject.name.Equals(slidersName[i]))
            {
                slidersValue[i] = slid.value;
            }
        }
    }
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat(gameObject.name, sliderValue);
    }
}

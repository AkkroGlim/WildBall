using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private AudioMixer am;
    [SerializeField] private Slider slid;

    private void OnEnable()
    {
       
        
    }
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat(gameObject.name, sliderValue);
    }
}

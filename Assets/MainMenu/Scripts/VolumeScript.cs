using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private AudioMixer am;

    public void Start()
    {
        Debug.Log(gameObject.name);
    }
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat(gameObject.name, sliderValue);
    }
}

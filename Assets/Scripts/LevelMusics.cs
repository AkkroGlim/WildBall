using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusics : MonoBehaviour
{
    [SerializeField] private List<AudioClip> clips;
    private GameObject audioObject;
    private AudioSource music;

    private void Awake()
    {
        audioObject = GameObject.FindGameObjectWithTag("Audio");
        music = audioObject.transform.GetChild(1).GetComponent<AudioSource>();
        foreach (AudioClip clip in clips)
        {
            if (music.clip.name.Equals(clip.name))
            {
                music.clip = clips[SceneManager.GetActiveScene().buildIndex - 1];
                music.loop = true;
                music.Play();
                break;
            }
        }
    }
}

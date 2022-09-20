using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using One;


public class MusicScr : MonoBehaviour
{
    [SerializeField] private List<Track> musics = new List<Track>(4);
    [SerializeField] private GameObject musicMenu;
    [SerializeField] private AudioSource music;
    [SerializeField] private List<AudioClip> clips;
    private GameObject compliteMenu;
    private List<Transform> menus = new List<Transform>(3);

    private void Start()
    {
        menus.Add(transform.GetChild(0));
        menus.Add(transform.GetChild(1));
        menus.Add(transform.GetChild(2));
    }

    private void Update()
    {
        ActiveMusicSource();
        ActiveMusicMenu();
    }

    public void SetPlusMusic(int genre)
    {
        music.clip = musics[genre].track[Random.Range(0, 4)];
        music.Play();

    }

    private void ActiveMusicSource()
    {
        if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            music.gameObject.SetActive(false);
        }
        else
        {
            music.gameObject.SetActive(true);
        }
    }

    private void ActiveMusicMenu()
    {
        compliteMenu = GameObject.FindGameObjectWithTag("CompliteMenu");

        if (!SceneManager.GetActiveScene().name.Equals("MainMenu") && LevelStats.GetCoinsFromLevel(2) != 0 && Input.GetKeyDown(KeyCode.Tab) && isMenusActive() == false && compliteMenu == null)
        {
            musicMenu.SetActive(!musicMenu.activeSelf);
            if (musicMenu.activeSelf)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    private bool isMenusActive()
    {
        bool ActiveMenu = false;
        foreach (Transform menu in menus)
        {
            ActiveMenu = menu.gameObject.activeSelf;
            if(ActiveMenu == true)
            {
                break;
            }
        }
        return ActiveMenu;
    }
}

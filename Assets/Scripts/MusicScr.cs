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
    [SerializeField] private List<AudioClip> levelMuscis;
    [SerializeField] private GameObject musicController;
    private int musicGenre;
    private int trackNumb;
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
        musicController.SetActive(true);
        musicGenre = genre;
        trackNumb = Random.Range(0, 4);
        music.clip = musics[musicGenre].track[trackNumb];
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
            if (ActiveMenu == true)
            {
                break;
            }
        }
        return ActiveMenu;
    }

    public void NextButton()
    {
        trackNumb++;
        if (trackNumb >= musics[musicGenre].track.Length)
        {
            trackNumb = 0;
        }
        music.clip = musics[musicGenre].track[trackNumb];
        music.Play();
    }

    public void PreviousButton()
    {
        trackNumb--;
        if (trackNumb < 0)
        {
            trackNumb = musics[musicGenre].track.Length - 1;
        }
        music.clip = musics[musicGenre].track[trackNumb];
        music.Play();
    }

    public void ResetButton()
    {
        music.clip = levelMuscis[SceneManager.GetActiveScene().buildIndex - 1];
        music.Play();
        musicController.SetActive(false);
    }
}

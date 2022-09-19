using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using One;

public class MusicScr : MonoBehaviour
{
    [SerializeField] private List<Track> musics = new List<Track>(4);
    [SerializeField] private GameObject musicMenu;
    private void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("MainMenu") && LevelStats.GetCoinsFromLevel(2) != 0 && Time.timeScale != 0 && Input.GetKeyDown(KeyCode.Tab))
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
}

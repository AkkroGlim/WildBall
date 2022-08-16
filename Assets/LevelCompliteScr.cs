using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompliteScr : MonoBehaviour
{
    [SerializeField] private GameObject compliteMenu;
    [SerializeField] private Text coinCountText;
    private int timeCount; // пофиксь баг с меню и рестартом
    private int tryCount;
    private int coinCount;

    public void Awake()
    {
        timeCount = 0;
        tryCount = 0;
        coinCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
            compliteMenu.SetActive(true);
            coinCountText.text = coinCount + " / 4";
        }

    }

    public void takeCoin()
    {
        coinCount++;
    }

    public void restart()
    {
        
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}



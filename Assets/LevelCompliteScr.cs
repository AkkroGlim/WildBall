using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompliteScr : MonoBehaviour
{
    [SerializeField] private GameObject compliteMenu;
    [SerializeField] private Text coinCountText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text tryCountText;
    [SerializeField] private DeathScr deathscr;
    private float timeCount;
    private int tryCount;
    private int coinCount;

    public void Update()
    {
        if (deathscr.Restart())
        {
            coinCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
            tryCount = deathscr.GetTry();
            timeCount = deathscr.GetTime();
            compliteMenu.SetActive(true);
            coinCountText.text = coinCount + " / 4";
            timerText.text = timeCount.ToString();
            tryCountText.text = tryCount.ToString();
        }

    }

    public void takeCoin()
    {
        coinCount++;
    }

    public void NullCoin()
    {
        coinCount = 0;
    }
    public void restart()
    {

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        deathscr.NullDeathCount();
        coinCount = 0;
        timeCount = 0;
        tryCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        Time.timeScale = 1;
        deathscr.NullDeathCount();
        coinCount = 0;
        timeCount = 0;
        tryCount = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void NextScene()
    {
        deathscr.NullDeathCount();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using One;


public class LevelCompliteScr : MonoBehaviour
{
    [SerializeField] private GameObject compliteMenu;
    [SerializeField] private Text coinCountText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text tryCountText;
    [SerializeField] private DeathScr deathscr;
    [SerializeField] private GameObject finalCoin;
    [SerializeField] private Button nextButton;
    private float timeCount;
    private int tryCount;
    private int coinCount;
    private bool finalFlag;


    public void Update()
    {
        if (LevelStats.GetCoinCount() >= NeedLevelValue.GetLevelPriceForLevels())
        {
            nextButton.interactable = true;
            
        }
        else
        {
            nextButton.interactable = false;
        }

        if (deathscr.Restart())
        {
            coinCount = 0;
        }

        if (finalCoin == null && !finalFlag)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
            tryCount = deathscr.GetTry();
            timeCount = deathscr.GetTime();
            LevelStats.increase(coinCount);
            compliteMenu.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex != 1)
            {
                coinCountText.text = coinCount + " / 4";
            }
            else
            {
                coinCountText.text = coinCount + " / 1";
            }
            
            timerText.text = timeCount.ToString();
            tryCountText.text = tryCount.ToString();
            finalFlag = true;
        }
    }

    public void takeCoin()
    {
        coinCount++;
        Debug.Log("Монетка");
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        deathscr.NullDeathCount();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    
}



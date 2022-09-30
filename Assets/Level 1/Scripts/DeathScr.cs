using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScr : MonoBehaviour
{
    private GameObject mainMenu;
    private Transform restartMenu;
    private bool isRPress;
    private Transform escMenu;
    private Transform settingsMenu;
    private static int deathCount = 1;
    private float timeCount;
    private bool isRestartActive;
    private Vector3 startPlayerTransform;
    private Transform player;
    private Transform playerParent;
    private void Awake()
    {
        mainMenu = GameObject.Find("GameMenu");
        restartMenu = mainMenu.transform.GetChild(2);
        escMenu = mainMenu.transform.GetChild(0);
        settingsMenu = mainMenu.transform.GetChild(1);
        
    }

    private void Start()
    {
        startPlayerTransform = GameObject.Find("PlayerBody").transform.localPosition;
        player = GameObject.Find("PlayerBody").GetComponent<Transform>();
        playerParent = GameObject.Find("Player").GetComponent<Transform>();
        TabletActivate();
    }

    private void Update()
    {
        timeCount += Time.deltaTime;
        
        if (restartMenu.gameObject.activeSelf && !escMenu.gameObject.activeSelf && !settingsMenu.gameObject.activeSelf)
        {
            isRPress = Input.GetKeyDown(KeyCode.R);
        }      
    }
    private void OnTriggerStay(Collider other)
    {
        if (!isRestartActive && other.gameObject.tag.Equals("Player"))
        {
            isRestartActive = true;
            Time.timeScale = 0;
            restartMenu.gameObject.SetActive(true);
            StartCoroutine("RestartScene");
        }

    }
    IEnumerator RestartScene()
    {
        yield return new WaitWhile(() => isRPress != true);
        if(SceneManager.GetActiveScene().name.Equals("Level 4"))
        {
            playerParent.SetParent(null);
            player.localPosition = startPlayerTransform;
            deathCount++;
            isRPress = false;
            Time.timeScale = 1;
            restartMenu.gameObject.SetActive(false);
            isRestartActive = false;
        }
        else
        {
            Debug.Log(deathCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            deathCount++;
            Time.timeScale = 1;
            restartMenu.gameObject.SetActive(false);
        }
        
    }

    public int GetTry()
    {
        return deathCount;
    }

    public float GetTime()
    {
        return (float)Math.Round(timeCount, 2);
    }

    public bool Restart()
    {
        return restartMenu.gameObject.activeSelf;
    }

    public void NullDeathCount()
    {
        deathCount = 1;
    }

    private void TabletActivate()
    {
        if(deathCount > 5)
        {
            GameObject tablet = GameObject.FindGameObjectWithTag("Tablet");
            tablet.transform.GetChild(0).gameObject.SetActive(true);
            tablet.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}

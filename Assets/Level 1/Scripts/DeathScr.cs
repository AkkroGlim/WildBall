using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScr : MonoBehaviour
{
    private GameObject mainMenu;
    private Transform restartMenu;
    private bool isRPress;
    private void Awake()
    {
        mainMenu = GameObject.Find("GameMenu");
        restartMenu = mainMenu.transform.GetChild(3);
    }

    private void Update()
    {
        if(restartMenu.gameObject.activeSelf)
        isRPress = Input.GetKeyDown(KeyCode.R);
    }
    private void OnTriggerStay(Collider other)
    {
        Time.timeScale = 0;
        restartMenu.gameObject.SetActive(true);
        StartCoroutine("RestartScene");
    }
    IEnumerator RestartScene()
    {
        yield return  new WaitWhile(() => isRPress != true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        restartMenu.gameObject.SetActive(false);
    }
}

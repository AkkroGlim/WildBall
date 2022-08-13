using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EscMenu : MonoBehaviour
{

    private bool escMenuFlag;
    private GameObject menu;

    [SerializeField] GameObject escMenu;
    
    
  


    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("MainMenu") && Input.GetKeyDown(KeyCode.Escape))
        {
            menu = GameObject.FindGameObjectWithTag("Menu");
            escMenuFlag = !escMenuFlag;
            if (menu != null)
            {
                menu.SetActive(escMenuFlag);
            }

            if (escMenuFlag)
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
            escMenu.SetActive(escMenuFlag);
        }
        
    }

    public void FlagChanger()
    {
        escMenuFlag = !escMenuFlag;
        Time.timeScale = 1;
    }
}

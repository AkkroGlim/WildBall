using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using One;


public class EscMenu : MonoBehaviour
{

    private bool escMenuFlag;
    private GameObject menu;
    private GameObject compliteMenu;
    [SerializeField] GameObject escMenu;
    [SerializeField] GameObject deathMenu;





    void Update()
    {
        compliteMenu = GameObject.FindGameObjectWithTag("CompliteMenu");
        
        if (!SceneManager.GetActiveScene().name.Equals("MainMenu") && Input.GetKeyDown(KeyCode.Escape) && compliteMenu == null)
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
                if (!deathMenu.activeSelf)
                {
                    Time.timeScale = 1;
                    
                }
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

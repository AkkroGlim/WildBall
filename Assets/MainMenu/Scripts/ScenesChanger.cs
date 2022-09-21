using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChanger : MonoBehaviour
{
    private DeathScr deathScr;
    public void SceneChanger(int i)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(i);
        if(Cursor.visible == true && i != 0)
        {
            Debug.Log("выкл");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if(i == 0)
        {
            Debug.Log("вкл");
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            deathScr = GameObject.FindGameObjectWithTag("DeathTrigger").GetComponent<DeathScr>();
            deathScr.NullDeathCount();
        }
        
        
    }
}

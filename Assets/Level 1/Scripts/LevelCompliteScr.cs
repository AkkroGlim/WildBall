using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompliteScr : MonoBehaviour
{
    [SerializeField] private GameObject compliteMenu;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Time.timeScale = 0;
            compliteMenu.SetActive(true);
        }
    }

    public void restart()
    {

    }
}

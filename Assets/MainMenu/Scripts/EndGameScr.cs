using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using One;

public class EndGameScr : MonoBehaviour
{
    [SerializeField] private GameObject endMenu;
    void Start()
    {
        if(LevelStats.GetCoinsFromLevel(4) != 0)
        {
            endMenu.SetActive(true);
        }
    }

    
    
}

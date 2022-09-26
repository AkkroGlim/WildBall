using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirageLogic : MonoBehaviour
{
    [SerializeField] private GameObject tombsParent;
    [SerializeField] List<GameObject> listOfTombs;
    private int tombNumber;
    private bool isIllusion;
    private void Start()
    {
        for(int i = 0; i < listOfTombs.Count; i++)
        {
            if (gameObject.name.Equals(listOfTombs[i].name))
            {
                tombNumber = i;
                break;
            }
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private GameObject[] duplicates;
    private void Awake()
    {
        duplicates = GameObject.FindGameObjectsWithTag("DontDestroy");
        if (duplicates.Length > 1)
        {
            gameObject.tag = "Destroy";
            Destroy(GameObject.FindGameObjectWithTag("Destroy"));
        }else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionDetectorScr : MonoBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            MirageLogic tomb = transform.GetComponentInParent<MirageLogic>();
            tomb.Illusion();
        }
    }

}

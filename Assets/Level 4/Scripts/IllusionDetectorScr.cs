using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionDetectorScr : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("���������� �����");
            MirageLogic tomb = collision.transform.GetComponent<MirageLogic>();
            tomb.Illusion();
            
        }
    }

}

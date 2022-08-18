using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            player.transform.SetParent(other.gameObject.transform);
            Debug.Log("�����������");
        }
    }

    void OnTriggerExit(Collider other)
    {
        player.transform.SetParent(null);
        if (other.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("����������");
            player.transform.SetParent(null);
        }
    }
}

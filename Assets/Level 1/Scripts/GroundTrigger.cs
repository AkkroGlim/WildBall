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
        }
    }

    void OnTriggerExit(Collider other)
    {
        player.transform.SetParent(null);
    }
}

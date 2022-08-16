using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinCollision : MonoBehaviour
{
    [SerializeField] private Animator coinAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            coinAnimator.SetBool("isTouched", true);
            StartCoroutine("destroyer");
        }
    }

    IEnumerator destroyer()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}

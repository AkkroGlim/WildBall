using System.Collections;
using UnityEngine;



public class CoinCollision : MonoBehaviour
{
    [SerializeField] private Animator coinAnimator;
    [SerializeField] private LevelCompliteScr levelComplite;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            coinAnimator.SetBool("isTouched", true);
            levelComplite.takeCoin();
            StartCoroutine("destroyer");
        }
    }

    IEnumerator destroyer()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}

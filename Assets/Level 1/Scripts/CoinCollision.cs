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
            StartCoroutine("destroyer");
        }
    }

    IEnumerator destroyer()
    {
        yield return new WaitForSeconds(1); //изменено с 3
        levelComplite.takeCoin();
        Destroy(this.gameObject);       
    }
}

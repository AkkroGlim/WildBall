using System.Collections;
using UnityEngine;



public class CoinCollision : MonoBehaviour
{
    [SerializeField] private Animator coinAnimator;
    [SerializeField] private LevelCompliteScr levelComplite;
    private AudioSource coinAudio;

    private void Start()
    {
        coinAudio = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            coinAnimator.SetBool("isTouched", true);
            coinAudio.Play();
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

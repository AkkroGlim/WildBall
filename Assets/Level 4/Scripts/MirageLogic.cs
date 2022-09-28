using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using illusion;

public class MirageLogic : MonoBehaviour
{
    [SerializeField] private GameObject tombsParent;
    private MeshRenderer tombRend;
    private MeshCollider tombColl;
    private bool isIllusion;
    private void Start()
    {
        int cycle—ount = 0;
        foreach (Transform child in tombsParent.transform)
        {
            if (gameObject.name.Equals(child.name))
            {
                isIllusion = MirageRandomScr.GetRandomList(cycle—ount);
                break;
            }
            cycle—ount++;
        }

        tombRend = transform.GetComponent<MeshRenderer>();
        tombColl = transform.GetComponent<MeshCollider>();
    }

    public void Illusion()
    {
        if (!isIllusion)
        {
            tombColl.enabled = false;
        }
        else
        {
            Color col = tombRend.material.color;
            col.a = 255;
            tombRend.material.SetColor("_Color", col);           
        }
    }

}

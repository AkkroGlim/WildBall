
using System.Collections.Generic;
using UnityEngine;

public class MirageRandomScr : MonoBehaviour
{
    private List<bool[]> tombs = new List<bool[]> { new bool[3], new bool[3], new bool[3], new bool[3], new bool[3] };
    private int previousTomb = 1;

    private void Awake()
    {
        foreach (bool[] line in tombs)
        {
            switch (previousTomb)
            {
                case 0:
                    previousTomb = Random.Range(0, 2);
                    line[previousTomb] = true;
                    break;
                case 1:
                    previousTomb = Random.Range(0, 3);
                    line[previousTomb] = true;
                    break;
                case 2:
                    previousTomb = Random.Range(1, 3);
                    line[previousTomb] = true;
                    break;
            }
        }
    }

    public List<bool[]> GetRandomList()
    {
        return tombs;
    }
}

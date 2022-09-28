
using System.Collections.Generic;
using UnityEngine;

namespace illusion
{
    public class MirageRandomScr : MonoBehaviour
    {
        private static List<bool[]> tombs = new List<bool[]> { new bool[3], new bool[3], new bool[3], new bool[3], new bool[3] };
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

        public static bool GetRandomList(int number)
        {
            int line = number / tombs[0].Length;
            int numb = number % tombs[0].Length;
            bool active = tombs[line][numb];
            tombs[line][numb] = false;
            return active;           
        }
    }
}


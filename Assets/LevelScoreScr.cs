using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace One
{
    public static class LevelStats
    {
        private static int[] coinCount = new int[6];

        public static void increase(int coinValue)
        {
            if (coinCount[SceneManager.GetActiveScene().buildIndex - 1] < coinValue)
            {
                coinCount[SceneManager.GetActiveScene().buildIndex - 1] = coinValue;
            }

        }
        //SceneManager.GetActiveScene().buildIndex;
        public static int GetCoinCount()
        {
            int i = 0;
            foreach (int j in coinCount)
            {
                i += j;
            }
            return i;
        }
    }

    public static class NeedLevelValue
    {
        private static int[] levelPrice = new int[6] { 0, 3, 8, 12, 15, 21 };


        public static int GetLevelPrice()
        {
            return levelPrice[SceneManager.GetActiveScene().buildIndex - 1];
        }
    }
}

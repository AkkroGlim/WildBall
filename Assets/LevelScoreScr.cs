using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Save;

namespace One
{
    public static class LevelStats
    {
        private static int[] coinCount = new int[5];

        public static void increase(int coinValue)
        {
            if (coinCount[SceneManager.GetActiveScene().buildIndex - 1] < coinValue)
            {
                coinCount[SceneManager.GetActiveScene().buildIndex - 1] = coinValue;
            }

            SaveScr.CoinsValueToSave(coinCount);
        }

        public static int GetCoinCount()
        {
            int coinSum = 0;
            foreach (int j in coinCount)
            {
                coinSum += j;
            }
            return coinSum;
        }

        public static void LoadCoinsValue(int[] coinsValue)
        {
            coinCount = coinsValue;
        }

        public static int GetCoinsFromLevel(int levelNumb)
        {
            return coinCount[levelNumb];
        }
    }


    public static class NeedLevelValue
    {
        private static int[] levelPrice = new int[5] { 0, 1, 3, 7, 12};


        public static int GetLevelPriceForLevels()
        {
            return levelPrice[SceneManager.GetActiveScene().buildIndex];
        }

        public static int GetLevelPriceForMaimMenu(int arrayNumb)
        {
            return levelPrice[arrayNumb];
        }
    }

    
}

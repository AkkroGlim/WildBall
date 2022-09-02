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
        
        public static int GetCoinCount()
        {
            int coinSum = 0;
            foreach (int j in coinCount)
            {
                coinSum += j;
            }
            return coinSum;
        }

        
    }


    public static class NeedLevelValue
    {
        private static int[] levelPrice = new int[7] { 0, 1, 3, 6, 11, 16 , 0};

        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using One;

public class ButtonUnlock : MonoBehaviour
{
    [SerializeField] private Button[] levelsButton;

    private void OnEnable()
    {
        for (int i = 0; i < levelsButton.Length; i++)
        {
            if (LevelStats.GetCoinCount() >= NeedLevelValue.GetLevelPriceForMaimMenu(i))
            {
                levelsButton[i].interactable = true;
            }
            else
            {
                levelsButton[i].interactable = false;
            }
        }
    }
}

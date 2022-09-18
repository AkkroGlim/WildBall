using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    [System.Serializable]public class Track
    {
        [SerializeField] public Image[] trackTitle = new Image[4];
        [SerializeField] public AudioClip track;
        private bool avaliable = false;
    }



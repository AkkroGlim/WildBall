using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



[Serializable]public class Track
    {
        public Sprite[] trackTitle;
        public AudioClip[] track;
        private bool[] avaliable = new bool[4];
    }



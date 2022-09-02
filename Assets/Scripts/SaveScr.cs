using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using One;

namespace Save
{
    public class SaveScr
    {
        int[] coinsToSave = new int[6];
        int masterSliderValueToSave;
        int musicSliderValueToSave;
        int soundSliderValueToSave;
        private FileStream file;
        private BinaryFormatter bf;
        private static bool isSavesLoaded = false;
        public void Load()
        {
            if (!File.Exists(Application.persistentDataPath + "/Data.dat") && !isSavesLoaded)
            {
                file = File.Create(Application.persistentDataPath + "/Data.dat");
                isSavesLoaded = true;
            }
            else if (File.Exists(Application.persistentDataPath + "/Data.dat") && !isSavesLoaded)
            {
                isSavesLoaded = true;
                file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
                SaveData data = (SaveData)bf.Deserialize(file);
                ArrayList savesArray = data.GetSaves();
                coinsToSave = (int[])savesArray[0];
                masterSliderValueToSave = (int)savesArray[1];
                musicSliderValueToSave = (int)savesArray[2];
                soundSliderValueToSave = (int)savesArray[3];
            }
        }
        void SaveGame()
        {
            SaveData data = new SaveData(coinsToSave, masterSliderValueToSave, musicSliderValueToSave, soundSliderValueToSave);
            bf.Serialize(file, data);
            file.Close();

        }


    }

}




[Serializable]
class SaveData
{
    private int[] savedCoins = new int[6];
    private int savedMasterSliderValue;
    private int savedMusicSliderValue;
    private int savedSoundSliderValue;

    public SaveData(int[] savedCoins, int savedMasterSliderValue, int savedMusicSliderValue, int savedSoundSliderValue)
    {
        this.savedCoins = savedCoins;
        this.savedMasterSliderValue = savedMasterSliderValue;
        this.savedMusicSliderValue = savedMusicSliderValue;
        this.savedSoundSliderValue = savedSoundSliderValue;
    }

    public ArrayList GetSaves()
    {
        ArrayList saves = new ArrayList();
        saves.Add(savedCoins);
        saves.Add(savedMasterSliderValue);
        saves.Add(savedMusicSliderValue);
        saves.Add(savedSoundSliderValue);
        return saves;
    }
}
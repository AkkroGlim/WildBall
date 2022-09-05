using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using One;

namespace Save
{
    public static class SaveScr
    {
        private static int[] coinsToSave = new int[6];
        private static float masterSliderValueToSave;
        private static float musicSliderValueToSave;
        private static float soundSliderValueToSave;
        private static FileStream file;
        private static BinaryFormatter bf = new BinaryFormatter();
        
        
        public static void SaveGame()
        {
            SaveData data = new SaveData(coinsToSave, masterSliderValueToSave, musicSliderValueToSave, soundSliderValueToSave);
            file.Close();
            File.Delete(Application.dataPath + "/Data.dat");
            file = File.Create(Application.dataPath + "/Data.dat");
            ArrayList saveArray = new ArrayList() { coinsToSave, masterSliderValueToSave, musicSliderValueToSave, soundSliderValueToSave };
            data.SetSaves(saveArray);
            bf.Serialize(file, data);


        }

        public static void VolumeValueToSave(float masterVolume, float musicVolume, float soundVolume)
        {
            masterSliderValueToSave = masterVolume;
            musicSliderValueToSave = musicVolume;
            soundSliderValueToSave = soundVolume;
            SaveGame();
            
        }

        public static void CoinsValueToSave(int[] coins)
        {
            coinsToSave = coins;
            SaveGame();
        }

        public static float[] VolumeValueForLoad()
        {
            return new float[] { masterSliderValueToSave, musicSliderValueToSave, soundSliderValueToSave };
        }

        public static void CreateSave()
        {
            file = File.Create(Application.dataPath + "/Data.dat");
        }

        public static void LoadSave()
        {
            file = File.Open(Application.dataPath + "/Data.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            ArrayList loadedArray = data.GetSaves();
            coinsToSave = (int[])loadedArray[0];
            masterSliderValueToSave = (float)loadedArray[1];
            musicSliderValueToSave = (float)loadedArray[2];
            soundSliderValueToSave = (float)loadedArray[3];
            LevelStats.LoadCoinsValue(coinsToSave);

        }
    }

}




[Serializable]
class SaveData
{
    private int[] savedCoins = new int[6];
    private float savedMasterSliderValue;
    private float savedMusicSliderValue;
    private float savedSoundSliderValue;

    public SaveData(int[] savedCoins, float savedMasterSliderValue, float savedMusicSliderValue, float savedSoundSliderValue)
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

    public void SetSaves(ArrayList saves)
    {
        savedCoins = (int[])saves[0];
        savedMasterSliderValue = (float)saves[1];
        savedMusicSliderValue = (float)saves[2];
        savedSoundSliderValue = (float)saves[3];
    }
}
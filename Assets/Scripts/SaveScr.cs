using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveScr : MonoBehaviour
{
    int[] coinsToSave = new int[6];
    int masterSliderValueToSave;
    int musicSliderValueToSave;
    int soundSliderValueToSave;

    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Data.dat");
        SaveData data = new SaveData(coinsToSave, masterSliderValueToSave, musicSliderValueToSave, soundSliderValueToSave);
        bf.Serialize(file, data);
        file.Close();
    }

    void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
        SaveData data = (SaveData)bf.Deserialize(file);
        file.Close();
        ArrayList saves = data.GetSaves();
        coinsToSave = (int[])saves[0];
        masterSliderValueToSave = (int)saves[1];
        musicSliderValueToSave = (int)saves[2];
        soundSliderValueToSave = (int)saves[3];
        //file.Flush(); очистить файл
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
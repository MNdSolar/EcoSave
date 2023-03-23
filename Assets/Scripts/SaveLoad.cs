using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
public class SaveLoad : MonoBehaviour
{
    [SerializeField] private ReverseTimer _timer;

    [Serializable]
    public class SaveData
    {
        public int MoneySaved;
        public int GreenSaved;
        public int BlockSaved;
        public int ElectroSaved;

        public int savedBack;
        public int savedUnlkButton;

        public int SwitchImage1Saved;
        public int SwitchImage2Saved;
        public int SwitchImage3Saved;
        public int SwitchImage4Saved;
        public int SwtichImage5Saved;

        public float TimerSaved;
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.BlockSaved = Storage.ScoreBlock;
        data.ElectroSaved = Storage.ScoreElectro;
        data.MoneySaved = Storage.ScoreMoney;
        data.GreenSaved = Storage.ScoreGreen;
        data.savedBack = Storage.SaveBack;
        data.savedUnlkButton = Storage.SaveUnlkButton;
        data.SwitchImage1Saved = Storage.SwitchImage1;
        data.SwitchImage2Saved = Storage.SwitchImage2;
        data.SwitchImage3Saved = Storage.SwitchImage3;
        data.SwitchImage4Saved = Storage.SwitchImage4;
        data.SwtichImage5Saved = Storage.SwitchImage5;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
            File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            Storage.ScoreBlock = data.BlockSaved;
            Storage.ScoreGreen = data.GreenSaved;
            Storage.ScoreElectro = data.ElectroSaved;
            Storage.ScoreMoney = data.MoneySaved;
            Storage.SaveBack = data.savedBack;
            Storage.SaveUnlkButton = data.savedUnlkButton;
            Storage.SwitchImage1 = data.SwitchImage1Saved;
            Storage.SwitchImage2 = data.SwitchImage2Saved;
            Storage.SwitchImage3 = data.SwitchImage3Saved;
            Storage.SwitchImage4 = data.SwitchImage4Saved;
            Storage.SwitchImage5 = data.SwtichImage5Saved;
            Debug.Log("Game data loaded!");

        }
        else
            Debug.LogError("There is no save data!");
    }
    public void ResetGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath + "/MySaveData.dat");
            Storage.ScoreBlock = 0;
            Storage.ScoreGreen = 0;
            Storage.ScoreElectro = 0;
            Storage.ScoreMoney = 0;
            Storage.SaveBack = 0;
            Storage.SwitchImage1 = 0;
            Storage.SwitchImage2 = 0;
            Storage.SwitchImage3 = 0;
            Storage.SwitchImage4 = 0;
            Storage.SwitchImage5 = 0;
            Storage.SaveUnlkButton = 0;
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }
    public void SaveTime()
    {
        PlayerPrefs.SetFloat("Time",_timer.Timer);
        PlayerPrefs.Save();
        Debug.Log("TimeSaved");
    }

    public void LoadTime()
    {
        if (PlayerPrefs.HasKey("Time"))
        {
            _timer.Timer = PlayerPrefs.GetFloat("Time");
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
    public void ResetTime()
    {
        PlayerPrefs.DeleteAll();
        _timer.Timer = 0;
        Debug.Log("TimeData reset complete");
    }

}


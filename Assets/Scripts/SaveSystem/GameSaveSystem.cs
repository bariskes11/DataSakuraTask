using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveSystem : SingletonCreator<GameSaveSystem>
{
    [SerializeField] private GameData gameData;
    [SerializeField] private float InitialMoney = 100;
    [SerializeField] private int startingWaveIndex = 1;
    #region Fields
    private const string FileName = "minibyte___";
    public GameData GameData { get => gameData; }
    #endregion
    #region Private Methods
    private void SaveGameData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = null;
        if (!File.Exists(Application.persistentDataPath + "/" + FileName))
        {
            file = File.Create(Application.persistentDataPath + "/" + FileName);
        }
        else
        {
            file = File.OpenWrite(Application.persistentDataPath + "/" + FileName);
        }
        bf.Serialize(file, gameData);
        file.Close();
    }
    public void IncreaseCircuitProgress(int finishPosition, int starCount, int moneyToAdd)
    {

    }

    private void InitialGameData()
    {
        gameData = new GameData
        {
            
        };
    }
    

    #endregion

    #region Context Menu  Methods
    [ContextMenu("Reset All GameData")]
    public void ResetAllGameData()
    {
        InitialGameData();
        // delete previous file
        string path = Application.persistentDataPath + "/" + FileName;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        SaveGameData();
        Load();
    }

    /// <summary>
    /// This method is for testing
    /// </summary>
    [ContextMenu("Load All GameData")]
    public void LoadAllGameData()
    {
        this.Load();
    }
    #endregion


    #region Unity Methods
    public void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

    }
    #endregion
    #region Public Methods

   


  


    public void SaveMusicStatus(bool musicStatus)
    {
        Load();

        try
        {
            SaveGameData();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }
 



 


   
  

    public void ResetAllValues()
    {
        try
        {

            gameData = new GameData();
            SaveGameData();
        }
        catch (Exception ex)
        {
            print(ex.ToString());
        }
    }
    private GameData Load()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Application.persistentDataPath + "/" + FileName))
            {
                file = File.Open(Application.persistentDataPath + "/" + FileName, FileMode.Open);
                gameData = (GameData)bf.Deserialize(file);
                file.Close();
                return gameData;
            }
            else // First Load
            {
                file = File.Create(Application.persistentDataPath + "/" + FileName);
                //if(!istest)
                InitialGameData();
                bf.Serialize(file, gameData);
                file.Close();
                return gameData;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return null;
        }
        finally
        {
            if (file != null)
                file.Close();

        }
    }
    #endregion

}

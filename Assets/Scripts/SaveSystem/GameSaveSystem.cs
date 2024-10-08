using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveSystem : SingletonCreator<GameSaveSystem>
{
    [SerializeField] private GameData gameData;
    [SerializeField] private float initialScore = 0;

    #region Fields

    private const string FileName = "gs_";

    public GameData GameData
    {
        get => gameData;
    }

    #endregion

    #region Private Methods

    public void SaveGameData(GameData gameData)
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


    private void InitialGameData()
    {
        gameData = new GameData
        {
            BestScore = this.initialScore
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

        SaveGameData( gameData = new GameData
        {
            BestScore = this.initialScore
        });
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

    
}
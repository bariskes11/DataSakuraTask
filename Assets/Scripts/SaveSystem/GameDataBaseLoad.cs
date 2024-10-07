using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataBaseLoad : MonoBehaviour
{

    protected GameData gameData;
    protected GameSaveSystem gameSaveSystem;

    protected virtual void LoadGameData()
    {
        gameSaveSystem = FindObjectOfType<GameSaveSystem>(true);
        gameSaveSystem.LoadAllGameData();
        gameData = gameSaveSystem.GameData;


    }
}

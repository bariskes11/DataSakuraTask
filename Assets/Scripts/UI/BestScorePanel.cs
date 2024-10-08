using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestScorePanel : Panel
{
    [SerializeField] private TextMeshProUGUI txthighScore;
    [SerializeField] private InGamePanel inGamePanel;
    [SerializeField] private Button btnBack;
    [SerializeField] private BeginGamePanel beginPanel;
    private GameData gameData;

    private void Start()
    {
        EventManager.OnEnemyKilled.AddListener(CheckAndUpdateScore);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(ReturnToBeginGame);
        LoadData();
    }

    private void ReturnToBeginGame()
    {
        this.beginPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void LoadLastHighScore()
    {
        LoadData();
    }

    private void LoadData()
    {
        GameSaveSystem.Instance.LoadAllGameData();
        gameData = GameSaveSystem.Instance.GameData;
        txthighScore.text = gameData.BestScore.ToString();
    }

    private void CheckAndUpdateScore(IEnemy arg0)
    {
         if (inGamePanel.CurrentScore > gameData.BestScore)
        {
            GameSaveSystem.Instance.SaveGameData(new GameData { BestScore = inGamePanel.CurrentScore });
        }
    }

    private void OnDestroy()
    {
        EventManager.OnEnemyKilled.RemoveAllListeners();
    }
}
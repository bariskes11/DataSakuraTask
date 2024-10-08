using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BeginGamePanel : Panel
{
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnhighScore;
    [SerializeField] private BestScorePanel highScorePanel;
    [SerializeField] private float startTimeOut = 1F;
    private bool isGameRunning = false;

    private void Awake()
    {
        isGameRunning = false;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        btnStart.onClick.RemoveAllListeners();
        btnhighScore.onClick.RemoveAllListeners();
        btnStart.onClick.AddListener(StartGame);
        btnhighScore.onClick.AddListener(HighScorePanel);
    }

    private void HighScorePanel()
    {
        if(isGameRunning) return; //edge case
        highScorePanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }



    private void StartGame()
    {
        this.isGameRunning = true;
        // Calculate the off-screen position (below the screen in this case)
        Vector2 offScreenPos = new Vector2(this.panelRecTransform.anchoredPosition.x, -Screen.height);

        // Move the panel out of the screen over 1 second
        this.panelRecTransform.DOAnchorPos(offScreenPos, startTimeOut).SetEase(Ease.InCubic).OnComplete(() =>
        {
            EventManager.OnGameStarted?.Invoke();
        });
        highScorePanel.gameObject.SetActive(false);
    }
}
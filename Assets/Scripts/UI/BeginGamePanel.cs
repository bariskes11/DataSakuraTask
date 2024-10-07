using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BeginGamePanel : Panel
{
    [SerializeField] private Button btnStart;
    [SerializeField] private float startTimeOut = 1F;
    protected override void OnEnable()
    {
        base.OnEnable();
        btnStart.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        // Calculate the off-screen position (below the screen in this case)
        Vector2 offScreenPos = new Vector2(this.panelRecTransform.anchoredPosition.x, -Screen.height);

        // Move the panel out of the screen over 1 second
        this.panelRecTransform.DOAnchorPos(offScreenPos, startTimeOut).SetEase(Ease.InCubic).OnComplete(() =>
        {
            EventManager.OnGameStarted?.Invoke();
        });
    }
}
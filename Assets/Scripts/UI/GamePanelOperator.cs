
using System;
using DG.Tweening;
using UnityEngine;

public class GamePanelOperator : MonoBehaviour
{
    [SerializeField] private BeginGamePanel beginGamePanel;
    [SerializeField] private InGamePanel inGamePanel;
    [SerializeField] private PlayerHit playerHit;
    private void Start()
    {
        EventManager.OnGameStarted.AddListener(GameStarted);
        beginGamePanel.gameObject.SetActive(true); 
        inGamePanel.gameObject.SetActive(false);
        playerHit.gameObject.SetActive(false);
        var recBeginGame= beginGamePanel.GetComponent<RectTransform>();
        recBeginGame.DOAnchorPos(Vector2.zero, 1F).SetEase(Ease.InOutCubic);
    }

    private void GameStarted()
    {
        inGamePanel.gameObject.SetActive(true);
        playerHit.gameObject.SetActive(false);
    }
}

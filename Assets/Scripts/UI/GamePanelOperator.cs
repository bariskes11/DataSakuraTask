
using System;
using DG.Tweening;
using UnityEngine;

public class GamePanelOperator : MonoBehaviour
{
    [SerializeField] private BeginGamePanel beginGamePanel;
    [SerializeField] private InGamePanel inGamePanel;
    [SerializeField] private PlayerHit playerHit;
    [SerializeField] private GameOverPanel gameOverPanel;
    [SerializeField] private BestScorePanel bestScorePanel;

    private void Awake()
    {
        EventManager.OnGameStarted.AddListener(GameStarted);
        EventManager.OnGameOver.AddListener(SetGameOverPanel);
    }

    private void OnDestroy()
    {
        EventManager.OnGameStarted.RemoveAllListeners();
        EventManager.OnGameOver.RemoveAllListeners();
    }

    private void Start()
    {
        
        beginGamePanel.gameObject.SetActive(true); 
        inGamePanel.gameObject.SetActive(false);
        playerHit.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        bestScorePanel.gameObject.SetActive(false);
            
        var recBeginGame= beginGamePanel.GetComponent<RectTransform>();
        recBeginGame.DOAnchorPos(Vector2.zero, 1F).SetEase(Ease.InOutCubic);
    }

    private void SetGameOverPanel()
    {
        beginGamePanel.gameObject.SetActive(false); 
        inGamePanel.gameObject.SetActive(false);
        bestScorePanel.gameObject.SetActive(false);
        gameOverPanel.InitGameOverPanel(inGamePanel.CurrentScore);
        
    }

    private void GameStarted()
    {
        inGamePanel.gameObject.SetActive(true);
        playerHit.gameObject.SetActive(false);
    }
}

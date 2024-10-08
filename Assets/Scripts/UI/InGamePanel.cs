
using DG.Tweening;

using TMPro;
using UnityEngine;


public class InGamePanel : Panel
{
    [SerializeField] private TextMeshProUGUI txtScore;
    public float CurrentScore { get; private set; }

    private void Awake()
    {
        EventManager.OnEnemyKilled.AddListener(AddScore);
        
        txtScore.text = CurrentScore.ToString();
    }

    private void AddScore(IEnemy enemy)
    {
        CurrentScore += enemy.KillScore;
        txtScore.text = CurrentScore.ToString();
        txtScore.transform.DOScale(1.5F, .3F).OnComplete(() =>
        {
            txtScore.transform.DOScale(1F, .3F);
        });
    }
    private void OnDestroy()
    {
        EventManager.OnEnemyKilled.RemoveAllListeners();
    }
}

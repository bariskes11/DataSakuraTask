using UnityEngine.Events;

public static class EventManager
{
    public static readonly UnityEvent OnGameStarted = new UnityEvent();
    public static readonly KilledEnemy OnEnemyKilled = new KilledEnemy();
    public static readonly UnityEvent OnGameOver = new UnityEvent();

    public class KilledEnemy : UnityEvent<IEnemy>
    {
        
    }

  
    
}

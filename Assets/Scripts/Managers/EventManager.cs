using UnityEngine.Events;

public static class EventManager
{
    public static readonly UnityEvent OnGameStarted = new UnityEvent();
    public static readonly KilledEnemy OnEnemyKilled = new KilledEnemy();

    public class KilledEnemy : UnityEvent<IEnemy>
    {
        
    }
    
}

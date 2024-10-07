using UnityEngine.Events;

public static class EventManager
{
    public static readonly UnityEvent OnStartClickedFromMain = new UnityEvent();
    public static readonly UnityEvent OnFiredSecondaryWeapon= new UnityEvent();
    public static readonly UnityEvent OnFiredHeavyWeapon= new UnityEvent();
}
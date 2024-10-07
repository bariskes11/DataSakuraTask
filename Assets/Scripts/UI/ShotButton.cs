using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShotButton : MonoBehaviour
{
    [SerializeField] private Image shotFillImage;
    [SerializeField] private PlayerProperties playerProperties;
    [SerializeField] private Button btnShot;
    public static Action OnShotClicked;
    public static Action OnShotReady;
    private bool chargeTimerStarted = false;
    private bool isShotReady = false;
    private TimeCounter chargeCounter;

    private void Awake()
    {
        chargeTimerStarted = false;
        EventManager.OnGameStarted.AddListener(StartCharging);
        PlayerController.OnShotBullet += ResetTimers;
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        shotFillImage.fillAmount = 0F;
        
        chargeCounter = new TimeCounter(playerProperties.TimeOutPerShot);
        btnShot.onClick.RemoveAllListeners();
        
    }

    private void OnDestroy()
    {
        PlayerController.OnShotBullet -= ResetTimers;
    }

    private void StartCharging()
    {
        chargeTimerStarted = true;
    }

    private void Update()
    {
        if (!this.chargeTimerStarted)
            return;
        if(isShotReady)
            return;
        if (chargeCounter.IsTickFinished(Time.deltaTime) &&!isShotReady)
        {
            shotFillImage.fillAmount = 1;
            OnShotReady?.Invoke();
            btnShot.onClick.AddListener(ShotPlayerBullet);
            isShotReady = true;
        }
        else if(chargeCounter.GetTimeLeft()>0F)
        {
            shotFillImage.fillAmount = 1F-(chargeCounter.GetTimeLeft()/chargeCounter.TotalTime);

        }
    }

    private void ResetTimers()
    {
        this.isShotReady = false;
        shotFillImage.fillAmount = 0F;
        chargeCounter = new TimeCounter(playerProperties.TimeOutPerShot);
    }

    private void ShotPlayerBullet()
    {
        btnShot.onClick.RemoveAllListeners();
        OnShotClicked?.Invoke();
    }
}
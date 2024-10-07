using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerProperties playerProperties;
    [SerializeField] private Transform shotPosition;
    [SerializeField] private ParticleSystem shotParticle;
    private Animator animator;
    private Rigidbody rigidBody;
    private Vector3 movement;
    private float moveZ;
    private float rotationMove;
    private Joystick joystick;

    public bool IsControlEnabled { get; set; }
    public static Action OnShotBullet;
    private bool isChargeFinished;

    void Start()
    {
        if (playerProperties is null)
        {
#if UNITY_EDITOR
            Debug.LogError("There is no Player Property!!!  system won't work!");
            return;
#endif
        }

        this.joystick = FindObjectOfType<Joystick>();
        this.rigidBody = GetComponent<Rigidbody>();
        this.animator = GetComponent<Animator>();
        EventManager.OnGameStarted.AddListener(EnableControls);
        ShotButton.OnShotClicked += ShotBullet;
        ShotButton.OnShotReady += OnShotReady;
    }


    void Update()
    {
        if (!IsControlEnabled)
            return;


        this.isChargeFinished = true;

        this.moveZ = Input.GetAxis("Vertical");
        this.rotationMove = Input.GetAxis("Horizontal");
        if (joystick is not null)
        {
            this.moveZ += joystick.Direction.y;
            this.rotationMove += joystick.Direction.x;
        }

        movement = transform.forward * moveZ;
        SetAnimations();
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.TestShot();
        }
#endif
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * playerProperties.MovingSpeed * Time.fixedDeltaTime);
        rigidBody.MoveRotation(rigidBody.rotation *
                               Quaternion.Euler(0, (rotationMove * playerProperties.RotateSpeed * Time.fixedDeltaTime),
                                   0));
    }

    private void OnDestroy()
    {
        ShotButton.OnShotClicked -= ShotBullet;
        EventManager.OnGameStarted.RemoveAllListeners();
    }

    void EnableControls()
    {
        this.IsControlEnabled = true;
    }

    void SetAnimations()
    {
        if (moveZ > 0)
        {
            this.animator.SetFloat(CommonVariables.PLAYER_FORWARD, moveZ);
            this.animator.SetFloat(CommonVariables.PLAYER_BACKWARD, 0);
        }
        else if (moveZ < 0)
        {
            this.animator.SetFloat(CommonVariables.PLAYER_BACKWARD, -moveZ);
            this.animator.SetFloat(CommonVariables.PLAYER_FORWARD, 0);
        }
        else // idle
        {
            this.animator.SetFloat(CommonVariables.PLAYER_BACKWARD, 0);
            this.animator.SetFloat(CommonVariables.PLAYER_FORWARD, 0);
        }
    }

    private void ShotBullet()
    {
        PlayerProjectile projectile =
            PoolManager.Instance.SpawnBaseProjectile(playerProperties.ProjectileIndex, this.shotPosition) as PlayerProjectile;
        this.shotParticle.Simulate(0, true);
        this.shotParticle.Play();
        projectile.transform.rotation = this.shotPosition.rotation;
        projectile.StartMoving(playerProperties.BulletSpeed, playerProperties.BulletDamage,
            playerProperties.ProjectileIndex);
        OnShotBullet?.Invoke();
    }

    private void OnShotReady()
    {
        this.isChargeFinished = true;
    }


    /// <summary>
    ///  this is for Keyboard Testing works in editor only.
    /// </summary>
    public void TestShot()
    {
        if (!this.isChargeFinished)
        {
#if UNITY_EDITOR
            Debug.Log("Waiting for charge...");
#endif
            return;
        }

        ShotBullet();
    }
}
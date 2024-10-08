using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    [SerializeField] private float timeOutPerSpawn;
    private bool isSpawning = false;
    private TimeCounter spawnTimer;

    private void Awake()
    {
        spawnTimer = new TimeCounter(timeOutPerSpawn);
        EventManager.OnGameStarted.AddListener(StartSpawning);
        spawnPoints = this.GetComponentsInChildren<SpawnPoint>().ToList();
        EventManager.OnGameOver.AddListener(StopSpawning);
    }

    private void Update()
    {
        if (!isSpawning)
            return;
        if (spawnTimer.IsTickFinished(Time.deltaTime))
        {
            GetRandomPointAndSpawn();
        }
    }

    private void GetRandomPointAndSpawn()
    {
        if (this.spawnPoints is null || this.spawnPoints.Count == 0)
        {
#if UNITY_EDITOR
            Debug.LogError($"There is no spawn point at child of this game object enemies wont be spawn.");
#endif
        }

        int targetSpawnIndex = UnityEngine.Random.Range(0, this.spawnPoints.Count);
        PoolManager.Instance.SpawnEnemy(0, this.spawnPoints[targetSpawnIndex].GetTransform());
    }

    private void StartSpawning()
    {
        this.isSpawning = true;
    }

    private void StopSpawning()
    {
        this.isSpawning = false;
    }
}
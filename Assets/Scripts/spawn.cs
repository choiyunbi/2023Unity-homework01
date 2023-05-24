using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool enableSpawn = false;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 1);
    }
    void SpawnEnemy()
    {
        if (enableSpawn)
        {
            // 랜덤한 위치에서 Enemy 생성
            Vector3 spawnPos = new Vector3(Random.Range(-15.0f, 15.0f), Random.Range(-10.0f, 10.0f), 40.0f);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            // 플레이 시간에 따라 생성 간격을 조절
            float interval = 2.0f;
            if (Time.time > 10.0f) interval = 1.0f;
            if (Time.time > 20.0f) interval = 0.5f;
        }
    }
}

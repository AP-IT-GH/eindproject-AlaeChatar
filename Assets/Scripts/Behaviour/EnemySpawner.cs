using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{    
    [SerializeField] 
    private GameObject Enemy;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float spawnSpeedIncrement;
    private float spawnSpeedDifference;
    private float remainingCooldown;
    // Start is called before the first frame update
    void Start()
    {
        spawnSpeedDifference = 0;
    }

    void Update()
    {
        remainingCooldown -= Time.deltaTime;
        if(remainingCooldown < 0)
        {
            int spawnPattern = Random.Range(1, (int)Mathf.Ceil((spawnSpeedDifference / spawnSpeedIncrement)/10));
            SpawnEnemy();
            remainingCooldown = cooldown;
            spawnSpeedDifference += spawnSpeedIncrement;
            remainingCooldown /= (spawnSpeedDifference + 1);
        }
    }

    public void SpawnEnemy()
    {
        Instantiate
        (
            Enemy,
            calculateSpawnPoint(),
            new Quaternion()
        );
    }

    private Vector3 calculateSpawnPoint()
    {   
        float r=25f;
        float angle=Random.Range(0,Mathf.PI*2);
        return new Vector3(Mathf.Sin(angle)*r, 1f, Mathf.Cos(angle)*r);
    }
}

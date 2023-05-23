using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private LevelVariables levelVar;

    [SerializeField]
    private int EnergyDeathValue = 1;
    [SerializeField]
    private int ScoreDeathValue = 1;
    [SerializeField]
    private int Hp = 1;

    public void HandleHit()
    {
        levelVar.score += ScoreDeathValue;
        levelVar.energy += EnergyDeathValue;
        Hp -= 1;

        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

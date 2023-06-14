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
    
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "PlayerBeam" || other.gameObject.tag == "PlayerFist")
        {
            levelVar.score += ScoreDeathValue;
            levelVar.energy += EnergyDeathValue;
            Hp -= 1;

            if(Hp <= 0)
            {
                Destroy(gameObject);
            }
            print("no");
        }

        if(other.gameObject.tag == "Player")
        {
            levelVar.hp -= 1;
            Destroy(gameObject);
            print("player");
        }
    }
}
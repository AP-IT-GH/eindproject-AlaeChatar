using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    [SerializeField]
    private LevelVariables levelVar;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            levelVar.score += 1;
        }
    }
}

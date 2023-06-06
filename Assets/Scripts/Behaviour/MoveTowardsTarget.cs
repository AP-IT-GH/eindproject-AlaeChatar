using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{    
    [SerializeField]
    private LevelVariables levelVar;

    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private int movementSpeed = 1;

    [SerializeField]
    private GameObject player;

    void Start() {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //aim at player
        Vector3 targetPostition = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z) ;
        this.transform.LookAt(targetPostition) ;
        //move towards player
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            levelVar.hp -= 1;
            Destroy(gameObject);
        }
    }
}

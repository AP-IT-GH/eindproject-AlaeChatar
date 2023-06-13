using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 10;
    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * bulletSpeed;
    }
}

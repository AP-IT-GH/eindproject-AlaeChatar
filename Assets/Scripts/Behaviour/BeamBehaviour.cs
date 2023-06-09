using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : MonoBehaviour
{
    [SerializeField]
    private float warningTime;
    [SerializeField]
    private float dangerTime;
    [SerializeField]
    private Material warningMaterial;
    [SerializeField]
    private Material dangerMaterial;
    private float lifeTime;
    void Start()
    {
        toggleWarning();
    }
    
    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime > warningTime && this.transform.gameObject.tag == "PlayerBeamWarning")
        {
            toggleDanger();
            lifeTime = 0;
        }
        else if(lifeTime > dangerTime && this.transform.gameObject.tag == "PlayerBeam")
        {
            Destroy(this);
        }
    }

    private void toggleDanger()
    {
        this.transform.gameObject.tag = "PlayerBeam";
        this.gameObject.GetComponent<MeshRenderer> ().material = dangerMaterial;
    }

    private void toggleWarning()
    {
        this.transform.gameObject.tag = "PlayerBeamWarning";
        this.gameObject.GetComponent<MeshRenderer> ().material = warningMaterial;
    }
}

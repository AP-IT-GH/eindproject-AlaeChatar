using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    [SerializeField]
    private LevelVariables levelVar;

    [SerializeField]
    private TMP_Text textEnergy;

    [SerializeField]
    private int maxEnergy;

    // Start is called before the first frame update
    void Start()
    {
        levelVar.energy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelVar.energy > maxEnergy)
        {
            levelVar.energy = maxEnergy;
        }
        textEnergy.text = "Energy: " + levelVar.energy + "/" + maxEnergy;
    }
}
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
        levelVar.Hp = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        textEnergy.text = "Energy: " + levelVar.Hp + "/" + maxEnergy;
    }
}
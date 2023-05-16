using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPManager : MonoBehaviour
{
    [SerializeField]
    private LevelVariables levelVar;

    [SerializeField]
    private TMP_Text textHp;

    [SerializeField]
    private int maxHp;

    // Start is called before the first frame update
    void Start()
    {
        levelVar.hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        textHp.text = "HP: " + levelVar.hp + "/" + maxHp;
    }
}

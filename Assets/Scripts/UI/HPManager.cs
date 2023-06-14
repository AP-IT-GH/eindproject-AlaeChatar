using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if(levelVar.hp > maxHp)
        {
            levelVar.hp = maxHp;
        }

        if(levelVar.hp < 1)
        {
            SceneManager.LoadScene(2);
        }
        textHp.text = "HP: " + levelVar.hp + "/" + maxHp;
    }
}

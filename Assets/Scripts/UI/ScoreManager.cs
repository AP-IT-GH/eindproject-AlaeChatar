using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private LevelVariables levelVar;

    [SerializeField]
    private TMP_Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        levelVar.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score: " + levelVar.score;
    }
}

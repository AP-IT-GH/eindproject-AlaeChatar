using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEvent : MonoBehaviour
{
    [SerializeField]
    private string nextLevel;

    public void loadNextLevel(){
       SceneManager.LoadScene(nextLevel);
    }
}

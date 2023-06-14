using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour

{
    public int SceneIndex;

    public void StartingGame(){
        SceneManager.LoadScene(SceneIndex);
    }
}

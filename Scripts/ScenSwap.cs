using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenSwap : MonoBehaviour
{
    public void NextScene(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}

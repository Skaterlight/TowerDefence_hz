using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoLevels_G : MonoBehaviour
{
    public int SceneNum;
    public void LoadSceneO()
    {
        SceneManager.LoadScene(SceneNum);
    }
}

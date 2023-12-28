using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadLevel : MonoBehaviour
{
    public string LeveltoLoad;

    public void LoadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(LeveltoLoad);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadLevel : MonoBehaviour
{
    public string LeveltoLoad;

    public void LoadLevel()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
}

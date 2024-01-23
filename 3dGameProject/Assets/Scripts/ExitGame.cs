using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitGameOnClick()
    {
        Debug.Log("Quitting game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

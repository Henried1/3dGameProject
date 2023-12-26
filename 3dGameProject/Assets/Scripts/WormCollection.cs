using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WormCollection : MonoBehaviour
{
    public TextMeshProUGUI worms;
    public float wormsToCatch = 1;
    private int wormsCaught;
    public string nextScenetoload;
    private void Start()
    {
        setWormsCaught();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Worm")
        {
            collision.gameObject.SetActive(false);
            wormsCaught += 1;
            setWormsCaught();
        }
        if (wormsCaught == wormsToCatch)
        {
            SceneManager.LoadScene(nextScenetoload);
        }

    }
    public void setWormsCaught()
    {
        worms.text = "Worms: " + wormsCaught + "/" + wormsToCatch;
    }

}

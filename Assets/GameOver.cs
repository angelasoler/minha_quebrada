using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public void BadEnding()
    {
        SceneManager.LoadScene("Bad ending");
    }

    public void GoodEnding()
    {
        SceneManager.LoadScene("Good ending");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Menu());
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("initMenu");
    }
}

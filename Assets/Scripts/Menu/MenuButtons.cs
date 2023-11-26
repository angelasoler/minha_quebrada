using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour

{
    public TMP_Text text;

    public SpriteRenderer button;

    public AudioSource audioSource;

    public AudioClip clip;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
    }
    private void OnMouseDown()
    {
        audioSource.PlayOneShot(clip);
        
    }

}

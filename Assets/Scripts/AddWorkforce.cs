using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AddWorkforce : MonoBehaviour

{

    public TMP_Text text;

    public SpriteRenderer button;

    private ResourceManager manager;

    AudioManager audioManager;

    public int delayToDespawn;

    private void Start()
    {
        manager = ResourceManager.Instance;
        audioManager = AudioManager.Instance;
        StartCoroutine(despawnAutomatic(delayToDespawn));
    }

    IEnumerator despawnAutomatic(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        manager.AddCount();
        audioManager.playSound("const_hospital");
        Destroy(gameObject);

    }

}

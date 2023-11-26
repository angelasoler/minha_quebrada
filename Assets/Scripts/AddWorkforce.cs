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

    private WorkforceSpawner workforceSpawner;

    public Animator animator;

    private void Start()
    {
        workforceSpawner = WorkforceSpawner.Instance;
        manager = ResourceManager.Instance;
        audioManager = AudioManager.Instance;
        StartCoroutine(despawnAutomatic(delayToDespawn));
    }

    IEnumerator despawnAutomatic(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        workforceSpawner.DecreaseCount();
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        manager.AddCount();
        workforceSpawner.DecreaseCount();
        audioManager.playSound("const_hospital");
        animator.SetTrigger("Clicked");

    }

    public void destroy()
    {
        Destroy(gameObject);
    }

}

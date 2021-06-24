using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollissionOrEvent : MonoBehaviour
{
    //variables declared in conjuction with time
    [Header("Colission Settings")]
    [SerializeField] float timeToWait = 2f;

    //Chached references
    PlayerMovement moveScript;
    MeshRenderer myRenderer;
    [Header("References")]
    [SerializeField] ParticleSystem explosion;
    [SerializeField] GameObject myCollider;

    //function that gets called as soon as the script starts up
    private void Awake()
    {
        StartupFunction();
    }

    //Any functionality that needs to be called at the start of the script will be called from here
    void StartupFunction()
    {
        moveScript = GetComponent<PlayerMovement>();
        myRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != Tags.TAGS_COLLECT)
        {
            StartCoroutine(WaitBeforeReloading());
        }
    }

    //Timer before reloading the level
    IEnumerator WaitBeforeReloading()
    {
        ShipColission();
        yield return new WaitForSeconds(timeToWait);
        ReloadLevel();
    }

    //Function that declares what happens if the ship collides
    void ShipColission()
    {
        explosion.Play();
        myCollider.SetActive(false);
        myRenderer.enabled = false;
        moveScript.enabled = false;
    }

    //Function That will reload the level when the player hits the obstacles
    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene);
    }
}

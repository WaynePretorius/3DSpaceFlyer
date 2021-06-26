using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour
{

    private void Awake()
    {
        MakeSingleton();
    }

    //counts the amount of Musicplayers, if there is more than 1, destroy it, otherwise, keep it running so the sound doesnt start over when the level resets
    void MakeSingleton()
    {
        int numOfMusicPlayers = FindObjectsOfType<MusicSingleton>().Length;

        if (numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
}

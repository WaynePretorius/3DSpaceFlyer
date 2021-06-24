using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeldDestructScript : MonoBehaviour
{
    //time to wait before selfdestructing
    [SerializeField] float timeToWait = 2f;

    private void Start()
    {
        Destroy(gameObject, timeToWait);
    }

}

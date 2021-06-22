using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionOrEvent : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Tags.TAGS_ENEMY)
        {
            print("You have bumped an enemy " + other.gameObject.name);
        }
        else if (other.gameObject.tag == Tags.TAGS_OBSTAC)
        {
            print("oops, you crashed into something " + other.gameObject.name);
        }
        else if (other.gameObject.tag == Tags.TAGS_TERRAIN)
        {
            print("You are leaving your mark here " + other.gameObject.name);
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.TAGS_COLLECT)
        {
            print("You have trigger a colectabel" + other.name);
        }
    }
}

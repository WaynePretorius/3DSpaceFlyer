using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //variables declared as settings for the enemies
    [Header("Settings")]
    [SerializeField] int enemyScore = 10;
    [SerializeField] int enemyHitPoints = 50;
    [SerializeField] int damageTakenPerHit = 25;

    //References that needs to be stored
    [Header("References for Objects")]
    [SerializeField] GameObject enemyExplosion;
    [SerializeField] GameObject enemyHit;
    GameObject instantiateParent;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        AwakeFunctions();
    }

    void AwakeFunctions()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        instantiateParent = GameObject.FindWithTag(Tags.TAGS_PARENT);
    }

    //Detects when particles with colliders hit the object of this script
    private void OnParticleCollision(GameObject other)
    {
        ProcessDamage(damageTakenPerHit);
    }

    //Function that handles when the enemy is hit
    void ProcessDamage(int damage)
    {
        ProcessHit();
        scoreKeeper.ModifyScore(enemyScore);
        enemyHitPoints -= damage;
        if(enemyHitPoints <= 0)
        {
            DestroyEnemy();
        }        
    }

    //Function that declares what happens when an enemy is hit
    void ProcessHit()
    {
        GameObject hit = Instantiate(enemyHit, transform.position, Quaternion.identity);
        hit.transform.parent = instantiateParent.transform;
    }

    //function that declares what happens when the enemy dies
    void DestroyEnemy()
    {
        GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        explosion.transform.parent = instantiateParent.transform;
        Destroy(gameObject);
    }


}

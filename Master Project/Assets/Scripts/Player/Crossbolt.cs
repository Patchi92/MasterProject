using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbolt : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * 120;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "NPC")
        {
            other.GetComponent<NPC>().npcHit();
            Destroy(gameObject);
        }


        if (other.tag == "EnemyMelee")
        {
            other.GetComponent<EnemyMelee>().health = other.GetComponent<EnemyMelee>().health - 5;
            Destroy(gameObject);
        }

        if (other.tag == "EnemyRanged")
        {
            other.GetComponent<EnemyRanged>().health = other.GetComponent<EnemyRanged>().health - 5;
            Destroy(gameObject);
        }
    }
}
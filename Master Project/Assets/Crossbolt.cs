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
            if (other.name == "Witch_Simple" || other.name == "Witch_Complex")
            {
                other.GetComponent<EnemyRanged>().enabled = true;
            }
        }


        if (other.tag == "EnemyMelee")
        {
            other.GetComponent<EnemyRanged>().health = other.GetComponent<EnemyRanged>().health - 5;
            Destroy(gameObject);
        }

        if (other.tag == "EnemyRanged")
        {
            other.GetComponent<EnemyRanged>().health = other.GetComponent<EnemyRanged>().health - 5;
            Destroy(gameObject);
        }
    }
}
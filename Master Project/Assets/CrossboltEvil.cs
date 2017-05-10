using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossboltEvil : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * 20;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerClass>().DamageTaken(Random.Range(8, 10));
            Destroy(gameObject);
        }

    }
}
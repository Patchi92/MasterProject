using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadowbolt : MonoBehaviour
{

    Vector3 endPos;

    // Use this for initialization
    void Start()
    {
        endPos = GameObject.Find("Player").transform.position;
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endPos, 0.5f);
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
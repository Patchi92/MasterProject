using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {

    GameObject player;

    public float speed;
    float step;

    Vector3 resetPos;

    // State
    bool move;
    bool attack;
    public bool reset;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Use this for initialization
    void Start () {
        reset = false;
        resetPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if(player == null)
        {
            player = GameObject.Find("Player");
        }

        step = speed * Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) < 10f && Vector3.Distance(player.transform.position, transform.position) > 2f)
        {
            move = true;
        } else
        {
            move = false;
        }
        	

        if(Vector3.Distance(player.transform.position, transform.position) < 2f)
        {
            attack = true;
        } else
        {
            attack = false;
        }


        //Move
        if(move && !reset)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }

        //Attack
        if(attack && !reset)
        {
            Debug.Log("Attack!");
        }

        if(reset)
        {
            transform.position = Vector3.MoveTowards(transform.position, resetPos, step * 2);

            if(transform.position == resetPos)
            {
                reset = false;
            }
        }
	}


    public void ResetNPC()
    {
        reset = true;
    }
}

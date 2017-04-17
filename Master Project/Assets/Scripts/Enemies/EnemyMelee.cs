using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour {

    GameObject player;
    public bool isNPC;
    public bool isGuard;

    public float speed;
    float step;

    int health;

    bool attackCD;

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
        gameObject.tag = "EnemyMelee";
        reset = false;
        resetPos = transform.position;

        health = 20;
        attackCD = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            if (isNPC)
            {
                PlayerPrefs.SetInt("KillerPoints", PlayerPrefs.GetInt("KillerPoints") + 1);
                PlayerPrefs.SetInt("NPCsKilled", 1);
            }
            else if (isGuard)
            {
                PlayerPrefs.SetInt("KillerPoints", PlayerPrefs.GetInt("KillerPoints") + 1);
            }
            else
            {
                PlayerPrefs.SetInt("HeroPoints", PlayerPrefs.GetInt("HeroPoints") + 1);
            }

            Destroy(gameObject);
        }


        if (player == null)
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
            if (!attackCD)
            {
                player.GetComponent<PlayerClass>().DamageTaken(Random.Range(6, 8));
                attackCD = true;
                StartCoroutine("AttackCD");
            }
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


    IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(1f);
        attackCD = false;
    }

    public void ResetNPC()
    {
        reset = true;
    }
}

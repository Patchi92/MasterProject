using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour {

    Animator aniObject;

    GameObject player;
    public bool isNPC;
    public bool isGuard;

    public float speed;
    float step;

    public int health;

    bool attackCD;

    Vector3 resetPos;

    // State
    bool stateAI;
    bool move;
    bool attack;
    public bool reset;

    bool runOnce;

    void Awake()
    {
        player = GameObject.Find("Player");
        aniObject = gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {

        aniObject.SetBool("Combat", true);
        gameObject.tag = "EnemyMelee";
        reset = false;
        resetPos = transform.position;

        health = 20;
        attackCD = false;

        runOnce = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            if (runOnce)
            {
                stateAI = false;

                aniObject.SetTrigger("Death");

                if (isNPC)
                {
                    PlayerPrefs.SetInt("KillerPoints", PlayerPrefs.GetInt("KillerPoints") + 1);
                    PlayerPrefs.SetInt("NPCsKilled", 1);
                    PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("Destruction") + 1);

                    player.GetComponent<PlayerClass>().ExpEarned(200);
                }
                else if (isGuard)
                {
                    PlayerPrefs.SetInt("KillerPoints", PlayerPrefs.GetInt("KillerPoints") + 1);
                    PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("Destruction") + 1);

                    player.GetComponent<PlayerClass>().ExpEarned(50);
                }
                else
                {
                    PlayerPrefs.SetInt("HeroPoints", PlayerPrefs.GetInt("HeroPoints") + 1);
                    PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("Excitement") + 1);
                    player.GetComponent<PlayerClass>().ExpEarned(40);
                }

                runOnce = false;
            }


        }

        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        step = speed * Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) > 3f && Vector3.Distance(player.transform.position, transform.position) < 20f)
        {
            move = true;
        }
        else
        {
            move = false;
        }


        if (Vector3.Distance(player.transform.position, transform.position) <= 3f)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        

        if (stateAI)
        {

            //Move
            if (move && !reset)
            {
                transform.LookAt(player.transform);
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            }

            //Attack
            if (attack && !reset)
            {
                transform.LookAt(player.transform);
                transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 50, transform.rotation.z));
                if (!attackCD)
                {
                    aniObject.SetTrigger("Attack");
                    attackCD = true;
                    StartCoroutine("AttackCD");
                }
            }

           

            if (reset)
            {
                aniObject.SetBool("Combat", false);
                transform.position = Vector3.MoveTowards(transform.position, resetPos, step * 2);

                if (transform.position == resetPos)
                {
                    reset = false;
                }
            }
        }
    }




    IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerClass>().DamageTaken(Random.Range(6, 8));
        yield return new WaitForSeconds(4f);
        attackCD = false;
        aniObject.SetTrigger("DoneAttack");
    }


    public void ResetNPC()
    {
        reset = true;
    }
}

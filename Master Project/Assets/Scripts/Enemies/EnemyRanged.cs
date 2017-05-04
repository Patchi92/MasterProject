using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour {

    Animator aniObject;
    public GameObject castPoint;
    public GameObject castObject;

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

    void Awake()
    {
        player = GameObject.Find("Player");
        aniObject = gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        aniObject.SetBool("Combat", true);
        gameObject.tag = "EnemyRanged";

        stateAI = true;
        reset = false;
        resetPos = transform.position;

        health = 10;
        attackCD = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            stateAI = false;

            aniObject.SetTrigger("Death");

            if (isNPC)
            {
                PlayerPrefs.SetInt("KillerPoints", PlayerPrefs.GetInt("KillerPoints") + 1);
                PlayerPrefs.SetInt("NPCsKilled", 1);
                PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("Destruction") + 1);
            } else if (isGuard)
            {
                PlayerPrefs.SetInt("KillerPoints", PlayerPrefs.GetInt("KillerPoints") + 1);
                PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("Destruction") + 1);
            } else
            {
                PlayerPrefs.SetInt("HeroPoints", PlayerPrefs.GetInt("HeroPoints") + 1);
                PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("Excitement") + 1);
            }

            //Destroy(gameObject, 5f);
        }

        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        step = speed * Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) < 10f && Vector3.Distance(player.transform.position, transform.position) > 10f)
        {
            move = true;
        }
        else
        {
            move = false;
        }


        if (Vector3.Distance(player.transform.position, transform.position) < 10f)
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
                    StartCoroutine("AttackCast");
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


    IEnumerator AttackCast()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(castObject, castPoint.transform.position, castPoint.transform.rotation);
    }


    IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(3f);
        attackCD = false;
    }


    public void ResetNPC()
    {
        reset = true;
    }
}

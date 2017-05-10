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
    int lastKnownHealth;

    bool attackCD;

    Vector3 resetPos;

    // State
    bool stateAI;
    bool move;
    bool attack;
    bool run;
    public bool reset;

    bool runOnce;

    int runDirection;

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

        attackCD = false;
        runOnce = true;

        lastKnownHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

        if(health != lastKnownHealth)
        {
            aniObject.SetTrigger("Hit");
            lastKnownHealth = health;
        }

        if (health <= 0)
        {
            if (runOnce)
            {
                stateAI = false;

                aniObject.SetTrigger("Death");

                if (isNPC)
                {
                    PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") - 1);
                    PlayerPrefs.SetInt("KillerPoints", PlayerPrefs.GetInt("KillerPoints") + 1);
                    PlayerPrefs.SetInt("NPCsKilled", 1);
                    PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("Destruction") + 1);

                    player.GetComponent<PlayerClass>().ExpEarned(200);
                }
                else if (isGuard)
                {
                    PlayerPrefs.SetInt("KillerPoints", PlayerPrefs.GetInt("KillerPoints") + 1);
                    PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("Destruction") + 1);
                }
                else
                {
                    PlayerPrefs.SetInt("HeroPoints", PlayerPrefs.GetInt("HeroPoints") + 1);
                    PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("Excitement") + 1);
                }

                Destroy(gameObject, 8f);
                runOnce = false;
            }
            
        }

        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        step = speed * Time.deltaTime;

        if (stateAI)
        {

            if (Vector3.Distance(player.transform.position, transform.position) > 12f && Vector3.Distance(player.transform.position, transform.position) < 20f)
            {
                aniObject.SetBool("Move", true);
                move = true;
            }
            else
            {
                aniObject.SetBool("Move", false);
                move = false;
            }


            if (Vector3.Distance(player.transform.position, transform.position) < 12f && Vector3.Distance(player.transform.position, transform.position) > 4f)
            {
                attack = true;
            }
            else
            {
                attack = false;
            }

            if (Vector3.Distance(player.transform.position, transform.position) < 4f)
            {
                if(run == false)
                {
                    runDirection = Random.Range(1, 4);
                }
                run = true;
            }
            else
            {
                run = false;
            }

       

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
                //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 50, transform.rotation.z));
                if (!attackCD)
                {
                    StartCoroutine("AttackCast");
                    attackCD = true;
                    StartCoroutine("AttackCD");
                }
            }

            if(run && !reset)
            {
                aniObject.SetBool("Move", true);
                switch (runDirection)
                {
                    case 1:
                        transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position + Vector3.left, step * 2);
                        break;
                    case 2:
                        transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position - Vector3.left, step * 2);
                        break;
                    case 3:
                        transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position - Vector3.forward, step * 2);
                        break;
                    default:
                        Debug.Log("Something is wrong");
                        break;
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
        aniObject.SetTrigger("Attack");
        if (gameObject.name == "Witch_Simple" || gameObject.name == "Witch_Complex")
        {
            yield return new WaitForSeconds(1f);
            Instantiate(castObject, castPoint.transform.position, castPoint.transform.rotation);
        }
        else
        {
            yield return new WaitForSeconds(1.8f);
            Instantiate(castObject, castPoint.transform.position, castPoint.transform.rotation);
        }
    }


    IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(4f);
        attackCD = false;
        aniObject.SetTrigger("DoneAttack");
    }


    public void ResetNPC()
    {
        reset = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorTest : MonoBehaviour {

    //Actions
    bool bashCD;
    bool slashCD;
    bool chargeCD;

    Ray chargeRay;
    RaycastHit chargeHit;
    bool chargeEnemy;
    public float chargeSpeed;

    //Animations
    Animator playerCam;
    Animator playerShield;
    Animator playerSword;

    void Awake()
    {
        playerCam = transform.FindChild("Player Camera").GetComponent<Animator>();
        playerShield = transform.FindChild("Shield").GetComponent<Animator>();
        playerSword = transform.FindChild("Sword").GetComponent<Animator>();
    }


    // Use this for initialization
    void Start () {
        bashCD = false;
        slashCD = false;
        chargeCD = false;
        chargeEnemy = false;

    }
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!bashCD)
            {
                playerShield.SetTrigger("Bash");
                bashCD = true;
                StartCoroutine("BashCD");
            }
           
        }


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!slashCD)
            {
                playerSword.SetTrigger("Slash");
                slashCD = true;
                StartCoroutine("SlashCD");
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!chargeCD)
            {
                chargeRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if (Physics.Raycast(chargeRay, out chargeHit))
                {
                    if(chargeHit.transform.tag == "Enemy")
                    {
                        if (Vector3.Distance(transform.position, chargeHit.transform.position) < 20)
                        {
                            playerCam.SetBool("isCharging", true);
                            chargeCD = true;
                            chargeEnemy = true;
                            StartCoroutine("ChargeCD");
                        }
                    }
                }
            }

        }

        if(chargeEnemy)
        {
            float step = chargeSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, chargeHit.transform.position, step);

            if(Vector3.Distance(transform.position, chargeHit.transform.position) < 2)
            {
                playerCam.SetBool("isCharging", false);
                chargeEnemy = false;
            }
        }

    }

    IEnumerator BashCD()
    {
        yield return new WaitForSeconds(1f);
        bashCD = false;
    }

    IEnumerator SlashCD()
    {
        yield return new WaitForSeconds(1f);
        slashCD = false;
    }

    IEnumerator ChargeCD()
    {
        yield return new WaitForSeconds(3f);
        chargeCD = false;
    }
}

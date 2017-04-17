using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClass : MonoBehaviour {


    //UI
    GameObject UI;
    GameObject HealthUI;
    Text HealthAmountUI;

    //Player
    int health;
    int damageReduction;

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

    //Class
    public GameObject sword;
    public GameObject shield;
    public GameObject staff;
    public GameObject dagger;
    public GameObject bow;


    void Awake()
    {
        UI = GameObject.Find("UI").gameObject;
        HealthUI = UI.transform.FindChild("HP").gameObject;
        HealthAmountUI = HealthUI.transform.FindChild("amountHP").gameObject.GetComponent<Text>();
        playerCam = transform.FindChild("Player Camera").GetComponent<Animator>();
    }


    // Use this for initialization
    void Start()
    {

        HealthUI.SetActive(true);
        health = 100;
        HealthAmountUI.text = "HP: " + health.ToString();

        if (PlayerPrefs.GetString("PlayerClass") == "Warrior")
        {
            damageReduction = 5;
            

            sword.SetActive(true);
            shield.SetActive(true);
            playerShield = transform.FindChild("Shield").GetComponent<Animator>();
            playerSword = transform.FindChild("Sword").GetComponent<Animator>();

            bashCD = false;
            slashCD = false;
            chargeCD = false;
            chargeEnemy = false;
        }

        if (PlayerPrefs.GetString("PlayerClass") == "Mage")
        {
            damageReduction = 1;

            staff.SetActive(true);
        }

        if (PlayerPrefs.GetString("PlayerClass") == "Assassin")
        {
            damageReduction = 2;

            dagger.SetActive(true);
            bow.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("Dead");
        }

        if (PlayerPrefs.GetString("PlayerClass") == "Warrior")
        {



            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (!bashCD)
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
                        Debug.Log(chargeHit.transform.name);
                        if (chargeHit.transform.tag == "EnemyMelee" || chargeHit.transform.tag == "EnemyRanged")
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

            if (chargeEnemy)
            {
                float step = chargeSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, chargeHit.transform.position, step);

                if (Vector3.Distance(transform.position, chargeHit.transform.position) < 2)
                {
                    playerCam.SetBool("isCharging", false);
                    chargeEnemy = false;
                }
            }

        }

    }


    public void DamageTaken(int amount)
    {
        health = health - (amount - damageReduction);
        HealthAmountUI.text = "HP: " + health.ToString();
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

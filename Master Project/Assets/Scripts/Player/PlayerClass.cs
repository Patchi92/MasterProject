using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClass : MonoBehaviour {


    //UI
    GameObject UI;
    GameObject InfoUI;
    Text HealthAmountUI;
    Text LevelAmountUI;
    Text GoldAmountUI;

    //Player
    GameObject player;
    int health;
    int level;
    int exp;
    int gold;
    int damageReduction;
    bool abilityLock;

    //Actions

    GameObject hitBox;
    bool globalCD;

    //Warrior


    //Mage
    public GameObject frostbolt;
    public GameObject mageCastPoint;
    bool coneOfColdCD;

    //Assassin
    public GameObject crossbolt;
    public GameObject assassinCastPoint;
    bool shootCD;


    //Animations
    Animator playerCam;
    Animator playerShield;
    Animator playerSword;
    Animator playerStaff;
    Animator playerDagger;
    Animator playerCrossbow;

    //Class
    public GameObject sword;
    public GameObject shield;
    public GameObject staff;
    public GameObject dagger;
    public GameObject bow;


    void Awake()
    {
        player = gameObject;
        UI = GameObject.Find("UI").gameObject;
        InfoUI = UI.transform.FindChild("PlayerInfo").gameObject;
        HealthAmountUI = InfoUI.transform.FindChild("amountHP").gameObject.GetComponent<Text>();
        LevelAmountUI = InfoUI.transform.FindChild("amountLevel").gameObject.GetComponent<Text>();
        GoldAmountUI = InfoUI.transform.FindChild("amountGold").gameObject.GetComponent<Text>();

        playerCam = transform.FindChild("Player Camera").GetComponent<Animator>();
        hitBox = gameObject.transform.FindChild("HitArea").gameObject;
    }


    // Use this for initialization
    void Start()
    {
        abilityLock = false;
        InfoUI.SetActive(true);
        health = 100;
        HealthAmountUI.text = "HP: " + health.ToString();
        level = 1;
        LevelAmountUI.text = "Level: " + level.ToString();
        gold = 0;
        GoldAmountUI.text = "Gold: " + gold.ToString();

        globalCD = false;

        PickClass();


    }

    // Update is called once per frame
    void Update()
    {

        if(exp >= 100)
        {
            if (level < 10)
            {
                ++level;
                exp = exp - 100;
                LevelAmountUI.text = "Level: " + level.ToString();
                health = health + 10;
                if(health > 100)
                {
                    health = 100;
                }
                HealthAmountUI.text = "HP: " + health.ToString();
            }
        }

        if (health <= 0)
        {
            Debug.Log("Dead");
        }


        abilityLock = gameObject.GetComponent<PlayerMovement>().movementLock;

        if (!abilityLock)
        {

            if (!globalCD)
            {

                if (PlayerPrefs.GetString("PlayerClass") == "Warrior")
                {



                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        //playerSword.SetTrigger("Bash");
                        hitBox.SetActive(true);
                        globalCD = true;
                        StartCoroutine("GlobalCD");
                    }


                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        //playerShield.SetTrigger("BlockUp");
                        damageReduction = 8;
                        globalCD = true;
                    }

                    if (Input.GetKeyUp(KeyCode.Mouse1))
                    {
                        //playerShield.SetTrigger("BlockDown");
                        damageReduction = 5;
                        StartCoroutine("GlobalCD");
                    }



                }

                if (PlayerPrefs.GetString("PlayerClass") == "Mage")
                {

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        //playerStaff.SetTrigger("Icebolt");
                        Instantiate(frostbolt, mageCastPoint.transform.position, mageCastPoint.transform.rotation);
                        globalCD = true;
                        StartCoroutine("GlobalCD");
                    }


                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        if (!coneOfColdCD)
                        {
                            //playerStaff.SetTrigger("ConeOfCold");
                            coneOfColdCD = true;
                            globalCD = true;
                            StartCoroutine("GlobalCD");
                            StartCoroutine("ConeOfColdCD");
                        }

                    }

                }

                if (PlayerPrefs.GetString("PlayerClass") == "Assassin")
                {



                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        //playerDagger.SetTrigger("Slash");
                        hitBox.SetActive(true);
                        globalCD = true;
                        StartCoroutine("GlobalCD");
                    }


                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        if (!shootCD)
                        {
                            coneOfColdCD = true;
                            playerCrossbow.SetTrigger("Shoot");
                            Instantiate(crossbolt, assassinCastPoint.transform.position, assassinCastPoint.transform.rotation);
                            globalCD = true;
                            StartCoroutine("GlobalCD");
                            StartCoroutine("ShootCD");
                        }
                    }





                }

            }

        }

    }


   
    public void PickClass()
    {
        if (PlayerPrefs.GetString("PlayerClass") == "Warrior")
        {
            damageReduction = 5;

            staff.SetActive(false);
            dagger.SetActive(false);
            bow.SetActive(false);

            sword.SetActive(true);
            shield.SetActive(true);
            //playerShield = transform.FindChild("Shield").GetComponent<Animator>();
            //playerSword = transform.FindChild("Sword").GetComponent<Animator>();




        }

        if (PlayerPrefs.GetString("PlayerClass") == "Mage")
        {
            damageReduction = 1;

            sword.SetActive(false);
            shield.SetActive(false);
            dagger.SetActive(false);
            bow.SetActive(false);


            staff.SetActive(true);
            //playerStaff = transform.FindChild("Shield").GetComponent<Animator>();

            coneOfColdCD = false;
        }

        if (PlayerPrefs.GetString("PlayerClass") == "Assassin")
        {
            damageReduction = 2;


            sword.SetActive(false);
            shield.SetActive(false);
            staff.SetActive(false);

            dagger.SetActive(true);
            //playerDagger = transform.FindChild("Shield").GetComponent<Animator>();
            bow.SetActive(true);
            playerCrossbow = bow.GetComponent<Animator>();

            shootCD = false;
        }

        if (PlayerPrefs.GetString("PlayerClass") == "Nothing")
        {

            sword.SetActive(false);
            shield.SetActive(false);
            staff.SetActive(false);
            dagger.SetActive(false);
            bow.SetActive(false);
         
        }
    }


    public void ExpEarned(int amount)
    {
        exp = exp + amount;
    }

    public void DamageTaken(int amount)
    {
        health = health - (amount - damageReduction);
        HealthAmountUI.text = "HP: " + health.ToString();
    }

    public void PickUpGold(int amount)
    {
        gold = gold + amount;
        GoldAmountUI.text = "Gold: " + gold.ToString();
    }


    IEnumerator GlobalCD()
    {
        yield return new WaitForSeconds(1f);
        globalCD = false;
    }

    IEnumerator ConeOfColdCD()
    {
        yield return new WaitForSeconds(5f);
        coneOfColdCD = false;
    }

    IEnumerator ShootCD()
    {
        yield return new WaitForSeconds(3f);
        shootCD = false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitArea : MonoBehaviour {

    private void OnEnable()
    {
        StartCoroutine("HitTime");
    }

    public int damage;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
          other.GetComponent<NPC>().npcHit();       
        }

        if (other.tag == "EnemyRanged")
        {
            other.GetComponent<EnemyRanged>().health = other.GetComponent<EnemyRanged>().health - damage;
        }

        if (other.tag == "EnemyMelee")
        {
            other.GetComponent<EnemyRanged>().health = other.GetComponent<EnemyRanged>().health - damage;
        }
    }

    IEnumerator HitTime()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}

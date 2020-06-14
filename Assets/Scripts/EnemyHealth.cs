using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    bool hasDied = false;

    public void Hit(float damage) {
        if(hasDied) return;
        BroadcastMessage("OnDamageTaken");
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        if(hasDied) return;
        hasDied = true;
        GetComponent<Animator>().SetTrigger("die");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}

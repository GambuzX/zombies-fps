using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth playerHealth;
    [SerializeField] float damage = 40f;

    void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        
    }

    public void AttackHitEvent() {
        if (playerHealth == null) return;

        playerHealth.Hit(this.damage);
        playerHealth.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}

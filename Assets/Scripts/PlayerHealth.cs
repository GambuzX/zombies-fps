﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void Hit(float damage) {
        health -= damage;
        if (health <= 0) {
            GetComponent<DeathHandler>().TriggerGameOver();
        }
    }
}

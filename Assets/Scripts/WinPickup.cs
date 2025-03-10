﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPickup : MonoBehaviour
{
    [SerializeField] int nextLevel = 0;

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            SceneManager.LoadScene(nextLevel);
        }
    }
}

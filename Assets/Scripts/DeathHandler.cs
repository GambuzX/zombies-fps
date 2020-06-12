using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start() {
        gameOverCanvas.enabled = false;
    }

    public void TriggerGameOver() {        
        GetComponent<FirstPersonController>().enabled = false;
        GetComponentInChildren<Weapon>().enabled = false;
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

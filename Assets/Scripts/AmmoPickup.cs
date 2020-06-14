using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmmount = 5;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Ammo playerAmmo = other.gameObject.GetComponent<Ammo>();
            if (playerAmmo) {
                playerAmmo.AddAmmo(ammoType, ammoAmmount);
            }
            Destroy(gameObject);
        }
    }
}

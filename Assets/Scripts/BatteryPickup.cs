using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            Flashlight flashlight = other.gameObject.GetComponentInChildren<Flashlight>();
            if(flashlight) {
                flashlight.RestoreLightAngle(restoreAngle);
                flashlight.AddLightIntensity(addIntensity);
            }
            Destroy(gameObject);
        }
    }
}

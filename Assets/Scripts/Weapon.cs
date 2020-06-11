using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        RaycastHit hit;
        if(!Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) return;

        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if(target) {
            PlayMuzzleFlash();
            target.Hit(damage);
        }
    }

    private void PlayMuzzleFlash() {
        muzzleFlash.Play();
    }
}

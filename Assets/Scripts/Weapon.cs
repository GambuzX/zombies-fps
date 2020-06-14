using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    private bool canShoot = true;
    [SerializeField] float shootCooldown = 1f;
    [SerializeField] TextMeshProUGUI ammoText;

    private void OnEnable() {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if(Input.GetMouseButtonDown(0) && canShoot) {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo() {
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    private IEnumerator Shoot() {
        if(ammoSlot.GetCurrentAmmo(ammoType) <= 0) yield break;
        
        canShoot = false;
        ammoSlot.ReduceCurrentAmmo(ammoType);

        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) {

            CreateHitEffect(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target) {
                PlayMuzzleFlash();
                target.Hit(damage);
            }
        }

        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    private void PlayMuzzleFlash() {
        muzzleFlash.Play();
    }

    private void CreateHitEffect(RaycastHit hit) {
        GameObject newHitEffect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(newHitEffect, .1f);
    }
}

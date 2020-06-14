using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int currentWeapon = 0;
    private int previousWeapon = 0;
    private List<GameObject> weapons = new List<GameObject>();

    void Start()
    {
        foreach(Weapon w in GetComponentsInChildren<Weapon>()) {
            weapons.Add(w.gameObject);
            w.gameObject.SetActive(false);
        }
        UpdateActiveWeapon();
    }

    void Update()
    {
        ProcessKeyInput();
        ProcessScrollWheel();
    }

    private void ProcessKeyInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SetWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SetWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SetWeapon(2);
        }
    }

    private void ProcessScrollWheel() {
        float scrollWheelVal = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelVal > 0) {
            SetNextWeapon();
        }
        else if (scrollWheelVal < 0) {
            SetPreviousWeapon();
        }
    }

    private void UpdateActiveWeapon() {
        WeaponZoom previousZoom = weapons[previousWeapon].GetComponent<WeaponZoom>();
        if (previousZoom) {
            previousZoom.SetDefaultZoom();
        }
        weapons[previousWeapon].SetActive(false);
        weapons[currentWeapon].SetActive(true);
    }

    private void SetWeapon(int num) {
        if (num == currentWeapon) return;

        previousWeapon = currentWeapon;
        currentWeapon = num;
        UpdateActiveWeapon();
    }

    private void SetNextWeapon() {
        previousWeapon = currentWeapon;
        currentWeapon = (currentWeapon+1) % weapons.Count;
        UpdateActiveWeapon();
    }

    private void SetPreviousWeapon() {
        previousWeapon = currentWeapon;
        currentWeapon--;
        if (currentWeapon < 0) 
            currentWeapon += weapons.Count;
        UpdateActiveWeapon();
    }
}

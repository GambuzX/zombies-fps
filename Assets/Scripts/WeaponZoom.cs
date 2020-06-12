using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedInMouseSensitivity = .5f;
    [SerializeField] float zoomedOutMouseSensitivity = 2f;

    bool zoomedInToggle = false;
    FirstPersonController firstPersonController;

    void Start() {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            fpsCamera.fieldOfView = zoomedInToggle ? zoomedOutFOV: zoomedInFOV;
            firstPersonController.m_MouseLook.XSensitivity = zoomedInToggle ? zoomedOutMouseSensitivity : zoomedInMouseSensitivity;
            firstPersonController.m_MouseLook.YSensitivity = zoomedInToggle ? zoomedOutMouseSensitivity : zoomedInMouseSensitivity;
            zoomedInToggle = !zoomedInToggle;
        }
    }
}

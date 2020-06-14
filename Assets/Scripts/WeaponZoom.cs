using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] FirstPersonController firstPersonController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedInMouseSensitivity = .5f;
    [SerializeField] float zoomedOutMouseSensitivity = 2f;

    bool zoomedInToggle = false;

    public void OnDisable() {
        ZoomOut();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            if(zoomedInToggle) 
                ZoomOut();
            else 
                ZoomIn();

            zoomedInToggle = !zoomedInToggle;
        }
    }

    public void ZoomIn() {
        fpsCamera.fieldOfView = zoomedInFOV;
        firstPersonController.m_MouseLook.XSensitivity = zoomedInMouseSensitivity;
        firstPersonController.m_MouseLook.YSensitivity = zoomedInMouseSensitivity;
    }

    public void ZoomOut() {
        fpsCamera.fieldOfView = zoomedOutFOV;
        firstPersonController.m_MouseLook.XSensitivity = zoomedOutMouseSensitivity;
        firstPersonController.m_MouseLook.YSensitivity = zoomedOutMouseSensitivity;
    }
}

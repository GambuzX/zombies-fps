using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float intensityDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;

    Light myLight;

    private void Start() {
        myLight = GetComponent<Light>();
    }

    private void Update() {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle() {
        myLight.spotAngle -= angleDecay * Time.deltaTime;
        myLight.spotAngle = Mathf.Max(myLight.spotAngle, minAngle);
    }

    private void DecreaseLightIntensity() {
        myLight.intensity -= intensityDecay * Time.deltaTime;
    }
    
    public void RestoreLightAngle(float restoreAngle) {
        myLight.spotAngle = Mathf.Max(restoreAngle, minAngle);
    }
    
    public void AddLightIntensity(float intensity) {
        myLight.intensity += intensity;
    }

}

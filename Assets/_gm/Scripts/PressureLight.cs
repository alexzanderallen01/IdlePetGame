using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PressureLight : MonoBehaviour
{
    public Light _myLight; 
    public PressurePlate pressurePlate;
    // Update is called once per frame
    void Update()
    {
        if (pressurePlate._PressurePlateState) {
            _myLight.intensity = 1;
        }
        else {
            _myLight.intensity = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public PressurePlate pressurePlate;
    public Transform door;
    public float DoorRotation;
    public float DoorMainRotation;
    private float x;
    private float z;

    public GameObject Door;
    void Start()
    {
        Vector3 rot = door.localRotation.eulerAngles;
        DoorMainRotation = rot.y;
        x = rot.x;
        z = rot.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressurePlate._PressurePlateState) {
            if (DoorMainRotation == 180){
                Vector3 rot = door.localRotation.eulerAngles;
                float y = DoorMainRotation + 90;
                quaternion doorExtraRotation = Quaternion.Euler(x,y,z);
                door.localRotation = doorExtraRotation;
            }
            else {
                Vector3 rot = door.rotation.eulerAngles;
                float y = DoorMainRotation - 90;
                quaternion doorExtraRotation = Quaternion.Euler(x,y,z);
                door.localRotation = doorExtraRotation;
            }
            
            //Door.SetActive(false);
        }
        else {
            //Door.SetActive(true);
            float y = DoorMainRotation;
            quaternion doorExtraRotation = Quaternion.Euler(x,y,z);
            door.localRotation = doorExtraRotation;
        }
    }
}

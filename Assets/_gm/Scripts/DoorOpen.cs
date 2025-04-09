using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    //Created vars for handling door logic
    public PressurePlate pressurePlate;
    public Transform door;
    public float DoorRotation;
    public float DoorMainRotation;
    private float x;
    private float z;

    public GameObject Door;
    void Start()
    {
        Vector3 rot = door.localRotation.eulerAngles;//Use eulerAngles to turn 4 var into 3 var
        DoorMainRotation = rot.y;//Set 3 vars for door main pos
        x = rot.x;
        z = rot.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressurePlate._PressurePlateState) {//If pressure plate true
            if (DoorMainRotation == 180){//Detect if door opens to the left or right
                Vector3 rot = door.localRotation.eulerAngles;
                float y = DoorMainRotation + 90;
                quaternion doorExtraRotation = Quaternion.Euler(x,y,z);
                door.localRotation = doorExtraRotation;//turn door to open pos
            }
            else {
                Vector3 rot = door.rotation.eulerAngles;
                float y = DoorMainRotation - 90;
                quaternion doorExtraRotation = Quaternion.Euler(x,y,z);
                door.localRotation = doorExtraRotation;
            }
            
            //Door.SetActive(false);//Make door disappear
        }
        else {
            //Door.SetActive(true);//Make door reappear
            float y = DoorMainRotation;
            quaternion doorExtraRotation = Quaternion.Euler(x,y,z);
            door.localRotation = doorExtraRotation;
        }
    }
}

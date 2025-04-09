using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform _Cameratransform;
    public Transform _Playertransform;
    public float _rotationSpeed = 0.5f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        float x = _Cameratransform.localRotation.eulerAngles.x-Input.GetAxis("Mouse Y")*_rotationSpeed;
        float y = 0;
        float z = 0;
        quaternion extraRotation = Quaternion.Euler(x,y,z);
        _Cameratransform.localRotation = extraRotation;
        x = 0;
        y = _Playertransform.localRotation.eulerAngles.y+Input.GetAxis("Mouse X")*_rotationSpeed;
        z = 0;
        quaternion playerextraRotation = Quaternion.Euler(x,y,z);
        _Playertransform.localRotation = playerextraRotation;
    }
}

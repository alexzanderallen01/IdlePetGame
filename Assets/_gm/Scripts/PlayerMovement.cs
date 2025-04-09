using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform _transform;
    public Rigidbody _rigidbody;
    public float _movespeed = 5f;
    public float _jumpstrength = 250;

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        float delta = Time.deltaTime;
        bool sprint = Input.GetKey(KeyCode.LeftShift);
        if (sprint){
            Vector3 displacement_local = new Vector3(xMovement,0,zMovement)*(_movespeed * 2)*delta;
            Vector3 displacement_world = _transform.TransformDirection(displacement_local);
            _rigidbody.position += displacement_world;
        }
        else{
            Vector3 displacement_local = new Vector3(xMovement,0,zMovement)*_movespeed*delta;
            Vector3 displacement_world = _transform.TransformDirection(displacement_local);
            _rigidbody.position += displacement_world;
        }
        bool isPressedSpace = Input.GetKeyDown(KeyCode.Space);
        if (isPressedSpace){
            Vector3 force = new Vector3(0,_jumpstrength,0);
            _rigidbody.AddForce(force);
        }
    }
}

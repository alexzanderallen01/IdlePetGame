using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //create vars for object pos, object mesh body, & base move & jump speed
    public Transform _transform;
    public Rigidbody _rigidbody;
    public float _movespeed = 5f;
    public float _jumpstrength = 250;

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");//Use unity's build in function to get mouse movement
        float zMovement = Input.GetAxis("Vertical");
        float delta = Time.deltaTime;//Get time
        bool sprint = Input.GetKey(KeyCode.LeftShift);//detect if shift is being pressed
        if (sprint){
            Vector3 displacement_local = new Vector3(xMovement,0,zMovement)*(_movespeed * 2)*delta;//create new local pos
            Vector3 displacement_world = _transform.TransformDirection(displacement_local);//convert local pos to world pos
            _rigidbody.position += displacement_world;//add pos to rigidbody to move character
        }
        else{
            Vector3 displacement_local = new Vector3(xMovement,0,zMovement)*_movespeed*delta;
            Vector3 displacement_world = _transform.TransformDirection(displacement_local);
            _rigidbody.position += displacement_world;
        }
        bool isPressedSpace = Input.GetKeyDown(KeyCode.Space);//detect if space has been pressed
        if (isPressedSpace){
            Vector3 force = new Vector3(0,_jumpstrength,0);
            _rigidbody.AddForce(force);//Add force to body to make it go up 
        }
    }
}

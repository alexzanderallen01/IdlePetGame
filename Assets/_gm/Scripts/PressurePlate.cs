using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool _PressurePlateState;//bool var for state of plate

    public GameObject _TouchingObject;//Object var that touched plate

    private void OnCollisionEnter(Collision collision)
    {
        _TouchingObject = collision.gameObject;//Get object from collision
        if(_TouchingObject.CompareTag("Crate")){//Make sure object is a crate
            _PressurePlateState = true; //Set Bool to true
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        _TouchingObject = null;//remove object after it is no longer touching
        _PressurePlateState = false;//Set Bool to false
    }
}
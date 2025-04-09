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
        if(_TouchingObject.CompareTag("Crate")){//Make sure
            _PressurePlateState = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        _TouchingObject = null;
        _PressurePlateState = false;
    }
}
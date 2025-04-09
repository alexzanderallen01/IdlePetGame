using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabObject : MonoBehaviour
{
    public Rigidbody _draggedRigidbody = null;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){//detect if left click is being pressed
            GrabItem();
        }
        if(Input.GetMouseButtonUp(0) && _draggedRigidbody !=null){//detect if left click has been let go of
            _draggedRigidbody.useGravity = true;
            _draggedRigidbody = null;
        }
        if(_draggedRigidbody != null){ //If holding a object, move it with the player & where player looks
            _draggedRigidbody.position = this.transform.position + transform.forward*1.5f;
        }
    }
    void GrabItem()
    {
        RaycastHit hit;//use raycast to see if player can pick anything up
        bool didIntersect = Physics.Raycast(transform.position, transform.forward, out hit, 50.0f);
        if (didIntersect==false){return;}//If nothing to pick up, end function
        bool isCreate = hit.transform.gameObject.tag == "Crate";
        if (isCreate){//Only allow for crates to be picked up
            _draggedRigidbody = hit.transform.gameObject.GetComponent<Rigidbody>();
            _draggedRigidbody.useGravity = false;//remove gravity from object so it can float where it is moved to while being held
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declaring gameObject's rigidbody
    public Rigidbody rb;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Initializing gameobject's rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        //Receive input from arrow keys (or awsd)
        float moveVert = Input.GetAxisRaw("Vertical");
        float moveHorz = Input.GetAxisRaw("Horizontal");

        //Apply commands to a force on object
        Vector3 move = new Vector3(moveHorz, 0, moveVert);
        rb.AddForce(move * speed);
    }
}

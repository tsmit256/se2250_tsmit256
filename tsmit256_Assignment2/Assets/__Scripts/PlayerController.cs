using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Declaring gameObject's rigidbody
    private Rigidbody _rb;

    public Material colourBlueLight, colourGrey, colourYellow;

    public float speed = 5;
    public int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //Initializing gameobject's rigidbody
        _rb = gameObject.GetComponent<Rigidbody>();

        //Initialize scoreText
        scoreText.text = "Score: " + score.ToString();
    }


    // Update is called once per frame
    void FixedUpdate()
    { 
        //Receive input from arrow keys (or awsd)
        float moveVert = Input.GetAxisRaw("Vertical");
        float moveHorz = Input.GetAxisRaw("Horizontal");

        //Apply commands to a force on object
        Vector3 move = new Vector3(moveHorz, 0, moveVert);
        _rb.AddForce(move * speed);
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUpObj"))
        {
            //Deactivates pick up object when collision occurs
            other.gameObject.SetActive(false);

            //Increment Score (based on property name of material defined in "PickUpCreator" script)
            if (other.gameObject.GetComponent<Renderer>().material.name == "Yellow")
            {
                score = score + 3;
            }
            else if (other.gameObject.GetComponent<Renderer>().material.name == "Light Blue")
            {
                score = score + 2;
            }
            else if (other.gameObject.GetComponent<Renderer>().material.name == "Grey")
            {
                score++;
            }
            //Display Score
            scoreText.text = "Score: " + score.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public Material colourBlueLight, colourGrey, colourYellow;
    public float speed = 5;
    public int score = 0;
    public Text scoreText;

    //Property - material of gameObject
    private string _matName;
    public string MatName
    {
        get { return _matName; }
        set { _matName = value; }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        //Initializing gameobject's rigidbody
        _rb = gameObject.GetComponent<Rigidbody>();

        //Initialize scoreText
        scoreText.text = "Score: " + score.ToString();
    }


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

            //Sets MatColour Property to be color of other gameobject
            MatName = other.gameObject.GetComponent<Renderer>().material.name;

            //Increment Score (based on property name of material defined in "PickUpCreator" script)
            if (MatName == "Yellow")
            {
                score = score + 3;
            }
            else if (MatName == "Light Blue")
            {
                score = score + 2;
            }
            else if (MatName == "Grey")
            {
                score++;
            }
            //Display Score
            scoreText.text = "Score: " + score.ToString();
        }
    }
}

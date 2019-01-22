using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour
{
    public Vector3 camSidePosition;
    public Vector3 camTopPosition;
    public Quaternion camSideRotationVal;
    public Quaternion camTopRotationVal;

    // Start is called before the first frame update
    void Start()
    {
        camSidePosition = gameObject.transform.position;
        camSideRotationVal = gameObject.transform.rotation;

        camTopPosition = new Vector3(0, 20, 0);
        camTopRotationVal = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C)){
            if(gameObject.transform.position == camSidePosition)
            {
                gameObject.transform.position = camTopPosition;
                gameObject.transform.rotation = camTopRotationVal;
            }
            else
            {
                gameObject.transform.position = camSidePosition;
                gameObject.transform.rotation = camSideRotationVal;
            }
        }
    }
}

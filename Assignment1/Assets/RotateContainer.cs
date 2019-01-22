using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContainer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 5));
        }
    }
}

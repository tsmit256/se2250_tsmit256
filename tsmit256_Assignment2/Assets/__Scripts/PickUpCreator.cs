using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCreator : MonoBehaviour
{
    public GameObject cubePrefabVar;
    public GameObject pickUpObjParent; //Name of gameobject drop-down for pickup objects
    public Material colourBlueLight, colourGrey, colourYellow; 

    private int _numCubes = 0;
    public int maxNumCubes = 8;
    private float _ang = 0;

    // Start is called before the first frame update
    void Start()
    {
        AddPickUps();
    }

    void AddPickUps()
    {
        Vector3 center = new Vector3(0, 1, 0);

        //While loop that instantiates pick up objects, assigns material, and position
        while (_numCubes < maxNumCubes)
        {
            _numCubes++;
            GameObject gObj = Instantiate<GameObject>(cubePrefabVar);
            gObj.name = "PickUpObj" + _numCubes;

            //This places all pick up objects under common gameObject drop-down
            gObj.transform.parent = pickUpObjParent.transform;

            //These if-statements determine the material (colour of object)
            //Material is then assigned name to be used in PlayerController script for scoring purposes
            if(_numCubes % 3 == 0)
            {
                gObj.GetComponent<Renderer>().material = colourBlueLight;
                gObj.GetComponent<Renderer>().material.name = "Light Blue";
            }
            else if (_numCubes % 3 == 1)
            {
                gObj.GetComponent<Renderer>().material = colourYellow;
                gObj.GetComponent<Renderer>().material.name = "Yellow";
            }
            else
            {
                gObj.GetComponent<Renderer>().material = colourGrey;
                gObj.GetComponent<Renderer>().material.name = "Grey";
            }
            gObj.transform.position = PosOnCircle(center, 3.0f);
        }
    }

    //Generates position of cubes to place them in a circle
    Vector3 PosOnCircle(Vector3 center, float radius)
        {
            Vector3 pos;
            pos.x = center.x + radius * Mathf.Sin(_ang * Mathf.Deg2Rad);
            pos.y = center.y;
            pos.z = center.z + radius * Mathf.Cos(_ang * Mathf.Deg2Rad);
            _ang = _ang + 360/maxNumCubes;
            return pos;
        }
}

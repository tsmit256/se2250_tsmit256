using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCreator : MonoBehaviour
{
    public GameObject cubePrefabVar;
    public GameObject pickUpObjParent;
    public Material colourBlueLight, colourGrey, colourYellow; 

    //NOT SURE IF I NEED THIS LIST              !!!!!!!  !!!   !!!  ! ! ! 
    public List<GameObject> gameObjectList;
    public int numCubes = 0;
    public float ang = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>();
        AddPickUps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddPickUps()
    {
        Vector3 center = new Vector3(0, 1, 0);
        while (numCubes < 8)
        {
            numCubes++;
            GameObject gObj = Instantiate<GameObject>(cubePrefabVar);
            gObj.name = "PickUpObj" + numCubes;
            gObj.transform.parent = pickUpObjParent.transform;

            //These if statements determine the material (colour of object)
            if(numCubes % 3 == 0)
            {
                gObj.GetComponent<Renderer>().material = colourBlueLight;
            }
            else if (numCubes % 3 == 1)
            {
                gObj.GetComponent<Renderer>().material = colourYellow;
            }
            else
            {
                gObj.GetComponent<Renderer>().material = colourGrey;
            }
            
            gameObjectList.Add(gObj);
            gObj.transform.position = PosOnCircle(center, 3.0f);
        }
    }

    Vector3 PosOnCircle(Vector3 center, float radius)
        {
            Vector3 pos;
            pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
            pos.y = center.y;
            pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            ang = ang + 45;
            return pos;
        }
}

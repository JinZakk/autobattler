using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Drag : MonoBehaviour {

    private Vector3 initialPosition;
    public static bool locked;
    public GameObject unit;
    public Vector3 moveHere;

    void Update()
    {

    }

    void OnMouseDown()
    {
        initialPosition = transform.position;
    }

    //https://answers.unity.com/questions/945153/dragging-a-3d-object-and-limiting-its-y-position.html
    void OnMouseDrag()

    {
        //Responsible for movement
        Plane plane = new Plane(Vector3.up, new Vector3(0, 1, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            transform.position = ray.GetPoint(distance);
        }

        //Detects "Grid" Objects
        RaycastHit[] allHit = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
        foreach (RaycastHit hit in allHit)
        {
            if (hit.collider.gameObject.tag == "Grid")
            {
                string temp = hit.collider.gameObject.name;
                PointDetected(temp);
                Debug.Log(temp);
            }
        }
    }

    void OnMouseUp()
    {
        //https://answers.unity.com/questions/657651/how-to-detect-mouse-events-when-the-object-is-cove.html
        if (Mathf.Abs(unit.transform.position.x - moveHere.x) <= 2f && Mathf.Abs(unit.transform.position.z - moveHere.z) <= 2f)
        {
            unit.transform.position = new Vector3(moveHere.x, 1, moveHere.z);
        }
        else
        {
            unit.transform.position = initialPosition;
        }
    }

    private void PointDetected(string pointDetected)
    {
        moveHere = GameObject.Find(pointDetected).transform.position;
    }

}
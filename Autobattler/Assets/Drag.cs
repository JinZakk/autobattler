﻿using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Drag : MonoBehaviour

{
    void OnMouseDrag()

    {
        Plane plane = new Plane(Vector3.up, new Vector3(0, 1, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            transform.position = ray.GetPoint(distance);
        }
    }

}
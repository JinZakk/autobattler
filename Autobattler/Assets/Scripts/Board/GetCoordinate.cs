using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GetCoordinate : MonoBehaviour
{
    //Vector3 boardCoord;
    [SerializeField]
    Transform coordinate;

    public event Action<Vector3> onCoordGet;

    private void Awake()
    {
        GetComponent<BoardInputManager>().onM1Press += GetCoord;
    }

    public void GetCoord()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            coordinate = hit.transform;
        }
        Vector3 boardCoord = new Vector3(coordinate.transform.position.x, 1f, coordinate.transform.position.z);

        if(onCoordGet!=null) onCoordGet(boardCoord);
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    public GameObject unitPrefab;

    public void Awake()
    {
        GetComponent<GetCoordinate>().onCoordGet += PlaceUnit;
    }

    public void PlaceUnit(Vector3 boardCoord)
    {
        Instantiate(unitPrefab, boardCoord, Quaternion.identity);
    }
}

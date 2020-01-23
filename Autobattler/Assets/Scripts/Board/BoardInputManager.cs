using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BoardInputManager : MonoBehaviour
{
    public event Action onM1Press;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(onM1Press != null) onM1Press();
        }
    }
}


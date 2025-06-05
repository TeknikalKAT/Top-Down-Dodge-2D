using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector3 mousePos;
    public bool move;
    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        move = Input.GetButtonDown("Fire1");
    }
}

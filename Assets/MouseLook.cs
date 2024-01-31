using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // enum to set values by name instead of number
    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }

    // public class-scope variable so it shows up in Inspector
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHoriz = 9.0f;

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            // horizontal rotation here
            float deltaHoriz = Input.GetAxis("Mouse X") * sensitivityHoriz;
            transform.Rotate(Vector3.up * deltaHoriz);
        } else if (axes == RotationAxes.MouseY)
        {
            // vertical rotation here
        } else
        {
            // both horizontal and vertical rotation here
        }
    }
}

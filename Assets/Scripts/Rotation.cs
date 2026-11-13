using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("Rotation Settings (hover on public variables for info)")]
    [Tooltip("Rotation speed (degrees per second) applied to each local axis: X, Y, Z")]
    public Vector3 rotationSpeed = new Vector3(0f, 90f, 0f);

    [Tooltip("If true, rotation is applied in local space; otherwise in world space")]
    public bool useLocalSpace = true;

    // Update is called once per frame
    void Update()
    {
        // Rotate per-axis by speed * deltaTime (degrees/frame)
        transform.Rotate(rotationSpeed * Time.deltaTime, useLocalSpace ? Space.Self : Space.World);
    }
}

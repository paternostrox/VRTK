using System.Collections;
using UnityEngine;

[System.Serializable]
public class Orientation
{
    public Vector3 position;
    public Quaternion rotation;

    public Orientation(Vector3 position, Quaternion rotation)
    {
        this.position = position;
        this.rotation = rotation;
    }
}
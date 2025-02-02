﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PPPUtil
{
    // Returns distance on the XZ plane
    public static float DistanceXZ(Vector3 a, Vector3 b)
    {
        float deltaX = a.x - b.x;
        float deltaZ = a.z - b.z;

        return Mathf.Sqrt(deltaX * deltaX + deltaZ * deltaZ);
    }

    // Returns vector (target - origin) ingnoring Y axis (XZ plane) 
    public static Vector3 ToTargetVecXZ(Vector3 origin, Vector3 target)
    {
        float deltaX = target.x - origin.x;
        float deltaZ = target.z - origin.z;

        return new Vector3(deltaX,0f,deltaZ);
    }

    // Returns normalized vector in the XY plane based on angle
    public static Vector3 VectorFromAngleXY(float angle)
    {
        float angleRad = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    // Returns angle based on vector XY coordinates
    public static float AngleFromVectorXY(Vector3 dir)
    {
        Vector3 normalizedDir = dir.normalized;
        float angle = Mathf.Atan2(normalizedDir.y, normalizedDir.x) * Mathf.Deg2Rad;
        if (angle < 0f)
            angle += 360f;
        return angle;
    }

    // Only goes one level deep (not sure)
    public static Transform[] GetAllChildren(Transform parent)
    {
        List<Transform> allChildren = new List<Transform>();
        foreach(Transform child in parent)
        {
            allChildren.Add(child);
        }
        return allChildren.ToArray();
    }

    // Returns array of positions of the given transforms
    public static Vector3[] Transforms2Positions(Transform[] transforms)
    {
        Vector3[] positions = new Vector3[transforms.Length];
        for (int i = 0; i < positions.Length; i++)
            positions[i] = transforms[i].position;
        return positions;
    }
}

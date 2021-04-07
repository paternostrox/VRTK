using System.Collections;
using UnityEngine;
using NaughtyAttributes;

public class Pathy : MonoBehaviour
{
    [ReadOnly] public Transform[] path; // Real path

    [Button]
    void UpdatePath()
    {
        path = PPPUtil.GetAllChildren(transform);
    }
}
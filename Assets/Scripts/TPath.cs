using System.Collections;
using UnityEngine;
using NaughtyAttributes;

// Represents a path of transforms
[System.Serializable]
public class Path
{
    [SerializeField]
    [AllowNesting]
    [OnValueChanged("SetPath")]
    Transform pathParent; // Parent

    [ReadOnly] public Transform[] path; // Real path

    void SetPath()
    {
        path = PPPUtil.GetAllChildren(pathParent);
    }
}
using System.Collections;
using UnityEngine;
using NaughtyAttributes;

public class TPath : MonoBehaviour
{
    [SerializeField]
    bool updatePath;

    [ReadOnly]
    public Transform[] path; // Real path

    public void UpdatePath()
    {
        path = PPPUtil.GetAllChildren(transform);
    }

    private void OnValidate()
    {
        if(updatePath == true)
        {
            updatePath = false;
            UpdatePath();
        }
    }

    private void OnDrawGizmos()
    {
        Transform[] children = PPPUtil.GetAllChildren(transform);
        for (int i = 0; i < children.Length - 1; i++)
        {
            Gizmos.color = new Color(0f, 255f, 0f);
            Gizmos.DrawLine(children[i].position, children[i + 1].position);
        }
    }
}
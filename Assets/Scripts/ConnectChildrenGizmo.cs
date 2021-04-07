using System.Collections;
using UnityEngine;

public class ConnectChildrenGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Transform[] children = PPPUtil.GetAllChildren(transform);
        for(int i=0;i<children.Length-1;i++)
        {
            Gizmos.color = new Color(0f,255f,0f);
            Gizmos.DrawLine(children[i].position, children[i+1].position);
        }
    }
}
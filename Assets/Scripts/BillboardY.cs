using UnityEngine;
using System.Collections;

public class BillboardY : MonoBehaviour
{
    Transform t;

    private void Start()
    {
        t = transform;
    }

    void Update()
    {
        t.LookAt(t.position + Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f) * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
    }
}

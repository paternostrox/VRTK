using System.Collections;
using UnityEngine;

public class ResetOnDisable : MonoBehaviour
{
    Orientation initialOrientation;

    private void Start()
    {
        initialOrientation = new Orientation(transform.position, transform.rotation);
    }

    private void OnDisable()
    {
        transform.position = initialOrientation.position;
        transform.rotation = initialOrientation.rotation;
        TreatmentManager.main.StartCoroutine(TreatmentManager.main.ReEnableObj(gameObject,1f));
    }
}
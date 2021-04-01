using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Patient : MonoBehaviour
{
    [SerializeField]
    TreatmentDatabase treatmentDatabase;

    Rigidbody rb;
    float moveSpeed;
    DialogueBox dialogueBox;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void RequestTreatment()
    {
        dialogueBox.Display();
    }

    public void GoAway()
    {

    }

    public void FollowPath(Transform[] path)
    {
        StartCoroutine(RunFollowPath(path));
    }

    IEnumerator RunWanderRandomly()
    {
        // Implement (has original pos and degree of freedom)
        yield return null;
    }

    IEnumerator RunFollowPath(Transform[] path)
    {
        for(int i =0; i < path.Length; )
        {
            Vector3 toTarget = PPPUtil.ToTargetVecXZ(transform.position, path[i].position);
            if (toTarget.magnitude > .01f) {
                rb.velocity = toTarget.normalized * moveSpeed;
            }
            else
                i++;
            yield return null;
        }
    }

    public void StopRB()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}

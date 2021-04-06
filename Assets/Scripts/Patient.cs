using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Patient : MonoBehaviour
{
    Rigidbody rb;
    float moveSpeed;
    DialogueBox dialogueBox;

    [SerializeField]
    TreatmentDatabase treatmentDatabase;

    Treatment currentTreatment;

    Transform[] currentPath;

    Queue<Action> tasks;

    int currentStation = -1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Initialize()
    {
        // Change visuals

        // Get tasks
        tasks = new Queue<Action>();

        bool hasVacancy = PathManager.main.HasVacancy();
        if (!hasVacancy)
        {
            PathManager.main.WaitInQueue(this);
            tasks.Enqueue(new Action(GoToWait));
            tasks.Enqueue(new Action(WanderRandomly));
        }
        tasks.Enqueue(new Action(TryGoToStation));
        tasks.Enqueue(new Action(RequestTreatment));
        tasks.Enqueue(new Action(GoToExit));

        PerformNextTask();
    }

    public void PerformNextTask()
    {
        Action a = tasks.Dequeue();
        a.Invoke();
    }

    public void GoToWait()
    {
        currentPath = PathManager.main.GetPathToWaitingZone();
        FollowPath();
    }

    public void TryGoToStation()
    {
        currentStation = PathManager.main.TryGetStation(out currentPath);
        if (currentStation != -1)
            FollowPath();
    }

    public void RequestTreatment()
    {
        currentTreatment = treatmentDatabase.GetRandomTreatment();
        dialogueBox.Display(currentTreatment.GetRequestMessage());
    }

    public void ReceiveTreatment()
    {
        PerformNextTask();
    }

    public void GoToExit()
    {
        PathManager.main.RemoveFromWait(this);
        dialogueBox.Display(currentTreatment.GetPostMessage());
        currentPath = PathManager.main.GetPathToExit(currentStation);
        FollowPath();
    }

    public void WanderRandomly()
    {

    }

    public void FollowPath()
    {
        StartCoroutine(RunFollowPath(currentPath));
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
        PerformNextTask();
    }

    public void StopRB()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}

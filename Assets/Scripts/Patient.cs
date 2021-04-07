using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Patient : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    TreatmentDatabase treatmentDatabase;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    DialogueBox dialogueBox;

    Treatment currentTreatment;

    Vector3[] currentPath;

    Queue<Action> tasks;

    int currentStation = -1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Initialize();
    }

    public void Initialize()
    {
        // Change visuals
        gameObject.SetActive(true);

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
        tasks.Enqueue(new Action(() => gameObject.SetActive(false)));

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

    IEnumerator RunFollowPath(Vector3[] path)
    {
        for(int i =0; i < path.Length; )
        {
            Vector3 toTarget = PPPUtil.ToTargetVecXZ(transform.position, path[i]);
            if (toTarget.magnitude > .05f) {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public static PathManager main;

    [SerializeField]
    TreatmentStation[] treatmentStations;

    [SerializeField]
    Path spawnToWaitingZone;

    List<Patient> waitQueue = new List<Patient>();

    [SerializeField]
    Bounds waitArea;

    private void Awake()
    {
        if (main == null)
            main = this;
        else
            throw new System.Exception("There should be only one PathManager in the scene!");
    }

    public void WaitInQueue(Patient patient)
    {
        waitQueue.Add(patient);
    }

    public void RemoveFromWait(Patient patient)
    {
        waitQueue.Remove(patient);
    }

    public bool HasVacancy()
    {
        for (int i = 0; i < treatmentStations.Length; i++)
        {
            if (!treatmentStations[i].isOccupied)
                return true;
        }
        return false;
    }

    public int TryGetStation(out Transform[] path)
    {
        for(int i=0;i < treatmentStations.Length; i++)
        {
            if(!treatmentStations[i].isOccupied)
            {
                path = treatmentStations[i].spawnToStation.path;
                treatmentStations[i].isOccupied = true;
                return i; // returns station index
            }
        }
        path = null;
        return -1;
    }

    public Transform[] GetPathToWaitingZone()
    {
        float xPos = Random.Range(waitArea.min.x, waitArea.max.x);
        float zPos = Random.Range(waitArea.min.z, waitArea.max.z);
        spawnToWaitingZone.path[spawnToWaitingZone.path.Length - 1].position = new Vector3(xPos,0f,zPos);
        Transform[] copy
        return spawnToWaitingZone.path; // ADICIONAR PERTURBACAO AQUI
    }

    public Transform[] GetPathToExit(int stationIndex)
    {
        if (stationIndex > 0)
        {
            treatmentStations[stationIndex].isOccupied = false;
            return treatmentStations[stationIndex].stationToExit.path;
        }
        else
        {
            Transform[] exit = { treatmentStations[0].stationToExit.path[treatmentStations[0].stationToExit.path.Length - 1] };
            return exit;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(waitArea.center,waitArea.size);
    }
}

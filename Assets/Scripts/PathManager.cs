using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathManager : Singleton<PathManager>
{
    //[SerializeField]
    //Transform spawnPoint, exitPoint;

    [SerializeField]
    TreatmentStation[] treatmentStations;

    [SerializeField]
    TPath spawnToWaitingZone;

    List<Patient> waitQueue = new List<Patient>();

    [SerializeField]
    Bounds waitArea;

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

    public int TryGetStation(out Vector3[] path)
    {
        for(int i=0;i < treatmentStations.Length; i++)
        {
            if(!treatmentStations[i].isOccupied)
            {
                path = PPPUtil.Transforms2Positions(treatmentStations[i].spawnToStation.path);
                treatmentStations[i].isOccupied = true;
                return i; // returns station index
            }
        }
        path = null;
        return -1;
    }

    public void DeoccupyStation(int stationIndex) 
    {
        treatmentStations[stationIndex].isOccupied = false;
    }

    public Vector3[] GetPathToWaitingZone()
    {
        float xPos = Random.Range(waitArea.min.x, waitArea.max.x);
        float zPos = Random.Range(waitArea.min.z, waitArea.max.z);
        Vector3 posInWaitZone = new Vector3(xPos,0f,zPos);
        spawnToWaitingZone.path[spawnToWaitingZone.path.Length - 1].position = posInWaitZone;
        Vector3[] path = PPPUtil.Transforms2Positions(spawnToWaitingZone.path);
        return path;
    }

    public Vector3[] GetPathToExit(int stationIndex)
    {
        if (stationIndex > 0)
        {
            treatmentStations[stationIndex].isOccupied = false;
            return PPPUtil.Transforms2Positions(treatmentStations[stationIndex].stationToExit.path);
        }
        else
        {
            Vector3[] exit = { treatmentStations[0].stationToExit.path[treatmentStations[0].stationToExit.path.Length - 1].position };
            return exit;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(waitArea.center,waitArea.size);
    }
}

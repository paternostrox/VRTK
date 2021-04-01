using System.Collections;
using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public class TreatmentStation
{
    public bool isOccupied;
    public Transform station;

    [SerializeField] [OnValueChanged("SetEntrancePath")] [AllowNesting]
    Transform EntranceToStationPath; // Parent
    [ReadOnly] public Transform[] entranceToStationPath; // Real path

    [SerializeField] [OnValueChanged("SetExitPath")] [AllowNesting]
    Transform StationToExitPath; // Parent
    [ReadOnly] public Transform[] stationToExitPath; // Real path

    void SetEntrancePath()
    {
        entranceToStationPath = PPPUtil.GetAllChildren(EntranceToStationPath);
    }

    void SetExitPath()
    {
        stationToExitPath = PPPUtil.GetAllChildren(StationToExitPath);
    }
}
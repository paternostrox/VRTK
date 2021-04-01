using System.Collections;
using UnityEngine;

public class PatientSpawner : MonoBehaviour
{
    public static PatientSpawner main; // Singleton

    [SerializeField]
    GameObject patientPrefab;

    private void Start()
    {
        if (main == null)
            main = this;
        else
            throw new System.Exception("There should be only one PatientManager in the scene!");
    }

    public void SpawnPatient()
    {

    }
}
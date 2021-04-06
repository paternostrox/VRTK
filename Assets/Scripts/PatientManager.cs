using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : MonoBehaviour
{
    public static PatientManager main;

    [SerializeField]
    GameObject patientPrefab;

    [SerializeField]
    Transform spawnPoint; // Entrance

    List<Patient> patientList = new List<Patient>();

    private void Start()
    {
        if (main == null)
            main = this;
        else
            throw new System.Exception("There should be only one PatientManager in the scene!");
    }

    public void SpawnPatient()
    {
        foreach(Patient p in patientList)
        {
            if(!p.enabled)
            {
                p.Initialize(); // not sure if this will run (GO disabled)
                return;
            }
        }
        Patient p = Instantiate<GameObject>(patientPrefab).GetComponent<Patient>();
        patientList.Add(p);
        p.Initialize();
    }
}
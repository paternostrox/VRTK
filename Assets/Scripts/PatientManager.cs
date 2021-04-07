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

    private void Awake()
    {
        if (main == null)
            main = this;
        else
            throw new System.Exception("There should be only one PatientManager in the scene!");

        StartCoroutine(RunSpawner(2f,12f));
    }

    IEnumerator RunSpawner(float minInterval, float maxInterval)
    {
        for(; ; )
        {
            SpawnPatient();
            float r = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(r);
        }
    }

    public void SpawnPatient()
    {
        foreach(Patient p in patientList)
        {
            if(!p.enabled)
            {
                p.gameObject.SetActive(true);
                return;
            }
        }
        Patient patient = Instantiate<GameObject>(patientPrefab).GetComponent<Patient>();
        patient.transform.position = spawnPoint.position;
        patientList.Add(patient);
    }
}
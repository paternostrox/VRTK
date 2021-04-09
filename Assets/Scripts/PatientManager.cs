using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : Singleton<PatientManager>
{

    [SerializeField]
    GameObject patientPrefab;

    [SerializeField]
    Transform spawnPoint; // Entrance

    List<Patient> patientList = new List<Patient>();

    [SerializeField]
    float spawnMin, spawnMax;

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(RunSpawner(spawnMin, spawnMax));
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

    public void RemoveFromList(Patient patient)
    {
        patientList.Remove(patient);
    }

    public void SpawnPatient()
    {
        Patient patient = Instantiate<GameObject>(patientPrefab).GetComponent<Patient>();
        patient.transform.position = spawnPoint.position;
        patientList.Add(patient);
    }
}
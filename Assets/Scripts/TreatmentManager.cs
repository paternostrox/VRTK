using System.Collections;
using UnityEngine;

public class TreatmentManager : Singleton<TreatmentManager>
{

    public TreatmentDatabase database;

    [Header("Must be in the same order as database!")]
    public TreatmentRepresentation[] reps;

    TreatmentPack[] packs;

    protected override void Awake()
    {
        base.Awake();

        // Make packs
        packs = new TreatmentPack[database.availableTreatments.Length];

        for(int i=0; i<packs.Length;i++)
        {
            packs[i] = new TreatmentPack(database.availableTreatments[i], reps[i]);
        }
    }

    public TreatmentPack GetTreatment()
    {
        int index = Random.Range(0, packs.Length);
        return packs[index];
    }

    public IEnumerator ReEnableObj(GameObject g, float time)
    {
        yield return new WaitForSeconds(time);
        g.SetActive(true);
    }
}
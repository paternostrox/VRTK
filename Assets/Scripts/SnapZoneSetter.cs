using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK.Prefabs.Interactions.InteractableSnapZone;
using Zinnia.Data.Collection.List;

    public class SnapZoneSetter : MonoBehaviour
{
    public void Set(GameObject treatmentObj, UnityAction receiveTreatment)
    {
        GetComponent<UnityObjectObservableList>().Add(treatmentObj);
        GetComponent<SnapZoneFacade>().Snapped.AddListener(g => receiveTreatment());
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ConfigOnAwake : MonoBehaviour
{
    public UnityEvent DoOnAwake;

    private void Awake()
    {
        DoOnAwake.Invoke();
    }
}
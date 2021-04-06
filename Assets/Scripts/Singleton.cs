using System.Collections;
using UnityEngine;
using System;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T main;

    protected virtual void Start()
    {
        if (main == null)
            main = (T) this;
        else
            throw new System.Exception("There should be only one " + typeof(T).FullName + " in the scene! (SINGLETON)");

    }
}
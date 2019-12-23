using System;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    public static T Instance;

    protected virtual void Awake()
    {
        if (Instance == null)
            Instance = (T)this;
        else
            throw new Exception($"Создано больше одного экземпляра {typeof(T).Name}.");
    }
}

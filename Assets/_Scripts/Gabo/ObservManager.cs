using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectObserv
{
    public Material original;
    public Material changeInObserv;
}

public class ObservManager : MonoBehaviour
{
    public static ObservManager instance;

    public void Awake()
    {
        instance = this;
    }
    public ObjectObserv objectChange;
}

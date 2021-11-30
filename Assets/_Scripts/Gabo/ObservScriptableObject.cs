using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservScriptableObject : MonoBehaviour
{
    public ObjectObserv classObserv;
    public bool change = true;

    public void Start()
    {
        change = true;
    }

    private void Update()
    {
        if (PlayerMovementIsaac.instance.changeCamera & change)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    public float speed = 10;
    

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 1*speed*Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RayObservation : MonoBehaviour
{
    public PlayerMovementIsaac player;
    public void Start()
    {
        player = FindObjectOfType<PlayerMovementIsaac>();
    }
    public void Update()
    {
        Vector3 mouse = Input.mousePosition;
        RaycastHit hit;
        if (player.changeCamera)
        {
            Debug.DrawRay(transform.position, mouse, Color.green, 10);
            Physics.Raycast(transform.position, mouse, out hit, 10);
            if (hit.transform)
            {
                Debug.Log("wena ctm");
            }
        }
 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RayObservation : MonoBehaviour
{
    PlayerMovementIsaac player;
    public Transform directionRay;
    public LayerMask layerRay;
    public void Start()
    {
        player = FindObjectOfType<PlayerMovementIsaac>();
    }
    public void Update()
    {
        //Vector3 mouse = Input.mousePosition;
        if (player.changeCamera && Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, directionRay.position, Color.green, 10);
            Physics.Raycast(transform.position, directionRay.position, out hit, 10, layerRay);
            if (hit.collider)
            {
                Debug.Log("wena ctm");
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
 
    }

    void ObservationDetected()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, directionRay.position, Color.green, 10);
        Physics.Raycast(transform.position, directionRay.position, out hit, 10, layerRay);
        if (hit.collider)
        {
            Debug.Log("wena ctm");
            hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}

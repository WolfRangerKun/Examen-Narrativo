using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RayObservation : MonoBehaviour
{
    PlayerMovementIsaac player;
    public Transform directionRay;
    public LayerMask layerRay;
    public float distanceRay;
    public void Start()
    {
        player = FindObjectOfType<PlayerMovementIsaac>();
    }
    public void Update()
    {
        if (player.changeCamera && Input.GetKey(KeyCode.E))
        {

            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward, Color.blue, 10);
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10, layerRay))
            {
                Debug.Log("wena ctm");
                hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            
        }
    }

    //public void ObservationDetected()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, directionRay.position, out hit, layerRay))
    //    {
    //        Debug.Log("wena ctm");
    //        hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    //    }
    //    Debug.DrawRay(transform.position, directionRay.position, Color.blue);

    //}

    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawRay(transform.position, transform.forward);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;
public class RayObservation : MonoBehaviour
{
    public TMP_Settings lol;
    Canvas tuVieja;
    PlayerMovementIsaac player;
    public LayerMask layerRay;
    public float distanceRay;
    public Transform target;
    public void Start()
    {
        player = FindObjectOfType<PlayerMovementIsaac>();
    }
    public void Update()
    {
        if (player.changeCamera && Input.GetKey(KeyCode.E))
        {

            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward, Color.blue, distanceRay);
            if (Physics.Raycast(transform.position, transform.forward, out hit, distanceRay, layerRay))
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.position);
    }


}

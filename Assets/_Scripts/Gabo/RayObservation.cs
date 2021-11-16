using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;
public class RayObservation : MonoBehaviour
{
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
            Debug.DrawRay(transform.position, target.transform.position, Color.blue, distanceRay);
            if (Physics.Raycast(transform.position, target.transform.position, out hit, distanceRay, layerRay))
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                Libreta.instance.RegisterGeturess(hit.transform.gameObject.GetComponent<ObservGests>().descripcion, hit.transform.gameObject.GetComponent<ObservGests>().gestoObservable);
            }
        }
    }

}

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
    public Vector3 targetVector;

    public void Start()
    {
        player = FindObjectOfType<PlayerMovementIsaac>();
    }
    public void Update()
    {
        if (player.changeCamera && Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.blue, distanceRay);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 100, out hit, distanceRay, layerRay))
            {
                hit.transform.gameObject.GetComponent<ObservScriptableObject>().change = false;
                Libreta.instance.RegisterGeturess(hit.transform.gameObject.GetComponent<ObservGests>().descripcion, hit.transform.gameObject.GetComponent<ObservGests>().gestoObservable);
                StartCoroutine(hit.transform.gameObject.GetComponent<ObservGests>().Situacion());
                
            }
        }
    }

}

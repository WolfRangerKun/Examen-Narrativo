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
    bool canSee = true;
    public void Start()
    {
        player = FindObjectOfType<PlayerMovementIsaac>();
    }
    public void Update()
    {
        //cameraSwitch = FindObjectOfType<CinemachineVirtualCamera>().Priority = h
        if (player.changeCamera && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Debug.DrawRay(/*cameraSwitch.position*/ transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue, distanceRay);
            if (Physics.Raycast(/*cameraSwitch.position*/transform.position, transform.TransformDirection(Vector3.forward) * 1000, out hit, distanceRay, layerRay) && canSee)
            {
                hit.transform.gameObject.GetComponent<ObservScriptableObject>().change = false;
                Libreta.instance.RegisterGeturess(hit.transform.gameObject.GetComponent<ObservGests>().descripcion, hit.transform.gameObject.GetComponent<ObservGests>().gestoObservable);
                StartCoroutine(hit.transform.gameObject.GetComponent<ObservGests>().Situacion());
                StartCoroutine("CanSee");
                canSee = false;
            }
        }
    }


    IEnumerator CanSee()
    {
        yield return new WaitForSeconds(2);
        canSee = true;
        yield break;
    }
}

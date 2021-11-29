using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaFInal : MonoBehaviour
{
    public AnimationsDialogueManager dM;
    public GameObject lol;
    private void Awake()
    {
        dM = FindObjectOfType<AnimationsDialogueManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(dM.DialogoClearGarmandoCity());
            lol.SetActive(true);
            //gameObject.SetActive(false);
        }
    }

    
}

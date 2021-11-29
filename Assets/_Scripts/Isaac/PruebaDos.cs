using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaDos : MonoBehaviour
{
    public AnimationsDialogueManager dM;
    private void Awake()
    {
        dM = FindObjectOfType<AnimationsDialogueManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(dM.DialogoClearGarmandoCityDORMIR());
        }
    }
}

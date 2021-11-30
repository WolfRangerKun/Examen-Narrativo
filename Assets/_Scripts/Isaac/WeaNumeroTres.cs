using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaNumeroTres : MonoBehaviour
{
    public AnimationsDialogueManager dM;
    public bool inicio, triggerOne;
    private void Awake()
    {
        dM = FindObjectOfType<AnimationsDialogueManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inicio)
            {
                StartCoroutine(dM.DialogoLastarriaSospecha());

            }
            if (triggerOne)
            {
                StartCoroutine(dM.DialogoLastarriaMiedo());

            }
        }
    }
}

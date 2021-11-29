using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaFInal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(AnimationsDialogueManager.instance.DialogoClearGarmandoCity());
            gameObject.SetActive(false);
        }
    }
}

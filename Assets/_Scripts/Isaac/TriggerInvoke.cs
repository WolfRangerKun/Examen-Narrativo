using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerInvoke : MonoBehaviour
{
    public UnityEvent triggerEnter, triggerExit;
    public bool desaparece, lol;
    bool canDo = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canDo)
        {
            triggerEnter?.Invoke();
            StartCoroutine(Recovery());
            canDo = false;
        }

        if (other.CompareTag("Player") && desaparece)
        {
            triggerEnter?.Invoke();
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Player") && lol)
        {
            triggerEnter?.Invoke();
            //gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && canDo)
        {
            triggerExit?.Invoke();
            StartCoroutine(Recovery());
            canDo = false;
        }
    }


    IEnumerator Recovery()
    {
        yield return new WaitForSeconds(1);
        canDo = true;
    }
}

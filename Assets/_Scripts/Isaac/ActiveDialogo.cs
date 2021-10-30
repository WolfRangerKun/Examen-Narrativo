using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDialogo : MonoBehaviour
{
    public DialogueManager dialogue;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.ShowDialogo(dialogue.dialogos[0]);
            if (dialogue.index >= dialogue.dialogos.Count)
            {
                dialogue.HideDialogo();
            }
        }
    }

    private void Update()
    {
        //if (dialogue.index >= dialogue.dialogos.Count)
        //{
        //    dialogue.HideDialogo();
        //}
    }
}

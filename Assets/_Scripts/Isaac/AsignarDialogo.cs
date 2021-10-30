using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarDialogo : MonoBehaviour
{
    public List<Dialogue> dialogosNpcAntes;
    public List<Dialogue> dialogosNpcDespues;
    DialogueManager dM;


    private void Start()
    {
        dM = FindObjectOfType<DialogueManager>();
    }
    public void AsignarDialogue()
    {
        dM = FindObjectOfType<DialogueManager>();
        if (dM.dialogos != dialogosNpcAntes)
        {
            dM.dialogos = dialogosNpcAntes;
        }
       


    }
}

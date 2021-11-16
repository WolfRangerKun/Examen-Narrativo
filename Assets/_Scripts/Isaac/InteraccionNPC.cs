using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteraccionNPC : MonoBehaviour
{
    public Question thisQuestion;
    public List<Dialogue> thisDialogue, thisDialogueRespuestaCorrectaUno;
    public GameObject cv;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayDialogue();
        }
    }
    
    void ReemplazarPalabra()
    {
        string fraseOrginial = thisQuestion.question;

        foreach (string z in Libreta.instance.notasPalabras)
        {
            if (fraseOrginial.Contains(z))
            {
                string palabraBuena = "";
                for (int i = 0; i < Libreta.instance.notasPalabras.Count; i++)
                {
                    if (Libreta.instance.notasPalabras[i] == z)
                    {
                        ////solo funciona si la lista tiene un significado solamente
                        
                        palabraBuena = Libreta.instance.sigPalabras[i].significados[0];
                    }
                }
                string nuevaFrase = fraseOrginial.Replace(z, palabraBuena);
                thisQuestion.question = nuevaFrase;
                return;
            }
        }
    }

    void PlayDialogue()
    {
        ReemplazarPalabra();
        cv.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        //thisDialogue.FindLast(x => x.dialogo == thisQuestion.question);
        int x = thisDialogue.Count;
        thisDialogue[x-1].dialogo = thisQuestion.question;
        DialogueManager.intance.dialogos = thisDialogue;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
        StartCoroutine(ShowDialogue());
        //thisDialogue.dialogo
    }


    IEnumerator ShowDialogue()
    {
        int x = thisDialogue.Count;
        
        yield return new WaitUntil(() => DialogueManager.intance.index == x-1);
        DialogueManager.intance.canContinue = false;
        QuestionManager.intance.ShowQuestion(thisQuestion);

        yield return new WaitUntil(() => QuestionManager.intance.replies[thisQuestion.correctAnswer].jaja != 0);
        QuestionManager.intance.botones.SetActive(false);
        DialogueManager.intance.index =0;

        DialogueManager.intance.canContinue = true;
        DialogueManager.intance.dialogos = thisDialogueRespuestaCorrectaUno;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
        yield return new WaitUntil(() => DialogueManager.intance.index >0);
        yield return new WaitUntil(() => DialogueManager.intance.index == 0);
        QuestionManager.intance.replies[thisQuestion.correctAnswer].jaja = 0;
        //yield return new WaitUntil(() => DialogueManager.intance.index >= DialogueManager.intance.dialogos.Count);

        cv.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        yield break;
    }
}

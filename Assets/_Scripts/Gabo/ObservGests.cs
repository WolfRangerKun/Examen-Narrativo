using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservGests : MonoBehaviour
{
    public GestObserv gestoObservable;
    public string descripcion;
    public List<Dialogue> siEsSituacionDialogue;
    public GameObject cv;
    public IEnumerator Situacion()
    {
        if (gestoObservable.clasifcationObserv ==GestObserv.OBSERVADO.Situacion)
        {
            cv.SetActive(true);
            PlayerMovementIsaac.instance.canMove = false;
            //thisDialogue.FindLast(x => x.dialogo == thisQuestion.question);
            DialogueManager.intance.dialogos = siEsSituacionDialogue;
            DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
            yield return new WaitUntil(() => DialogueManager.intance.index >= DialogueManager.intance.dialogos.Count - 1);
            yield return new WaitUntil(() => DialogueManager.intance.index == 0);
            cv.SetActive(false);
            PlayerMovementIsaac.instance.canMove = true;
        }
        else
        {
            yield break;
        }
    }

}

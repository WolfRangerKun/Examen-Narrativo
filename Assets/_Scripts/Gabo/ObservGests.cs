using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservGests : MonoBehaviour
{
    public GestObserv gestoObservable;
    public string descripcion;
    public List<Dialogue> siEsSituacionDialogue;
    public GameObject cv, vfxMira;
    public IEnumerator Situacion()
    {
        if (gestoObservable.clasifcationObserv == GestObserv.OBSERVADO.Situacion || gestoObservable.clasifcationObserv == GestObserv.OBSERVADO.Objeto || gestoObservable.clasifcationObserv == GestObserv.OBSERVADO.Gesto)
        {
            GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);

            vfxMira = GameObject.Find("Mira");
                vfxMira.SetActive(false);
            cv.SetActive(true);
            PlayerMovementIsaac.instance.canMove = false;
            //thisDialogue.FindLast(x => x.dialogo == thisQuestion.question);
            DialogueManager.intance.dialogos = siEsSituacionDialogue;
            DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
            if (DialogueManager.intance.dialogos[0].nombre == "Flaite Lider")
            {
                GameManager.instance.lastarriasOne = true;
            }
            yield return new WaitUntil(() => DialogueManager.intance.index >= DialogueManager.intance.dialogos.Count - 1);
            yield return new WaitUntil(() => DialogueManager.intance.index == 0);
            GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

            cv.SetActive(false);
            vfxMira.SetActive(true);

            //PlayerMovementIsaac.instance.canMove = true;
            yield break;

        }
        else
        {
            yield break;
        }
    }

}

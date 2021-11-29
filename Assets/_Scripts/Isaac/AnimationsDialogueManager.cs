using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsDialogueManager : MonoBehaviour
{
    public static AnimationsDialogueManager instance;
    public List<Dialogue> dialogoAnimationBienvenida, dialogoClearGarmando, dialogoClearGarmandoADormir;
    public List<AudioSource> audios;
    public GameObject cv, vsfHambre;
    public bool sceneOne;
    bool jaja1 = true;
    bool jaja2 = true;
    public static int lol;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (sceneOne)
        {
            StartCoroutine(DialogoBienvenidaSiagotan());

        }
        else
        {
            //ponerDollydeNivel e iniciar otra corrutina 
        }
    }

    public void ClearEtapaUno()
    {
        if (lol == 0)
        {
            print("kaka");
            StartCoroutine(DialogoClearGarmandoCity());
            lol = 1;
        }
    }

    public void ClearEtapaUnoNOCHE()
    {
        if (jaja1)
        {
            StartCoroutine(DialogoClearGarmandoCityDORMIR());
            jaja1 = true;
        }

    }

    public IEnumerator DialogoBienvenidaSiagotan()
    {
        cv.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        DialogueManager.intance.dialogos = dialogoAnimationBienvenida;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
        

        yield return new WaitUntil(() => DialogueManager.intance.index > 2);
        PlayerMovementIsaac.instance.sprite.GetComponent<Animator>().SetBool("IsTalking", false);

        DialogueManager.intance.canContinue = false;
        DialogueManager.intance.HideDialogo();
        yield return new WaitForSeconds(.8f);
        audios[0].Play();
        vsfHambre.SetActive(true);
        yield return new WaitForSeconds(2);
        vsfHambre.SetActive(false);
        yield return new WaitForSeconds(2);

        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[3]);
        DialogueManager.intance.canContinue = true;

        yield return new WaitUntil(() => DialogueManager.intance.index > 0);
        yield return new WaitUntil(() => DialogueManager.intance.index == 0);

        cv.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        yield break;

    }

    public IEnumerator DialogoClearGarmandoCity()
    {
        cv.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        DialogueManager.intance.dialogos = dialogoClearGarmando;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);

        yield return new WaitUntil(() => DialogueManager.intance.index > 0);
        yield return new WaitUntil(() => DialogueManager.intance.index == 0);

        cv.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        yield break;

    }

    public IEnumerator DialogoClearGarmandoCityDORMIR()
    {
        cv.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        DialogueManager.intance.dialogos = dialogoClearGarmandoADormir;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
        yield return new WaitUntil(() => DialogueManager.intance.index > 2);

        yield return new WaitUntil(() => DialogueManager.intance.index > 0);
        yield return new WaitUntil(() => DialogueManager.intance.index == 0);
        print("TerminasteELNivel");
        cv.SetActive(false);
        yield break;

    }


}

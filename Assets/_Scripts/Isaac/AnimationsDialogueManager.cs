using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationsDialogueManager : MonoBehaviour
{
    public static AnimationsDialogueManager instance;
    public List<Dialogue> dialogoAnimationBienvenida, dialogoClearGarmando, dialogoClearGarmandoADormir;
    public List<AudioSource> audios;
    public GameObject cv,cv2,cvDolly, vsfHambre, winTrigger;
    public DialogueManager dM;
    public bool sceneOne;
    private void Awake()
    {
        instance = this;
        dM = FindObjectOfType<DialogueManager>();
    }
    private void Start()
    {
        if (sceneOne)
        {
            StartCoroutine(DialogoBienvenidaSiagotan());
        }
        else
        {
            StartCoroutine(DialogoEntradaLastarrias());

        }
    }

   
   
    public IEnumerator DialogoBienvenidaSiagotan()
    {
        Transparencia.intance.modo = Transparencia.MODO.HIDE;
        yield return new WaitForSeconds(.6f);
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);

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
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

        cv.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        yield break;

    }

    public IEnumerator DialogoEntradaLastarrias()
    {
        PlayerMovementIsaac.instance.canMove = false;
        //Dollyprimero y despues dialogo.
        yield return new WaitForSeconds(16.7f);

        Transparencia.intance.modo = Transparencia.MODO.SHOW;
        yield return new WaitForSeconds(2f);
        cvDolly.SetActive(false);
        //Cambio de camara
        yield return new WaitForSeconds(1f);

        Transparencia.intance.modo = Transparencia.MODO.HIDE;
        yield return new WaitForSeconds(2f);
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);

        cv.SetActive(true);
        dM.dialogos = dialogoAnimationBienvenida;
        dM.ShowDialogo(DialogueManager.intance.dialogos[0]);
        yield return new WaitUntil(() => dM.index > 0);

        yield return new WaitUntil(() => dM.index == 0);

        cv.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

        yield break;

    }

    public IEnumerator DialogoClearGarmandoCity()
    {
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);

        cv.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        dM.dialogos = dialogoClearGarmando;
        dM.ShowDialogo(DialogueManager.intance.dialogos[0]);
        yield return new WaitUntil(() => dM.index > 0);

        yield return new WaitUntil(() => dM.index == 0);

        cv.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

        winTrigger.SetActive(false);

        yield break;

    }

    public IEnumerator DialogoClearGarmandoCityDORMIR()
    {
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);

        cv.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        DialogueManager.intance.dialogos = dialogoClearGarmandoADormir;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);

        yield return new WaitUntil(() => DialogueManager.intance.index > 0);
        yield return new WaitUntil(() => DialogueManager.intance.index == 0);
        print("TerminasteELNivel");
        Transparencia.intance.modo = Transparencia.MODO.SHOW;

        GameManager.instance.StartFade(GameManager.instance.bgm, 3, .01f);
        yield return new WaitForSeconds(2.1f);
        cv.SetActive(false);
        SceneManager.LoadScene(2);
        yield break;

    }

    public IEnumerator DialogoLastarriaSospecha()
    {
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);

        cv2.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        dM.dialogos = dialogoClearGarmando;
        dM.ShowDialogo(DialogueManager.intance.dialogos[0]);
        yield return new WaitUntil(() => dM.index > 0);

        yield return new WaitUntil(() => dM.index == 0);

        cv2.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

        winTrigger.SetActive(false);

        yield break;

    }

    public IEnumerator DialogoLastarriaMiedo()
    {
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);

        cv2.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        dM.dialogos = dialogoClearGarmandoADormir;
        dM.ShowDialogo(DialogueManager.intance.dialogos[0]);
        yield return new WaitUntil(() => dM.index > 0);

        yield return new WaitUntil(() => dM.index == 0);

        cv2.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

        winTrigger.SetActive(false);

        yield break;

    }
}

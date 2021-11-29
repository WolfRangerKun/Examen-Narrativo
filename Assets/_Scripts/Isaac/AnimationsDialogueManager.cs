using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsDialogueManager : MonoBehaviour
{
    public List<Dialogue> dialogoAnimationBienvenida, dialogoIntroTutorial;
    public List<AudioSource> audios;
    public GameObject cv, vsfHambre;
    private void Start()
    {
        StartCoroutine(DialogoBienvenidaSiagotan());
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

   
   

}

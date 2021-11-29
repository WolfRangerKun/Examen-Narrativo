using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsDialogueManager : MonoBehaviour
{
    public List<Dialogue> dialogoAnimationBienvenida;
    public List<AudioSource> audios;
    public GameObject cv;
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
        //DialogueManager.intance.TalkinAnimation();


        //yield return new WaitUntil(() => DialogueManager.intance.index == 1);

        //DialogueManager.intance.TalkinAnimation();

        //yield return new WaitUntil(() => DialogueManager.intance.index == 2);
        //DialogueManager.intance.TalkinAnimation();


        yield return new WaitUntil(() => DialogueManager.intance.index > 2);
        PlayerMovementIsaac.instance.sprite.GetComponent<Animator>().SetBool("IsTalking", false);

        DialogueManager.intance.canContinue = false;
        DialogueManager.intance.HideDialogo();
        yield return new WaitForSeconds(2);
        audios[0].Play();
        yield return new WaitForSeconds(4);
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[3]);
        DialogueManager.intance.canContinue = true;
        //DialogueManager.intance.TalkinAnimation();


        //yield return new WaitUntil(() => DialogueManager.intance.index == 4);
        //DialogueManager.intance.TalkinAnimation();

        //yield return new WaitUntil(() => DialogueManager.intance.index == 5);
        //DialogueManager.intance.TalkinAnimation();


        yield return new WaitUntil(() => DialogueManager.intance.index > 0);
        yield return new WaitUntil(() => DialogueManager.intance.index == 0);

        cv.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        yield break;


    }
}

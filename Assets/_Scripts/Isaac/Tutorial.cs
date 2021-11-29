using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    public List<Dialogue> dialogoAnimationBienvenida;
    public GameObject cv, tutorial;
    public Transform posInicio,posFinal,panelTutorial1, panelTutorial2,panelTutorial3, panelTutorial4;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TutorialJuego());
        }
    }
    bool canCon;
   
    public IEnumerator TutorialJuego()
    {
        cv.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        DialogueManager.intance.dialogos = dialogoAnimationBienvenida;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);


        //yield return new WaitUntil(() => DialogueManager.intance.index > 2);
        //PlayerMovementIsaac.instance.sprite.GetComponent<Animator>().SetBool("IsTalking", false);

        //DialogueManager.intance.canContinue = false;
        //DialogueManager.intance.HideDialogo();
        //yield return new WaitForSeconds(.8f);
        //audios[0].Play();
        //yield return new WaitForSeconds(4);
        //DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[3]);
        //DialogueManager.intance.canContinue = true;

        yield return new WaitUntil(() => DialogueManager.intance.index > 0);
        yield return new WaitUntil(() => DialogueManager.intance.index == 0);
        cv.SetActive(false);
        StartCoroutine(VolumeManager.instance.LiseningFiltroIn());
        panelTutorial1.gameObject.SetActive(true);
        tutorial.transform.DOMove(posFinal.position, 1f);
        yield return new WaitForSeconds(1.5f);
        canCon = true;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && canCon);
        canCon = false;
        StartCoroutine(CanCo());
        panelTutorial1.gameObject.SetActive(false);

        panelTutorial2.gameObject.SetActive(true);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && canCon);
        canCon = false;
        StartCoroutine(CanCo());
        panelTutorial2.gameObject.SetActive(false);

        panelTutorial3.gameObject.SetActive(true);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && canCon);
        canCon = false;
        StartCoroutine(CanCo());
        panelTutorial3.gameObject.SetActive(false);

        panelTutorial4.gameObject.SetActive(true);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && canCon);
        
        tutorial.transform.DOMove(posInicio.position, 1f);

        StartCoroutine(VolumeManager.instance.LiseningFiltroOut());
        yield return new WaitForSeconds(1.5f);


        cv.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        gameObject.SetActive(false);
        yield break;

    }

    IEnumerator CanCo()
    {
        yield return new WaitForSeconds(1);
        canCon = true;
        yield break;
    }

}

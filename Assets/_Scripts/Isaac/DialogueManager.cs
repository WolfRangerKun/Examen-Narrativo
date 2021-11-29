using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Dialogue
{
    public string nombre;
    public string dialogo;
    public Texture retrato;
}


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager intance;
    public List<Dialogue> dialogos;
    public TextMeshProUGUI dialogoText;
    public TextMeshProUGUI nombre;
    public RawImage portrait;
    public int index;
    public List<GameObject> personajesParaAnimTalk;

    public RectTransform dialogoPanel, puntoGuia;
    private Vector2 originalPos;

    bool dialogueOn;
    public bool canContinue = true;
    private void Awake()
    {
        intance = this;
    }

    private void Start()
    {
        originalPos = dialogoPanel.position;
        //ShowDialogo(dialogos[0]);

    }

    public void ShowDialogo(Dialogue dialogue)
    {
        StopAllCoroutines();
        dialogoText.text = "";
        dialogoPanel.DOMove(puntoGuia.position, .5f);
        nombre.text = dialogue.nombre;
        StartCoroutine(LetrasDeAPoco());
        TalkinAnimation();

        //dialogoText.text = dialogue.dialogo;
        //portrait.texture = dialogue.retrato;
        //portrait.SetNativeSize();
        dialogueOn = true;

        IEnumerator LetrasDeAPoco()
        {
            //yield return new WaitUntil(() => Transparencia.intance.transparencia >= .5f);
            foreach (char caracter in dialogue.dialogo)
            {
                dialogoText.text = dialogoText.text + caracter;
                yield return new WaitForSeconds(.05f);

            }
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueOn&& canContinue)
        {

            NextDialgogue();
        }

    }

    public void NextDialgogue()
    {
        if (dialogoText.text != dialogos[index].dialogo)
        {
            StopAllCoroutines();
            StopAnimationTalking();

            dialogoText.text = dialogos[index].dialogo;
        }
        else
        {
            StopAllCoroutines();
            StopAnimationTalking();
            index++;
            if (index >= dialogos.Count)
            {

                //StartCoroutine(HideDialogoCorrutina());

                HideDialogo();

                index = 0;

                //termina dialogo
            }
            else
            {
                ShowDialogo(dialogos[index]);
                TalkinAnimation();

            }
        }

    }

    public void HideDialogo()
    {
        dialogueOn = false;
        dialogoText.text = "";
        dialogoPanel.DOMove(originalPos, .5f);
    }

    public IEnumerator ShowDialogoCorrutina()
    {
        Transparencia.intance.modo = Transparencia.MODO.SHOW;
        yield return new WaitForSeconds(.7f);
        ShowDialogo(dialogos[index]);
    }

    public IEnumerator HideDialogoCorrutina()
    {
        HideDialogo();
        yield return new WaitForSeconds(.7f);
        Transparencia.intance.modo = Transparencia.MODO.HIDE;
    }

    public void TalkinAnimation()
    {

        switch (dialogos[index].nombre)
        {
            case "Garmando":
                PlayerMovementIsaac.instance.sprite.GetComponent<Animator>().SetBool("IsTalking", true);
                break;
            case "Dueño de Almacen":
                personajesParaAnimTalk[0].GetComponent<Animator>().SetBool("IsTalking", true);
                break;
            case "Eduardo":
                personajesParaAnimTalk[1].GetComponent<Animator>().SetBool("IsTalking", true);
                break;
            case "Benjamín":
                personajesParaAnimTalk[2].GetComponent<Animator>().SetBool("IsTalking", true);
                break;
        }


    }

    public void StopAnimationTalking()
    {
        switch (dialogos[index].nombre)
        {
            case "Garmando":
                PlayerMovementIsaac.instance.sprite.GetComponent<Animator>().SetBool("IsTalking", false);
                break;
            case "Dueño de Almacen":
                personajesParaAnimTalk[0].GetComponent<Animator>().SetBool("IsTalking", false);
                break;
            case "Eduardo":
                personajesParaAnimTalk[1].GetComponent<Animator>().SetBool("IsTalking", false);
                break;
            case "Benjamín":
                personajesParaAnimTalk[2].GetComponent<Animator>().SetBool("IsTalking", false);
                break;
        }
    }

    
}

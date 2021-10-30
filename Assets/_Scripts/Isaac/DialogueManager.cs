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


    public RectTransform dialogoPanel, puntoGuia;
    private Vector2 originalPos;

    bool dialogueOn;

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
        dialogoText.text = "";
        dialogoPanel.DOMove(puntoGuia.position, .5f);
        nombre.text = dialogue.nombre;
        StartCoroutine(LetrasDeAPoco());
        //dialogoText.text = dialogue.dialogo;
        portrait.texture = dialogue.retrato;
        //portrait.SetNativeSize();
        dialogueOn = true;

        IEnumerator LetrasDeAPoco()
        {
            yield return new WaitUntil(() => Transparencia.intance.transparencia >= .5f);
            foreach (char caracter in dialogue.dialogo)
            {
                dialogoText.text = dialogoText.text + caracter;
                yield return new WaitForSeconds(.05f);

            }
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueOn)
        {
            NextDialgogue();
        }

    }

    public void NextDialgogue()
    {
        if (dialogoText.text != dialogos[index].dialogo)
        {
            StopAllCoroutines();
            dialogoText.text = dialogos[index].dialogo;
        }
        else
        {
            StopAllCoroutines();
            index++;
            if (index >= dialogos.Count)
            {

                StartCoroutine(HideDialogoCorrutina());
                index = 0;
                //termina dialogo
            }
            else
            {

                ShowDialogo(dialogos[index]);
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



    private void OnTriggerEnter2D(Collider2D other)
    {


        //ShowDialogo(0);

    }

    //private void OnTriggerExit(Collider other)
    //{
    //    HideDialogo();
    //}
}

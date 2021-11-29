using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using System.Linq;
[System.Serializable]

public enum SignificadosWeons
{
    Amigo,
    Tonto

}
public class NpcGenericInteractionDialogue : MonoBehaviour
{
    public SignificadosWeons sigWeon;


    public List<Dialogue> thisDialogue;
    public GameObject cv, textoPopUp;
    bool canTalk;
    private void Update()
    {
        if (canTalk && Input.GetMouseButtonDown(0))
        {
            PlayDialogue();
            textoPopUp.SetActive(false);
            canTalk = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = true;
            textoPopUp.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = false;
            textoPopUp.SetActive(false);

        }
    }

    void PlayDialogue()
    {
        ReemplazarPalabra();
        cv.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        DialogueManager.intance.dialogos = thisDialogue;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
        StartCoroutine(ShowDialogue());
    }
    void ReemplazarPalabra()
    {
        foreach (Dialogue d in thisDialogue)
        {
            string fraseOrginial = d.dialogo;

            foreach (string z in Libreta.instance.notasPalabras)
            {

                
                if (fraseOrginial.Contains(z) && z != "Weon")
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
                    d.dialogo = nuevaFrase;
                }

                if (fraseOrginial.Contains(z) && z == "Weon")
                {
                    string palabraBuena = "";
                    for (int i = 0; i < Libreta.instance.notasPalabras.Count; i++)
                    {
                        if (Libreta.instance.notasPalabras[i] == z)
                        {
                            ////solo funciona si la lista tiene un significado solamente
                            for (int e = 0; e < Libreta.instance.sigPalabras[i].significados.Count; e++)
                            {
                                if (Libreta.instance.sigPalabras[i].significados[e] == sigWeon.ToString())
                                {
                                    palabraBuena = Libreta.instance.sigPalabras[i].significados[e];
                                    string nuevaFrase = fraseOrginial.Replace(z, palabraBuena);
                                    d.dialogo = nuevaFrase;
                                }
                            }
                        }
                    }

                }
            }
            foreach (var o in Libreta.instance.cosasObservadas)
            {
                string fraseOrginialDos = d.dialogo;

                if (fraseOrginialDos.Contains(o.context[0]))
                {
                    string palabraBuena = "";
                    for (int i = 0; i < Libreta.instance.cosasObservadas.Count; i++)
                    {
                        if (Libreta.instance.cosasObservadas[i] == o)
                        {

                            palabraBuena = Libreta.instance.notasObservaciones[i];
                        }
                    }
                    string nuevaFrase = fraseOrginialDos.Replace(o.context[0], palabraBuena);
                    d.dialogo = nuevaFrase;
                }
            }
        }
    }

    IEnumerator ShowDialogue()
    {
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);


        yield return new WaitUntil(() => DialogueManager.intance.index > 0);
        yield return new WaitUntil(() => DialogueManager.intance.index == 0);
        //QuestionManager.intance.replies[thisQuestion.correctAnswer].jaja = 0;
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

        cv.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
        yield break;
    }

   
}

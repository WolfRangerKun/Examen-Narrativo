using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
//using System.Linq;

[System.Serializable]
public enum SwitchTextos
{
    RESPUESTAUNO = 0,
    RESPUESTADOS = 1,
    RESPUESTATRES = 2
}

public enum SignificadosWeon
{
    Amigo,
    Tonto

}
public class InteraccionNPC : MonoBehaviour
{
    public SwitchTextos switchTextos;
    public SignificadosWeon sigWeon;
    public string singinificadoParaDesbloquear;
    //public string observacionParaDesbloquear;


    public Question thisQuestion;
    public List<Dialogue> thisDialogue, dialogueUno, dialogueDos, dialogueTres, dialogoDesbloqueoConPalabra, dialogoDesbloqueoConObservacion;
    public GameObject cv, textoPopUp;
    public GameObject flaite , cubo;
    bool yaDesbloqueo, isDialogoPalabra;
    int l;
    bool canTalk;
    private void Start()
    {
        if (GameObject.Find("Sprite Flaite Principal"))
        {
            flaite = GameObject.Find("Sprite Flaite Principal");

        }
        if (GameObject.Find("CubexD"))
        {
            cubo = GameObject.Find("CubexD");

        }


    }
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
        //thisDialogue.FindLast(x => x.dialogo == thisQuestion.question);
        int x = thisDialogue.Count;
        thisDialogue[x - 1].dialogo = thisQuestion.question;
        if (!yaDesbloqueo)
        {
            DialogueManager.intance.dialogos = thisDialogue;
        }
        else
        {
            if (isDialogoPalabra)
            {
                DialogueManager.intance.dialogos = dialogoDesbloqueoConPalabra;

            }
            else
            {
                DialogueManager.intance.dialogos = dialogoDesbloqueoConObservacion;

            }
        }
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
        StartCoroutine(ShowDialogue());
        //thisDialogue.dialogo
    }
    void ReemplazarPalabra()
    {
        #region Parapregunta
        //Para Pregunta

        foreach (string z in Libreta.instance.notasPalabras)
        {
            string fraseOrginial = thisQuestion.question;
            #region CodigoGabo
            //if (fraseOrginial.Contains(z))
            //{
            //    string palabraBuena = "";
            //    for (int i = 0; i < Libreta.instance.notasPalabras.Count; i++)
            //    {
            //        if (Libreta.instance.notasPalabras[i] == z)
            //        {
            //            ////solo funciona si la lista tiene un significado solamente
            //            for (int e = 0; e < Libreta.instance.sigPalabras[i].significados.Count; e++)
            //            {
            //                if (Libreta.instance.sigPalabras[i].significados[e] == palabaSearch)
            //                {
            //                    palabraBuena = palabaSearch;
            //                    Debug.Log("funciona la wea del weon weon weon weon weon");
            //                    string nuevaFrase = fraseOrginial.Replace(z, palabraBuena);
            //                    thisQuestion.question = nuevaFrase;
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion
            if (fraseOrginial.Contains(z) && z != "Weon")
            {
                string palabraBuena = "";
                for (int i = 0; i < Libreta.instance.notasPalabras.Count; i++)
                {
                    if (Libreta.instance.notasPalabras[i] == z)
                    {

                        palabraBuena = Libreta.instance.sigPalabras[i].significados[0];
                    }
                }
                string nuevaFrase = fraseOrginial.Replace(z, palabraBuena);
                thisQuestion.question = nuevaFrase;
            }

            if (fraseOrginial.Contains(z) && z == "Weon")
            {
                string palabraBuena = "";
                for (int i = 0; i < Libreta.instance.notasPalabras.Count; i++)
                {
                    if (Libreta.instance.notasPalabras[i] == z)
                    {
                        for (int e = 0; e < Libreta.instance.sigPalabras[i].significados.Count; e++)
                        {
                            if (Libreta.instance.sigPalabras[i].significados[e] == sigWeon.ToString())
                            {
                                palabraBuena = Libreta.instance.sigPalabras[i].significados[e];
                                string nuevaFrase = fraseOrginial.Replace(z, palabraBuena);
                                thisQuestion.question = nuevaFrase;
                            }
                        }
                    }
                }

            }
           
        }
        foreach (var o in Libreta.instance.cosasObservadas)
        {
            string fraseOrginialDos = thisQuestion.question;

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
                thisQuestion.question = nuevaFrase;
            }
        }
        #endregion
        #region ParaDialogos
        foreach (Dialogue d in thisDialogue)
        {
            string fraseOrginial = d.dialogo;

            foreach (string z in Libreta.instance.notasPalabras)
            {

                #region CodigoGabo
                //if (fraseOrginial.Contains(z))
                //{
                //    string palabraBuena = "";
                //    for (int i = 0; i < Libreta.instance.notasPalabras.Count; i++)
                //    {
                //        if (Libreta.instance.notasPalabras[i] == z)
                //        {
                //            ////solo funciona si la lista tiene un significado solamente
                //            for (int e = 0; e < Libreta.instance.sigPalabras[i].significados.Count; e++)
                //            {
                //                if (Libreta.instance.sigPalabras[i].significados[e] == palabaSearch)
                //                {
                //                    palabraBuena = palabaSearch;
                //                    Debug.Log("funciona la wea del weon weon weon weon weon");
                //                    string nuevaFrase = fraseOrginial.Replace(z, palabraBuena);
                //                    thisQuestion.question = nuevaFrase;
                //                }
                //            }
                //        }
                //    }
                //}
                #endregion
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
        foreach (Dialogue d in dialogueUno)
        {
            string fraseOrginial = d.dialogo;

            foreach (string z in Libreta.instance.notasPalabras)
            {

                #region CodigoGabo
                //if (fraseOrginial.Contains(z))
                //{
                //    string palabraBuena = "";
                //    for (int i = 0; i < Libreta.instance.notasPalabras.Count; i++)
                //    {
                //        if (Libreta.instance.notasPalabras[i] == z)
                //        {
                //            ////solo funciona si la lista tiene un significado solamente
                //            for (int e = 0; e < Libreta.instance.sigPalabras[i].significados.Count; e++)
                //            {
                //                if (Libreta.instance.sigPalabras[i].significados[e] == palabaSearch)
                //                {
                //                    palabraBuena = palabaSearch;
                //                    Debug.Log("funciona la wea del weon weon weon weon weon");
                //                    string nuevaFrase = fraseOrginial.Replace(z, palabraBuena);
                //                    thisQuestion.question = nuevaFrase;
                //                }
                //            }
                //        }
                //    }
                //}
                #endregion
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
        foreach (Dialogue d in dialogueDos)
        {
            string fraseOrginial = d.dialogo;

            foreach (string z in Libreta.instance.notasPalabras)
            {

                #region CodigoGabo
                //if (fraseOrginial.Contains(z))
                //{
                //    string palabraBuena = "";
                //    for (int i = 0; i < Libreta.instance.notasPalabras.Count; i++)
                //    {
                //        if (Libreta.instance.notasPalabras[i] == z)
                //        {
                //            ////solo funciona si la lista tiene un significado solamente
                //            for (int e = 0; e < Libreta.instance.sigPalabras[i].significados.Count; e++)
                //            {
                //                if (Libreta.instance.sigPalabras[i].significados[e] == palabaSearch)
                //                {
                //                    palabraBuena = palabaSearch;
                //                    Debug.Log("funciona la wea del weon weon weon weon weon");
                //                    string nuevaFrase = fraseOrginial.Replace(z, palabraBuena);
                //                    thisQuestion.question = nuevaFrase;
                //                }
                //            }
                //        }
                //    }
                //}
                #endregion
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
        foreach (Dialogue d in dialogueTres)
        {
            string fraseOrginial = d.dialogo;

            foreach (string z in Libreta.instance.notasPalabras)
            {

                #region CodigoGabo
                //if (fraseOrginial.Contains(z))
                //{
                //    string palabraBuena = "";
                //    for (int i = 0; i < Libreta.instance.notasPalabras.Count; i++)
                //    {
                //        if (Libreta.instance.notasPalabras[i] == z)
                //        {
                //            ////solo funciona si la lista tiene un significado solamente
                //            for (int e = 0; e < Libreta.instance.sigPalabras[i].significados.Count; e++)
                //            {
                //                if (Libreta.instance.sigPalabras[i].significados[e] == palabaSearch)
                //                {
                //                    palabraBuena = palabaSearch;
                //                    Debug.Log("funciona la wea del weon weon weon weon weon");
                //                    string nuevaFrase = fraseOrginial.Replace(z, palabraBuena);
                //                    thisQuestion.question = nuevaFrase;
                //                }
                //            }
                //        }
                //    }
                //}
                #endregion
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
        foreach (Dialogue d in dialogoDesbloqueoConPalabra)
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
        foreach (Dialogue d in dialogoDesbloqueoConObservacion)
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


        #endregion
        #region ParaRespuestaBotones
        for (int x = 0; x < thisQuestion.replies.Count; x++)
        {
            string fraseOrginial = thisQuestion.replies[x];

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
                    thisQuestion.replies[x] = nuevaFrase;
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
                                    thisQuestion.replies[x] = nuevaFrase;
                                }
                            }
                        }
                    }
                }
            }
            foreach (var o in Libreta.instance.cosasObservadas)
            {
                string fraseOrginialDos = thisQuestion.replies[x];

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
                    thisQuestion.replies[x] = nuevaFrase;
                }
            }
        }
        #endregion
    }

    int t;
    bool pasa;
    IEnumerator ShowDialogue()
    {
        GameManager.instance.StartFade(GameManager.instance.bgm, 1, .1f);


        int x = thisDialogue.Count;
        if (!yaDesbloqueo)
        {
            yield return new WaitUntil(() => DialogueManager.intance.index == x - 1);
            DialogueManager.intance.canContinue = false;
            QuestionManager.intance.ShowQuestion(thisQuestion);
            PlayerMovementIsaac.instance.MouseState();

            yield return new WaitWhile(() => QuestionManager.intance.replies.TrueForAll(x => x.jaja == 0));
            PlayerMovementIsaac.instance.MouseState();


            for (int i = 0; i < QuestionManager.intance.replies.Count; i++)
            {

                if (QuestionManager.intance.replies[i].jaja != 0)
                {
                    switchTextos = (SwitchTextos)i;


                    if (QuestionManager.intance.replies[i].GetComponentInChildren<TextMeshProUGUI>().text.Contains(singinificadoParaDesbloquear))
                    {
                        DialogueManager.intance.dialogos = dialogoDesbloqueoConPalabra;
                        isDialogoPalabra = true;
                        yaDesbloqueo = true;
                        pasa = true;
                    }
                    else
                    {
                        SwitchText();
                    }
                    for (int a = 0; a < Libreta.instance.cosasObservadas.Count; a++)
                    {
                        if (QuestionManager.intance.replies[i].GetComponentInChildren<TextMeshProUGUI>().text.Contains(Libreta.instance.notasObservaciones[a]) && !pasa)
                        {
                            DialogueManager.intance.dialogos = dialogoDesbloqueoConObservacion;
                            yaDesbloqueo = true;
                            if (QuestionManager.intance.replies[i].GetComponentInChildren<TextMeshProUGUI>().text == "Baile Flaite")
                            {
                                t++;
                            }

                            pasa = true;
                            print("Lologre");
                        }
                        else
                        {
                            if (!pasa)
                            {
                                SwitchText();
                            }
                        }
                    }
                    //foreach (var g in Libreta.instance.notasObservaciones)
                    //{
                    //    if (g == QuestionManager.intance.replies[i].GetComponentInChildren<TextMeshProUGUI>().text)
                    //    {
                    //        DialogueManager.intance.dialogos = dialogoDesbloqueo;
                    //        yaDesbloqueo = true;
                    //        l++;
                    //    }
                    //    else
                    //    {
                    //        SwitchText();

                    //    }
                    //}
                    QuestionManager.intance.replies[i].jaja = 0;
                }
            }

           

            QuestionManager.intance.botones.SetActive(false);
        }
       
        DialogueManager.intance.index = 0;

        DialogueManager.intance.canContinue = true;

        if (l == 0)
        {
            if ( !yaDesbloqueo)
            {
                DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
            }
            else
            {
                if (yaDesbloqueo)
                {
                    DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
                    if (DialogueManager.intance.dialogos[0].nombre == "Dueño de Almacen")
                    {
                        GameManager.instance.levelOneComplete = true;
                    }
                    if (DialogueManager.intance.dialogos[0].nombre == "Flaite Nro. 37")
                    {
                        print("completo");
                        GameManager.instance.lastarriaTwo = true;
                    }
                    l++;
                }
            }
        }
        yield return new WaitUntil(() => DialogueManager.intance.index > 0);
        yield return new WaitUntil(() => DialogueManager.intance.index == 0);
        //QuestionManager.intance.replies[thisQuestion.correctAnswer].jaja = 0;

        
        if (flaite != null && l == 1)
        {
            print("dotiwng");

            if (t ==1)
            {
                PlayerMovementIsaac.instance.sprite.GetComponent<Animator>().SetBool("Baile", true);
            }
            flaite.transform.DOMove(flaite.transform.position + new Vector3(4, 0, 0), 3);
            flaite.GetComponent<Animator>().SetBool("IsWalking", true);
            yield return new WaitForSeconds(3);
            flaite.GetComponent<Animator>().SetBool("IsWalking", false);
            PlayerMovementIsaac.instance.sprite.GetComponent<Animator>().SetBool("Baile", false);

            GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);
            flaite.GetComponentInParent<BoxCollider>().isTrigger = true;
            cubo.SetActive(false);
            cv.SetActive(false);
            PlayerMovementIsaac.instance.canMove = true;
        }
        else
        {
            GameManager.instance.StartFade(GameManager.instance.bgm, 1, .3f);

            cv.SetActive(false);
            PlayerMovementIsaac.instance.canMove = true;
        }
        yield break;
    }

    void SwitchText()
    {
        switch (switchTextos)
        {
            case SwitchTextos.RESPUESTAUNO:
                DialogueManager.intance.dialogos = dialogueUno;
                break;
            case SwitchTextos.RESPUESTADOS:
                DialogueManager.intance.dialogos = dialogueDos;
                break;
            case SwitchTextos.RESPUESTATRES:
                DialogueManager.intance.dialogos = dialogueTres;
                break;

        }
    }

   
}

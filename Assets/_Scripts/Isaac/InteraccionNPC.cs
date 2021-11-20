using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public Question thisQuestion;
    public List<Dialogue> thisDialogue, dialogueUno, dialogueDos, dialogueTres;
    public GameObject cv;
    //public string palabaSearch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayDialogue();
        }
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
                        ////solo funciona si la lista tiene un significado solamente

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
                        ////solo funciona si la lista tiene un significado solamente
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
        }
        #endregion
    }

    void PlayDialogue()
    {
        ReemplazarPalabra();
        cv.SetActive(true);
        PlayerMovementIsaac.instance.canMove = false;
        //thisDialogue.FindLast(x => x.dialogo == thisQuestion.question);
        int x = thisDialogue.Count;
        thisDialogue[x - 1].dialogo = thisQuestion.question;
        DialogueManager.intance.dialogos = thisDialogue;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
        StartCoroutine(ShowDialogue());
        //thisDialogue.dialogo
    }


    IEnumerator ShowDialogue()
    {
        int x = thisDialogue.Count;

        yield return new WaitUntil(() => DialogueManager.intance.index == x - 1);
        DialogueManager.intance.canContinue = false;
        QuestionManager.intance.ShowQuestion(thisQuestion);

        yield return new WaitWhile(() => QuestionManager.intance.replies.TrueForAll(x => x.jaja == 0));


        for (int i = 0; i < QuestionManager.intance.replies.Count; i++)
        {

            if (QuestionManager.intance.replies[i].jaja != 0)
            {
                switchTextos = (SwitchTextos)i;
                QuestionManager.intance.replies[i].jaja = 0;
            }
        }

        QuestionManager.intance.botones.SetActive(false);
        DialogueManager.intance.index = 0;

        DialogueManager.intance.canContinue = true;

        SwitchText();
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
        yield return new WaitUntil(() => DialogueManager.intance.index > 0);
        yield return new WaitUntil(() => DialogueManager.intance.index == 0);
        QuestionManager.intance.replies[thisQuestion.correctAnswer].jaja = 0;

        cv.SetActive(false);
        PlayerMovementIsaac.instance.canMove = true;
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

    //foreach (string z in Libreta.instance.notasPalabras)
    //    {
    //        if (fraseOrginial.Contains(z))
    //        {
    //            string palabraBuena = "";
    //            for (int i = 0; i < Libreta.instance.notasPalabras.Count; i++)
    //            {
    //                if (Libreta.instance.notasPalabras[i] == z)
    //                {
    //                    ////solo funciona si la lista tiene un significado solamente

    //                    palabraBuena = Libreta.instance.sigPalabras[i].significados[0];
    //                }
    //            }
    //            string nuevaFrase = fraseOrginial.Replace(z, palabraBuena);
    //            thisQuestion.question = nuevaFrase;
    //            return;
    //        }
    //    }
}

using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class SignificadosPalabras
{
    public List<string> significados;
}
[System.Serializable]
public class GestObserv
{
    public enum OBSERVADO
    {
        Gesto,
        Situacion,
        Objeto
    }
    public OBSERVADO clasifcationObserv;
    public List<string> context;
}

public class Libreta : MonoBehaviour
{
    public static Libreta instance;
    public List<string> notasPalabras;
    public List<string> notasObservaciones;
    public List<SignificadosPalabras> sigPalabras;
    public List<GestObserv> cosasObservadas;
    public Transform panelModismos, panelSig;
    public GameObject panelString;
    private void Awake()
    {
        instance = this;
    }

    

    public void CompararPalabras(string palabra, SignificadosPalabras sig)
    {
        if (!notasPalabras.Contains(palabra))
        {
            notasPalabras.Add(palabra);
            GameObject modismo = Instantiate(panelString, panelModismos);
            modismo.GetComponentInChildren<TextMeshProUGUI>().text = palabra;

            sigPalabras.Add(sig);
            GameObject significado = Instantiate(panelString, panelSig);
            significado.GetComponentInChildren<TextMeshProUGUI>().text = sig.significados[0];
        }
        else
        {
            for (int i = 0; i < notasPalabras.Count; i++)
            {
                if (notasPalabras[i] == palabra)
                {
                    SignificadosPalabras xd = sigPalabras[i];

                    if (!sigPalabras[i].significados.Contains(sig.significados[0]))
                    {
                        sigPalabras[i].significados.Add(sig.significados[0]);
                        GameObject significado = Instantiate(panelString, panelSig);
                        significado.GetComponentInChildren<TextMeshProUGUI>().text = sig.significados[0];
                    }
                    else
                    {
                        print("ya tengo esta palabra");
                    }
                }
            }
        }
    }

    public void RegisterGeturess(string gesture, GestObserv gesturAction)
    {
        if (!notasObservaciones.Contains(gesture))
        {
            notasObservaciones.Add(gesture);
            cosasObservadas.Add(gesturAction);
        }
        else
        {
            for(int i = 0; i < notasObservaciones.Count; i++)
            {
                if(notasObservaciones[1] == gesture)
                {
                    GestObserv a = cosasObservadas[i];
                    if (!cosasObservadas[i].context.Contains(gesturAction.context[0]))
                    {
                        cosasObservadas[i].context.Add(gesturAction.context[0]);
                    }
                    else
                    {
                        Debug.Log("ya analise su lenguaje corporal");
                    }
                }
            }
        }
    }
}

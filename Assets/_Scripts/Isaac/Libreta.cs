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
    public Transform panelModismos, panelSig,panelGest ,panelObs,panelSituacion,panelQueFueSituacion,panelObj,panelQueFueObj;
    public GameObject panelString;
    public List<GameObject> modLibreta, sigLibreta,gestLibreta ,obsLibreta,situLibreta, queFueSituLibreta, objeLibreta,queFueObjLibreta;

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
            modLibreta.Add(modismo);

            sigPalabras.Add(sig);
            GameObject significado = Instantiate(panelString, panelSig);
            significado.GetComponentInChildren<TextMeshProUGUI>().text = sig.significados[0];
            sigLibreta.Add(significado);

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
                        sigLibreta[i].GetComponentInChildren<TextMeshProUGUI>().text = sigLibreta[i].GetComponentInChildren<TextMeshProUGUI>().text + ", "+ sig.significados[0];

                        //GameObject significado = Instantiate(panelString, panelSig);
                        //significado.GetComponentInChildren<TextMeshProUGUI>().text = sig.significados[0];

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
            switch (gesturAction.clasifcationObserv)
            {
                case GestObserv.OBSERVADO.Gesto:
                    notasObservaciones.Add(gesture);
                    GameObject gesto = Instantiate(panelString, panelGest);
                    gesto.GetComponentInChildren<TextMeshProUGUI>().text = gesture;
                    gestLibreta.Add(gesto);

                    cosasObservadas.Add(gesturAction);
                    GameObject observacion = Instantiate(panelString, panelObs);
                    observacion.GetComponentInChildren<TextMeshProUGUI>().text = gesturAction.context[0];
                    obsLibreta.Add(observacion);
                    break;
                case GestObserv.OBSERVADO.Situacion:
                    notasObservaciones.Add(gesture);
                    GameObject situaicon = Instantiate(panelString, panelQueFueSituacion);
                    situaicon.GetComponentInChildren<TextMeshProUGUI>().text = gesture;
                    situLibreta.Add(situaicon);

                    cosasObservadas.Add(gesturAction);
                    GameObject obser = Instantiate(panelString, panelSituacion);
                    obser.GetComponentInChildren<TextMeshProUGUI>().text = gesturAction.context[0];
                    queFueSituLibreta.Add(obser);
                    break;
                case GestObserv.OBSERVADO.Objeto:
                    notasObservaciones.Add(gesture);
                    GameObject obj = Instantiate(panelString, panelQueFueObj);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = gesture;
                    objeLibreta.Add(obj);

                    cosasObservadas.Add(gesturAction);
                    GameObject obsers = Instantiate(panelString, panelObj);
                    obsers.GetComponentInChildren<TextMeshProUGUI>().text = gesturAction.context[0];
                    queFueObjLibreta.Add(obsers);
                    break;
              
            }
            
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
                        switch (gesturAction.clasifcationObserv)
                        {
                            case GestObserv.OBSERVADO.Gesto:
                                cosasObservadas[i].context.Add(gesturAction.context[0]);
                                obsLibreta[i].GetComponentInChildren<TextMeshProUGUI>().text = obsLibreta[i].GetComponentInChildren<TextMeshProUGUI>().text + ", " + gesturAction.context[0];
                                break;
                            case GestObserv.OBSERVADO.Situacion:
                                cosasObservadas[i].context.Add(gesturAction.context[0]);
                                queFueSituLibreta[i].GetComponentInChildren<TextMeshProUGUI>().text = queFueSituLibreta[i].GetComponentInChildren<TextMeshProUGUI>().text + ", " + gesturAction.context[0];
                                break;
                            case GestObserv.OBSERVADO.Objeto:
                                cosasObservadas[i].context.Add(gesturAction.context[0]);
                                queFueObjLibreta[i].GetComponentInChildren<TextMeshProUGUI>().text = queFueObjLibreta[i].GetComponentInChildren<TextMeshProUGUI>().text + ", " + gesturAction.context[0];
                                break;
                        }

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

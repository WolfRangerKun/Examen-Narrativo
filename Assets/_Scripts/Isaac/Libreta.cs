using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SignificadosPalabras
{
    public List<string> significados;
}

public class Libreta : MonoBehaviour
{
    public static Libreta instance;
    public List<string> notasPalabras;
    public List<SignificadosPalabras> sigPalabras;
    private void Awake()
    {
        instance = this;
    }


    public void CompararPalabras(string palabra, SignificadosPalabras sig)
    {
        if (!notasPalabras.Contains(palabra))
        {
            notasPalabras.Add(palabra);
            sigPalabras.Add(sig);
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
                    }
                    else
                    {
                        print("ya tengo esta palabra");
                    }
                }
            }
        }
    }
}

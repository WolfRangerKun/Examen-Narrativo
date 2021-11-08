using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class SignificadosPalabras
{
    public List<string> significadosDePalabra;
}

public class Libreta : MonoBehaviour
{
    public static Libreta instance;
    public List<string> notasPalabras;
    public List<SignificadosPalabras> sigPalabras;
    string jaja;
    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
        }
    }


    public void CompararPalabras(string palabra, string significado)
    {
        SignificadosPalabras thiSig = new SignificadosPalabras();

        if (!notasPalabras.Contains(palabra))
        {
            notasPalabras.Add(palabra);
            sigPalabras.Add(thiSig);

                for (int i = 0; i < notasPalabras.Count; i++)
                {
                    if (notasPalabras[i] == palabra)
                    {
                        string newWord = jaja;
                        sigPalabras[i].significadosDePalabra.Add(newWord);
                    }
                }
            
        }
        //sigPalabras[notasPalabras.Find(x => x.Contains(palabra))]
        //notasPalabras.Find(x => x.Contains(palabra));
        //notasPalabras.Find(x => x == palabra);

        //sigPalabras.Find(x => x == sigPalabras.Last()).significadosDePalabra.Add(significado);
        //sigPalabras.FindLast(x => x == thiSig).significadosDePalabra.Add(significado);






        //thiSig.significadosDePalabra.Add(significado);

    }

}

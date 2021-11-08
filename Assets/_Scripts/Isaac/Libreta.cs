using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Libreta : MonoBehaviour
{
    public static Libreta instance;
    public List<string> notasPalabras;
    private void Awake()
    {
        instance = this;
    }

   
}

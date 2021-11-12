using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reply : MonoBehaviour
{
    public bool isCorrect;
    public bool isFirts, isSecond;
    public GameObject panelPregunta;
    public void ReplyQuestion()
    {
        if (isCorrect)
        {
            panelPregunta.SetActive(false);
           
        }
        else
        {

        }
    }
}

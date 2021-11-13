using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reply : MonoBehaviour
{
    public bool isCorrect;
    public int jaja;
    public void ReplyQuestion()
    {
        if (isCorrect)
        {
            jaja++;
        }
        else
        {

        }
    }
}

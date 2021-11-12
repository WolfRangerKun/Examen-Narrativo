using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[System.Serializable]
public class Question
{
    public string question;
    public int correctAnswer;
    public List<string> replies;
}
public class QuestionManager : MonoBehaviour
{
    public static QuestionManager intance;
    public List<Question> questions;
    public TextMeshProUGUI question, reply1, reply2, reply3;
    public List<Reply> replies;

    private void Awake()
    {
        intance = this;
    }
    

    public void CallQuestion(int i)
    {

        question.text = questions[i].question;
        reply1.text = questions[i].replies[0];
        reply2.text = questions[i].replies[1];
        reply3.text = questions[i].replies[2];
        replies[questions[i].correctAnswer].isCorrect = true;
    }
}

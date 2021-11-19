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
    public TextMeshProUGUI questionD, reply1, reply2, reply3;
    public List<Reply> replies;
    public GameObject botones;
    private void Awake()
    {
        intance = this;
    }
    

    public void CallQuestion(int i)
    {
        questionD.text = questions[i].question;
        reply1.text = questions[i].replies[0];
        reply2.text = questions[i].replies[1];
        reply3.text = questions[i].replies[2];
        //replies[questions[i].correctAnswer].isCorrect = true;
    }

    public void ShowQuestion(Question question)
    {
        botones.SetActive(true);
        DialogueManager.intance.StopAllCoroutines();
        questionD.text = "";
        questionD.text = question.question;

        reply1.text = question.replies[0];
        reply2.text = question.replies[1];
        reply3.text = question.replies[2];
        //replies[question.correctAnswer].isCorrect = true;
    }
}

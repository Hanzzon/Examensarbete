using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionList {

    public int id;
    public string question;
    public string answer;
    public int attempt;

    public QuestionList(int id, string question, string answer, int attempt)
    {
        this.id = id;
        this.question = question;
        this.answer = answer;
        this.attempt = attempt;
    }
}

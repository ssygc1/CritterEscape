using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeClue : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDisplay;

    [SerializeField]
    private string[] questions;

    [SerializeField]
    private int currentQuestionIndex = 0;

    private void Start()
    {
        UpdateQuestion();
    }

    public void UpdateQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            textDisplay.text = questions[currentQuestionIndex];
            currentQuestionIndex++;
        }
        else
        {
            textDisplay.text = "Ring on this side is ready.";
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotatePlate : MonoBehaviour
{
    [SerializeField]
    private GameObject[] icons;

    [SerializeField]
    private int[] correctAnswerIndexes;

    [SerializeField]
    private int currentIndex;

    [SerializeField]
    private int currentQuestion;

    [SerializeField]
    private UnityEvent onCorrectAnswers;

    [SerializeField]
    private UnityEvent onIncorrectAnswers;

    [SerializeField]
    private UnityEvent onAllQuestionSolved;

    public Transform ringTransform;
    public float rotationSpeed = 3.0f;
    private Quaternion targetRotation;


    private void Update()
    {
        ringTransform.rotation = Quaternion.Slerp(ringTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void RotateRight()
    {
        targetRotation = ringTransform.rotation;
        currentIndex = (currentIndex + 1) % icons.Length;
        targetRotation *= Quaternion.Euler(72, 0, 0);
    }

    public void RotateLeft()
    {
        targetRotation = ringTransform.rotation;
        currentIndex = (currentIndex - 1 + icons.Length) % icons.Length;
        targetRotation *= Quaternion.Euler(-72, 0, 0);
    }

    public void ConfirmSelection()
    {
        if (currentQuestion < correctAnswerIndexes.Length && currentIndex == correctAnswerIndexes[currentQuestion])
        {
            onCorrectAnswers?.Invoke();

            currentQuestion++;

            if (currentQuestion == correctAnswerIndexes.Length)
            {
                onAllQuestionSolved?.Invoke();
            }
        }
        else
        {
           
            onIncorrectAnswers?.Invoke();
        }
    }
}

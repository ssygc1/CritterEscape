using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class Cauldron : MonoBehaviour
{
    [Header("Values")]
    [Tooltip("Target value of pot")]
    [SerializeField]
    public int targetValue;

    [Tooltip("Current value of the pot")]
    [SerializeField]
    private int currentValue = 0;

    [Tooltip("Chest lid to open")]
    public UnityEvent onPotionsCorrect;
    public UnityEvent onPotionsIncorrect;
    public  bool isCompleted = false;
    
    public TMP_Text text;

    public void AddBottleValueToPot(int value)
    {
        currentValue += value;
        text.text = currentValue.ToString();

        if (currentValue >= targetValue)
        {
            Confirm();
        }
    }
    
    public void removeBottleValueToPot(int value)
    {
        currentValue -= value;
        text.text = currentValue.ToString();
    }

    public void ResetCauldron()
    {
        currentValue = 0;
    }
    
    public void Confirm()
    {
        if (currentValue == targetValue)
        {
            Debug.Log("Potion successfully matched the target value");
            onPotionsCorrect?.Invoke();
            isCompleted = true;
        }
        else if (currentValue > targetValue)
        {
            Debug.Log("Potion exceeded the target value");
            onPotionsIncorrect?.Invoke();
        }
    }

    
}

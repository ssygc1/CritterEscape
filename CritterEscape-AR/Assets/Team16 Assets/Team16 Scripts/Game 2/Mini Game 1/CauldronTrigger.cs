using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CauldronTrigger : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference of parent cauldron")]
    private Cauldron cauldron;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit; 

    private List<Potion> addedPotions = new List<Potion>();  // List to store already added potions

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potion"))
        {
            Potion potion = other.GetComponent<Potion>();

            if (potion != null && !addedPotions.Contains(potion))  // Check if the potion is already in the list
            {
                cauldron.AddBottleValueToPot(potion.value);
                onTriggerEnter.Invoke();
                addedPotions.Add(potion);  // Add the potion to the list after it's added
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Potion"))
        {
            Potion potion = other.GetComponent<Potion>();

            if (potion != null && addedPotions.Contains(potion))  // Check if this potion is in the added potions list
            {
                Debug.Log("The potion is leaving");
                cauldron.removeBottleValueToPot(potion.value);
                addedPotions.Remove(potion);
                onTriggerExit.Invoke();  // 可触发事件
            }
        }
    }

    public void ResetCollider()
    {
        addedPotions.Clear();
    }
}
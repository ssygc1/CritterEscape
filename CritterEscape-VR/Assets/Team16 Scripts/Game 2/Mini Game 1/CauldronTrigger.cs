using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronTrigger : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference of parent cauldron")]
    private Cauldron cauldron;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potion"))
        {
            Potion potion = other.GetComponent<Potion>();
        
            if (potion != null)
            {
                cauldron.AddBottleValueToPot(potion.value);
            }
        }
    }
}

using Mirror;
using UnityEngine.Events;

public class Reset : NetworkBehaviour
{
    public UnityEvent reset;
    public Potion[] potions;
    
    private void Start()
    {

    }
    public void resetGame()
    {
        reset.Invoke();
        foreach (var potion in potions)
        {
            potion.resetPotion();
        }
    }
    
}
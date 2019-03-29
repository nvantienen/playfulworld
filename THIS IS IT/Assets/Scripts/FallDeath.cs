using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public GameManager gm;
    public void OnTriggerEnter()
    {
    gm.EndGame();
    }
     
   
}

using UnityEngine;

public class GameState : MonoBehaviour
{
    public int hitCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            hitCount++;
            if (hitCount >= 50000)
            {
                Debug.Log("Game Over!");
                Time.timeScale = 0;
            }
        }
    }
}

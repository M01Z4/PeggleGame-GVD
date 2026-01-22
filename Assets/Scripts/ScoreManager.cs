using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton
    public static ScoreManager Instance;

    // Totale score
    public int score = 0;


private void Awake()
{
    Debug.Log("ScoreManager Awake ran on: " + gameObject.name);

    if (Instance != null && Instance != this)
    {
        Debug.LogWarning("Duplicate ScoreManager destroyed: " + gameObject.name);
        Destroy(gameObject);
        return;
    }

    Instance = this;
}

    // functie om punten toe te voegen
    public void AddScore(int amount)
    {
        score = score + amount;
        // debug voor testen
        Debug.Log("Score: " + score);
    }

    
}
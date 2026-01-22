using UnityEngine;
using TMPro;

public class UIScoreBoard : MonoBehaviour
{
    public TMP_Text scoreField;
    public TMP_Text multiplierField;

    private void OnEnable()
    {
        ComboSystem.OnScoreChange += UpdateUI;
    }

    private void OnDisable()
    {
        ComboSystem.OnScoreChange -= UpdateUI;
    }

    private void UpdateUI(int score, int multiplier)
    {
        scoreField.text = "Score: " + score;
        multiplierField.text = "Multiplier: " + multiplier + "X";
    }
}

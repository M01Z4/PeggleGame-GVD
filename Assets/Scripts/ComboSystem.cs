using System;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    
    public static event Action<int, int> OnScoreChange;

    private List<string> bumperTags = new List<string>();
    private int scoreMultiplier = 1;

    private void Start()
    {
        HitBumper.onHitBumper += CheckForCombo;
    }

    private void OnDisable()
    {
        HitBumper.onHitBumper -= CheckForCombo;
    }

    private void CheckForCombo(Transform transform, int bumperValue)
    {
        //vervang
        //bumperTags.Add(tag);
        //Met:
        bumperTags.Add(transform.gameObject.tag);
        if (bumperTags.Count > 1)
        {
            if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
            {
                scoreMultiplier++;                          //verhoog de multiplier
            }
            else                                            //als ze niet gelijk zijn
            {
                scoreMultiplier = 1;                        //reset multiplier
                bumperTags.Clear();                         //leeg de lijst met tags
            }
        }                                                   //voeg score toe aan de ScoreManager


        int addedScore = bumperValue * scoreMultiplier;
        ScoreManager.Instance.AddScore(addedScore);

        OnScoreChange?.Invoke(ScoreManager.Instance.score, scoreMultiplier);
    }
}


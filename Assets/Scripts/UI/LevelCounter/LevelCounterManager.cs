using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCounterManager : MonoBehaviour
{
    private TMP_Text levelCounterText;
    private int levelCounter;
    private void Awake()
    {
        levelCounterText = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        levelCounter = 1;
        levelCounterText.text="LEVEL " +levelCounter.ToString();
       
    }
   
    private void IncreaseLevelCounter(int levelIndex)
    {
        
        levelCounter += levelIndex;
        levelCounterText.text = "LEVEL " + levelCounter.ToString();
    }

}

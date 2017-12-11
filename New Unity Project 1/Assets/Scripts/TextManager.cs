using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    private int[] cannonScores;
    private int totalScore;

    public Text cannon0Text;
    public Text cannon1Text;
    public Text cannon2Text;
    public Text cannon3Text;
    public Text totalScoreText;
    private Text[] texts;

    // Use this for initialization
    void Start () {
        cannonScores = new int[4];
        foreach (int i in cannonScores)
        {
            cannonScores[i] = 0;
        }

        totalScore = 0;

        texts = new Text[] { cannon0Text, cannon1Text, cannon2Text, cannon3Text };

        foreach (Text text in texts)
        {
            text.text = "0";
        }

        UpdateTotalScoreText();
        
	}

    public void UpdateScore (int cannonIndex)
    {
        cannonScores[cannonIndex]++;
        totalScore++;
        UpdateCannonScoreText(cannonIndex);
        UpdateTotalScoreText();
    }

    private void UpdateCannonScoreText(int cannonIndex)
    {
        texts[cannonIndex].text = cannonScores[cannonIndex].ToString();
    }

    private void UpdateTotalScoreText()
    {
        totalScoreText.text = "Total Hits Score: " + totalScore.ToString();
    }


}

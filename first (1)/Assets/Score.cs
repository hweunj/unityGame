using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    public static int score;        // The player's score.
    Text text;                      // Reference to the Text component.
    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + score;
    }
}
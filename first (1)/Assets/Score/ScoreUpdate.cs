using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {
    Text SCORE;

    void Awake()
    {
        SCORE = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SCORE.text = ScoreManage.score.ToString();

    }
}

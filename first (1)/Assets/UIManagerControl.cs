using UnityEngine;
using System.Collections;

public class UIManagerControl : MonoBehaviour {

	public void OnClickStartButton(string msg){
		Debug.Log("Click Start Button" + msg);
        Application.LoadLevel("level1");
//        Application.LoadLevelAdditive("main");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	//declare a int player score and a text txt
	public int playScore;
	Text txt;

	public void increaseScore(){
		//increase the score by one
		playScore++;
	}
	// Use this for initialization
	void Start () {
		// at the start set the score to 0, the txt equals the text component of the gameObject
		playScore = 0;
		txt = gameObject.GetComponent<Text>();
		//set txt to equal the string plus the score
		txt.text = "Score: " + playScore;
	}
	
	// Update is called once per frame
	void Update () {
		//update the score every frame
		txt.text = "Score: " + playScore;
	}
}
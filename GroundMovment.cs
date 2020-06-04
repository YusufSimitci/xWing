using UnityEngine;
using System.Collections;


public class GroundMovment : MonoBehaviour {

    //GameObject tank;
	public GameObject sound;
	public AudioSound audioSound;
	public Sprite exp1;
	public Sprite exp2;
	public Sprite exp3;
	bool isDestroyed = false;
	float destroyTime;
	//public GameObject tank;
	//Time.realtimeSinceStartup
    // Use this for initialization
    void Start () {
		// get a sound from the gameObject "Audio Source" from the game world
		sound = GameObject.Find("Audio Source");
		audioSound = sound.GetComponent<AudioSound> ();
	}

	// Update is called once per frame
	void Update () {


        //tank = GameObject.Find("Tank");
        //tank.transform.
		// move left
        transform.Translate(-Time.deltaTime*3, 0,0);

		if(isDestroyed){
			//if the object is destroyed then call on each sprite and play the destruction sound
			if(destroyTime + .9 < Time.realtimeSinceStartup){
				Destroy(GetComponent<SpriteRenderer>().sprite);
				Destroy(gameObject);
			}else if(destroyTime + .6 < Time.realtimeSinceStartup){
				GetComponent<SpriteRenderer>().sprite = exp1;
			}else if(destroyTime + .3 < Time.realtimeSinceStartup){
				audioSound.playTieExplode();
				GetComponent<SpriteRenderer>().sprite = exp2;
			}
		}

    }

	public void startDestroy(){
		// if the object is not destroyed then flip isDestroyed and start the timer
		if(!isDestroyed){
			isDestroyed = true;
			destroyTime = Time.realtimeSinceStartup;
			//set the sprite to the fisrt destroyed sprite
			GetComponent<SpriteRenderer>().sprite = exp3;
		}
	}
}

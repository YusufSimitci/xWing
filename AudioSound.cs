using UnityEngine;
using System.Collections;

public class AudioSound : MonoBehaviour {
	public AudioClip xWingFire;
	private AudioSource source;
	public AudioClip explodeSound;

	// Use this for initialization
	void Start () {
		// set sound to the coponent Audio Source
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playXWingFire(){
		//play the xWingSound assigned
		source.PlayOneShot (xWingFire,1.0f);
	}

	public void playTieExplode(){
		//play the explotion sound assigned
		source.PlayOneShot(explodeSound,0.1f);
	}
}

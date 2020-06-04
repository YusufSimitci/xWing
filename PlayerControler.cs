using UnityEngine;
using System.Collections;
 

public class PlayerControler : MonoBehaviour {

    GameObject airplane;
	public GameObject tank;
	public GameObject sound;
	public AudioSound audioSound;
    public Transform firePoint;
    public GameObject bullet;
    public float lastFireTime = 0;
	public Transform SpawnPointPlaneEnemy;
	public Transform SpawnPointTank;
	public float lastSpawnTime = 0;
	public float lastSpawnTimePlane = 0;
    // Use this for initialization
    void Start () {
		// set the audio sound and the sound
		sound = GameObject.Find("Audio Source");
		audioSound = sound.GetComponent<AudioSound> ();
	}
    // Update is called once per frame
    void Update()
    {
		//get the angle of the plane
        float angle = Input.GetAxis("Vertical") * 5;
        //set airplane to the gameObject "Airplane"
        airplane = GameObject.Find("Airplane");
		// get the z rotation of the plane
        float planeAngle = airplane.transform.rotation.z;
		//if the user presses down on the keyboard and the angle of the plane is greater than 45 or equal to
        if ((angle < 0 && planeAngle >= -.45) ||
                (angle > 0 && planeAngle <= .45))

        {
			// then update the transform
            airplane.transform.Rotate(0, 0, angle);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
			// if the user presses space and the timer has reset
            if(lastFireTime + 1 < Time.realtimeSinceStartup)
            {
				//fire two bullets
				for(int i = 0; i < 2; i++){
					Instantiate(bullet, new Vector2(firePoint.position.x - ((float)i*3), firePoint.position.y), firePoint.rotation);
				}
				//play the audio and reset the fire time
				audioSound.playXWingFire();
				lastFireTime = Time.realtimeSinceStartup;
			}
        }

		//Random rnd = new Random();

		//if 4 seconds have passes since the start of the game then spawn in two more Tie Fighters
		if (lastSpawnTime + 4 < Time.realtimeSinceStartup) {
			Instantiate (tank, new Vector2 (SpawnPointTank.position.x - ((Random.value) * 8 - 4),SpawnPointTank.position.y - ((Random.value) * 4)), SpawnPointTank.rotation);
			Instantiate (tank, new Vector2 (SpawnPointPlaneEnemy.position.x + ((1 - Random.value) * 8 - 4) , SpawnPointPlaneEnemy.position.y + ((1 - Random.value) * 4)),SpawnPointTank.rotation);
			//reset the spawn timer
			lastSpawnTime = Time.realtimeSinceStartup;
		}
        if (Input.GetKeyDown(KeyCode.E))
        {
			//press e to get the transform of the planes z rotation
			//used to debug the game, usless for play
            Debug.Log(airplane.transform.rotation.z);
        }




    }
}

using UnityEngine;
using System.Collections;
using System;


public class BulletControler : MonoBehaviour {

    public float speed;
    public Rigidbody rb;
    public double yAngle;
	public double yPosition;

	GameObject score;
	PlayerScore playTxt;
    GameObject airPlane;
	GameObject bullet;
    float xVelocity;
    float yVelocity;
	
    void Start () {
        rb = GetComponent<Rigidbody>();
        airPlane = GameObject.Find("Airplane");
		bullet = GameObject.Find ("Bullet");
		//grab the z rotation of the plane
        yAngle = airPlane.transform.rotation.z;
        xVelocity = (float)3;
		// the yVelocity if equal to the tangent because the game was origonaly desined to have 
		// gravity, but after  decided to make it Star Wars themed gravity made little sence
		// so now it is just a flat value
        yVelocity = (float)Math.Tan(yAngle) * xVelocity;

    }

    // Update is called once per frame
    void Update()
    {
		//yPosition = bullet.transform.position.y;
        //rb.AddForce(transform.forward * speed);
        //yVelocity = yVelocity - (float).01; 
        //rb.velocity = new Vector3(xVelocity,yVelocity, 0);
        //transform.Translate(Time.deltaTime * xVelocity, Time.deltaTime * yVelocity, 0);

		//the code above was how I implamented gravity into the game

		//move the bullet with the given vilocitys
		transform.Translate(xVelocity * .3f, yVelocity * .3f, 0);
	}


    void OnTriggerEnter2D(Collider2D other)
    {

        //if (other.tag == "Enemy")
		switch(other.tag)
        {
			case "Enemy":
				// the the tag is Enemy then increase score
				score = GameObject.Find("score");
				PlayerScore score2 = score.GetComponent<PlayerScore>();
				// grab the increaseScore method from the PlayerScore code
				score2.increaseScore();
				
				//start to destroy the other object
			    other.GetComponent<GroundMovment>().startDestroy();
				
				//playTxt = (PlayerScore) score;
				//playTxt.playScore++;
				// used to debug game, used to check if the hit was registering
	            Debug.Log("Hit the Tank");
				
	            //Destroy(other.gameObject);
	            Destroy(gameObject);
			    break;
        }
    }
}

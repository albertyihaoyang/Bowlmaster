using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Rigidbody rigidBody;
    private AudioSource ballSound;
    private Vector3 ballStartPos;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        ballSound = GetComponent<AudioSource>();

        ballStartPos = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rigidBody.velocity = velocity;
        rigidBody.useGravity = true;

        ballSound.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;

        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
    }
}

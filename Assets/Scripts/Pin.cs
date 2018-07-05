using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    private float standingTreshold = 10f;

    private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = rotationInEuler.x + 90f;

        return ((tiltInX <= standingTreshold || tiltInX >= 360f - standingTreshold));
    }

    public void RaiseIfStanding(){
        if (IsStanding())
        {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, 50f, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0, 0);
            rigidBody.isKinematic = true;
        }
    }

    public void Lower()
    {
        transform.Translate(new Vector3(0, -50f, 0), Space.World);
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
    }
}

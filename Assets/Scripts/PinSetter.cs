using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    
    public GameObject pinSet;

    private Animator animator;
    private PinCounter pinCounter;

	void Start () {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void RaisePins(){
        // raise standing pins only by distanceToRaise
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();

        }
    }

    public void LowerPins()
    {
        // raise standing pins only by distanceToRaise
        Debug.Log("Lower Pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins(){
        Debug.Log("Renew Pins");
        Instantiate(pinSet, new Vector3(0, 50, 1829), Quaternion.identity);
    }

    public void PerformAction(ActionMaster.Action action){
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.Reset || action == ActionMaster.Action.EndTurn)
        {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle end game yet");
        }
    }

}

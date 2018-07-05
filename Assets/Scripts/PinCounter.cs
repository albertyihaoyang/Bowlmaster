using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
    
    public Text standingDisplay;

    private GameManager gameManager;
    private bool ballOutOfPlay = false;
    private float lastChangeTime;
    private int lastSettledCount = 10;
    private int lastStandingCount = -1;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
	}

    public void Reset()
    {
        lastSettledCount = 10;
    }

    void PinHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        standingDisplay.color = Color.green;
        lastStandingCount = -1;
        ballOutOfPlay = false;
        gameManager.Bowl(pinFall);
    }

    void UpdateStandingCountAndSettle()
    {
        int cur = CountStanding();
        if (cur != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = cur;
            return;
        }
        float settleTime = 3f;
        if (Time.time - lastChangeTime >= settleTime)
        {
            PinHaveSettled();
        }

    }

    int CountStanding()
    {
        int standing = 0;
        Pin[] pins = GameObject.FindObjectsOfType<Pin>();
        foreach (Pin pin in pins)
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
        }
    }
}

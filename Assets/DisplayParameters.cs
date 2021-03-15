using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayParameters : MonoBehaviour {


    public Text timerValue;
    public Slider timerSlider;
    public Text digitValue;
    public Slider digitSlider;

    public float currentTv;
    public int currentDv;

    public bool includeAddition = true;
    public bool includeSubtraction = true;
    public bool includeMultiplication = true;

    public Toggle at;
    public Toggle st;
    public Toggle mt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DispTimer();
        DispDigitLVL();
	}
    void DispTimer()
    {
        float tv = timerSlider.value;
        currentTv = tv;
        timerValue.text = "" + tv;
    }
    void DispDigitLVL()
    {
        float dv = digitSlider.value;
        currentDv = (int)dv;
        digitValue.text = "" + dv;
    }
    public void updateAT()
    {
        if (at.isOn)
        {
            includeAddition = true;
        }
        else
        {
            includeAddition = false;
        }
    }
    public void updateST()
    {
        if (st.isOn)
        {
            includeSubtraction = true;
        }
        else
        {
            includeSubtraction = false;
        }
    }
    public void updateMT()
    {
        if (mt.isOn)
        {
            includeMultiplication = true;
        }
        else
        {
            includeMultiplication = false;
        }
    }

}

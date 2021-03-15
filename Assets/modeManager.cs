using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modeManager : MonoBehaviour {


    [SerializeField]
    gameManager gscript;

   // public GameObject endlessB;
   // public GameObject ladderB;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setMode0()
    {
        gscript.setGameMode(0);
    }
    public void setMode1()
    {
        gscript.setGameMode(1);
    }
}

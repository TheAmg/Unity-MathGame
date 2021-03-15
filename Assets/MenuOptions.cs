using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour {

    [SerializeField]
    private gameManager gobj;

    [SerializeField]
    private GameObject MenuObj;

    [SerializeField]
    private GameObject PlayObj;

    [SerializeField]
    private GameObject DiffMenu;

    [SerializeField]
    private GameObject SettingsMenu;

    [SerializeField]
    private Text[] tfs;

    [SerializeField]
    private Image bck;

	// Use this for initialization
	void Start () {
        ApplyTheme();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {  
        MenuObj.SetActive(false);
        PlayObj.SetActive(true);
        gobj.resetSessionStats();
        SettingsMenu.SetActive(false);
    }
    public void EndGameSession()
    {
        gobj.resetSessionStats();
        MenuObj.SetActive(true);
        PlayObj.SetActive(false);
        SettingsMenu.SetActive(false);
    }
    public void OpenDiffMenu()
    {
        MenuObj.SetActive(false);
        PlayObj.SetActive(false);
        DiffMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
    public void CloseDiffMenu()
    {
        MenuObj.SetActive(true);
        PlayObj.SetActive(false);
        DiffMenu.SetActive(false);
        SettingsMenu.SetActive(false);
    }
    public void OpenSettings()
    {
        MenuObj.SetActive(false);
        PlayObj.SetActive(false);
        DiffMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        MenuObj.SetActive(true);
        PlayObj.SetActive(false);
        DiffMenu.SetActive(false);
        SettingsMenu.SetActive(false);
    }
    public void SetCurrentDiffParameters()
    {
        DisplayParameters dp = DiffMenu.GetComponent<DisplayParameters>();
        gobj.setCustomRules(dp.currentTv,dp.currentDv);
    }
    public void ApplyTheme()
    {
        SettingsMenuControl csm = SettingsMenu.GetComponent<SettingsMenuControl>();
        bck.sprite = csm.returnSelected();
        ApplyTextTheme();
    }
    public void ApplyTextTheme()
    {
        SettingsMenuControl tcs = SettingsMenu.GetComponent<SettingsMenuControl>();
        Color cc = tcs.retCol();
       // tcs.colPrev.color = cc;

        for(int i = 0; i < tfs.Length; i++)
        {
            tfs[i].color=cc;
        }
    }
}

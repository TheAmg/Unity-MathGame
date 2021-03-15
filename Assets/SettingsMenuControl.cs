using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuControl : MonoBehaviour {

    [SerializeField]
    private Sprite[] imgOps;

    [SerializeField]
    private Color[] cols;

    [SerializeField]
    private Image previewIMG;

    [SerializeField]
    private Text ExampleText;

    public Image colPrev;

    int counter = 0;
    int cc2 = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        previewIMG.sprite = imgOps[counter];
        ExampleText.color = cols[cc2];
        colPrev.color = cols[cc2];
	}

    public void nextImage()
    {
        if (counter >= imgOps.Length-1)
        {
            counter = 0;
        }
        else
        {
            counter++;
        }
    }
    public void previousImage()
    {
        if (counter <= 0)
        {
            counter = imgOps.Length - 1;
        }
        else
        {
            counter--;
        }
    }
    public Sprite returnSelected()
    {
        return (imgOps[counter]);
    }
    public void nextCol()
    {
        if (cc2 >= cols.Length - 1)
        {
            cc2 = 0;
        }
        else
        {
            cc2++;
        }
    }
    public void prevCol()
    {
        if (cc2 == 0)
        {
            cc2 = cols.Length-1;
        }
        else
        {
            cc2--;
        }
    }
    public Color retCol()
    {
        return (cols[cc2]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
  
    #region references

    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Text answerText;
    [SerializeField]
    private Text option1;
    [SerializeField]
    private Text option2;
    [SerializeField]
    private Text option3;
    [SerializeField]
    private Text option4;

    [SerializeField]
    private Text ctext;
    [SerializeField]
    private Text wtext;
    [SerializeField]
    private Text missesText;
    [SerializeField]
    private Text tlt;
    [SerializeField]
    private GameObject timerBar;

    [SerializeField]
    private int[] gamemodes;
    [SerializeField]
    private int currentMode = 0;



    public Color early;
    public Color mid;
    public Color late;

    int wins = 0;
    int losses = 0;
    int misses = 0;
    bool canAns = true;
    bool isChecking = false;
    float startTime = 0;
    bool isPlaying = false;
    char[] exparray;
    bool ca = true;
    bool cs = true;
    bool cm = true;

  //  int[] numarray;
   // char[] oparray;

  //  public Color def;
  //   public Color wrongAns;
  //   public Color correctAns;

    #endregion

    #region rules and diff

    [SerializeField]
    [Range(5,25)]
    float Timer;
    [SerializeField]
    char[] IPS;
    private int iplength;
    [Range(1,5)]
    public int digitLevel = 1;
    [Range(2,5)]
    int expLenght=2;
    
    #endregion

    private float currentans=0;

    void Start () {
       
        
        iplength = IPS.Length;
        generateQuestion();
	}
	
	
	void Update () {
        if (currentMode == 0)
        {
            if ((Time.time - startTime > Timer) && !isChecking && isPlaying)
            {
                canAns = false;
                misses++;
                missesText.text = "Missed : " + misses;
                generateQuestion();
            }
        }
        else if (currentMode == 1)
        {
            if ((Time.time - startTime > Timer) && !isChecking && isPlaying)
            {
                canAns = false;
              //  misses++;
                missesText.text = "Game over : ";
                isPlaying = false;
               // generateQuestion();
            }
        }
        
        if (isPlaying)
        {
            updateTimerBar();
        }


	}

    public void generateQuestion()
    {
        isChecking = false;
        isPlaying = true;
      //  resetButtonsCol(option1);
      //  resetButtonsCol(option2);
      //  resetButtonsCol(option3);
      //  resetButtonsCol(option4);
        string q;
      //  exparray = new char[(expLenght * 2) - 1];
     //   for (int i = 0; i < expLenght; i=i+2)
     //   {
     //       exparray[i]= (char)generateRNO(digitLevel);
     //       int opi= (int)Random.Range(0, iplength - 1);
     //       exparray[i + 1] = IPS[opi];
     //   }

      //  exparray[exparray.Length-1]= (char)generateRNO(digitLevel);

           int num1 = generateRNO(digitLevel);
           int num2 = generateRNO(digitLevel);
           int opindex = (int)Random.Range(0, iplength-1);

      //  string arrDisp="";
     //   for(int i = 0; i < exparray.Length; i++)
     //   {
     //       arrDisp = "" + exparray[i];
     //   }

        q = "Question: "+num1+" "+IPS[opindex]+" "+num2;
        questionText.text = ""+q;

           float ans = findAnswer(num1, IPS[opindex], num2);
      //  float ans = (float)arrayEval(exparray);
        currentans = ans;
        // Debug.Log("Answer is " + ans);
        generateOptions(ans);
        if (currentMode == 0)
        {
            StartTimer();
        }
       else if (currentMode == 1)
        {
            addbonusTime();
        }



    }
    private void addbonusTime()
    {
       float deltaT = Time.time - startTime;
       startTime = startTime + deltaT;

    }
    private int retValOPindex()
    {
        int ret = -1;

        int x= (int)Random.Range(0, iplength - 1);

        if (x == 0 && !ca)
        {

        }else if (x == 1 && !cs)
        {
         
        }else if (x == 2 && !cm)
        {

        }

        return ret;
    }
    private int arrayEval(char[] expa)
    {
        int res = 0;
        
        int i = 0;
        //top level mult/div
        while(i<expa.Length)
        {
            if (expa[i] == '*')
            {
                expa = multele(expa, i);
                i = 0;
            }
        }
        i = 0;

        //add or subtract
        while (i < expa.Length)
        {
            if (expa[i] == '+' || expa[i] == '-')
            {
                expa = multele(expa, i);
            }
        }

        string resval = expa[0].ToString();
        res = int.Parse(resval);



        return res;
    }
    char[] multele(char[] expa,int index)
    {   
        char[] retarr = expa;
        string s1 = retarr[index - 1].ToString();
        string s2 = retarr[index + 1].ToString();
        int n1 = int.Parse(s1);
        int n2 = int.Parse(s2);
        int temp = (int)findAnswer(n1, retarr[index], n2);
        retarr[index - 1] =(char)temp;

        //pass 1 filter

        for(int i = index + 1; i < retarr.Length; i++)
        {
            retarr[i] = retarr[i + 1];
        }

        //pass 2 filter

        for(int i = index; i < retarr.Length; i++)
        {
            retarr[i] = retarr[i + 1];
        }
        return retarr;
    }

    int generateRNO(int diffLVL)
    {
        int res = 0;
        switch (diffLVL)
        {
            case 1: res=(int)Random.Range(1, 9);
                    break;
            case 2:
                res = (int)Random.Range(1, 99);
                    break;
            case 3:
                res = (int)Random.Range(1, 999);
                    break;
            case 4:
                res = (int)Random.Range(1, 9999);
                    break;
            case 5:
                res = (int)Random.Range(1, 99999);
                    break;

        }
        return res;
    }

    void StartTimer()
    {
        startTime = Time.time;
        canAns = true;
    }

    float findAnswer(int n1,char x,int n2)
    {
        float res=0.0f;

        switch (x)
        {
            case '+' :
                res = n1 + n2;
                break;
            case '-':
                res = n1 - n2;
                break;
            case '*':
                res = n1 * n2;
                break;
            case '/':
                res = n1 / n2;
                break;
        }



        return res;
    }

    void generateOptions(float ans)
    {
        List<float> Oexceptions = new List<float>();
        Oexceptions.Add(ans);
        float[] ops = { 0.0f, 0.0f, 0.0f, 0.0f };
        float[] altops = { 0, 0, 0 };
        int ansind = (int)Random.Range(0, 3);
        ops[ansind] = ans;
        float atlop1 = getVaildOption(Oexceptions);
        Oexceptions.Add(atlop1);
        altops[0] = atlop1;
        float atlop2 = getVaildOption(Oexceptions);
        Oexceptions.Add(atlop2);
        altops[1] = atlop2;
        float atlop3 = getVaildOption(Oexceptions);
        Oexceptions.Add(atlop3);
        altops[2] = atlop3;
        int k = 0;
        for (int i = 0; i < ops.Length; i++)
        {
            if (i != ansind)
            {
                ops[i] = altops[k];
                k++;
            }
        }

      //  Debug.Log("Options:");
      //  foreach(float f in ops)
     //   {
      //      Debug.Log(f);
     //   }

        option1.text = "" + ops[0];
        option2.text = "" + ops[1];
        option3.text = "" + ops[2];
        option4.text = "" + ops[3];


    }

    float getVaildOption(List<float> except)
    {
        float rnd = generateRNO(digitLevel);
        foreach(float f in except)
        {
            if (rnd == f)
            {
                getVaildOption(except);
            }
        }
        return rnd;
    }

    public void checkAnswer(float option)
    {
        Debug.Log("Selected: " + option + " Expected " + currentans);
        if ((option-currentans)==0)
        {
            answerText.text = "You picked the right option(" + currentans + ")";
            //  setOptionColorTo(selopt, correctAns);
            wins++;
            ctext.text = "Correct : " + wins;
            generateQuestion();
        }
        else
        {
            answerText.text = "Wrong answer, the right answer is "+currentans;
            //  setOptionColorTo(selopt, wrongAns);
            losses++;
            wtext.text = "Wrong : " + losses;
            generateQuestion();
        }
    }
    public void op1CLK()
    {
        if (canAns)
        {
            isChecking = true;
            string str = option1.text.ToString();
            float opt = float.Parse(str);
            checkAnswer(opt);
            
        }
        
    }
    public void op2CLK()
    {
        if (canAns)
        {
            isChecking = true;
            string str = option2.text.ToString();
            float opt = float.Parse(str);
            checkAnswer(opt);
        }
        
    }
    public void op3CLK()
    {
        if (canAns)
        {
            isChecking = true;
            string str = option3.text.ToString();
            float opt = float.Parse(str);
            checkAnswer(opt);
        }
        
    }
    public void op4CLK()
    {
        if (canAns)
        {
            isChecking = true;
            string str = option4.text.ToString();
            float opt = float.Parse(str);
            checkAnswer(opt);
        }
        
    }

  /*  void setOptionColorTo(Text childobj,Color col)
    {
        GameObject pob = childobj.transform.gameObject;
        Image bimg = pob.GetComponent<Image>();
        bimg.color = col;
    }*/
  //  void resetButtonsCol(Text opt)
  //  {
 //       GameObject obj1= opt.transform.parent.gameObject;
 //       Image b1 = obj1.GetComponent<Image>();
 //       b1.color = def;
 //   }

    public void ExitDeGame()
    {
        Application.Quit();
    }
    public void resetSessionStats()
    {
        isPlaying = false;
        startTime = 0;
        wins = 0;
        ctext.text = "Correct : " + wins;
        losses = 0;
        wtext.text = "Wrong : " + losses;
        misses = 0;
        missesText.text = "Missed : " + misses;
    }
    private void updateTimerBar()
    {

        float tleft = Timer-(Time.time - startTime);
        tlt.text = "Time:" + tleft;

        if (Time.time - startTime > Timer)
        {
            return;
        }
        else
        {
            float imgsize = (((Time.time - startTime)/Timer)*100)*2;
            float propimg= ((Time.time - startTime) / Timer)*100;
           // float timeCounter = (Time.time - startTime);
            //tlt.text = "Time: " + (int)timeCounter +" IS:"+imgsize;
            RectTransform tbrt = timerBar.GetComponent<RectTransform>();
            Image Timg = timerBar.GetComponent<Image>();
            if (propimg < 34)
            {
                Timg.color = early;
            }else if(propimg>=34 && propimg < 64)
            {
                Timg.color = mid; 
            }
            else if (propimg >= 64)
            {
                Timg.color = late;
            }
            tbrt.sizeDelta = new Vector2(imgsize, 30);
        }
        
    }
    public void setCustomRules(float timer, int dlvl)
    {
        Timer = timer;
        digitLevel = dlvl;
      //  ca = canA;
      //  cs = canS;
      //  cm = canM;
    }
    public void setGameMode(int mod)
    {
        if (mod > gamemodes.Length - 1)
        {
            currentMode = 0;
        }
        else
        {
            currentMode = mod;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    int screenCount = 0;
    int totalScreens = 3;
    float buttonWidth =  100f;
    float imageWidth = 350f;
    int result = 0;
    string gender = "";
    string selection = "";
    public Texture[] femaleTexture;
    public Texture[] maleTexture;
    public Texture[] otherTexture;
    System.Random rand = new System.Random();
    string[] femaleQoutes = {"I would venture to guess that Anon, who wrote so many poems without signing them, was often a woman","The man who does not read has no advantage over the man who cannot read","I became insane, with long intervals of horrible sanity"};
    string[] maleQoutes = {"If you tell the truth, you don't have to remember anything","Books are the mirrors of the soul","We loved with a love that was more than love"};
    string[] otherQoutes = {"I would venture to guess that Anon, who wrote so many poems without signing them, was often a woman","There is nothing more deceptive than an obvious fact","Deserve your dream"};

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        
       switch(screenCount)
       {
            case 0: //Home
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box: " + screenCount.ToString());
                if(GUI.Button(new Rect(Screen.width/2-(buttonWidth/2), (Screen.height/10)*6.5f, 100, 30), "Show image"))
                {
                    selection = "image";
                    nextScreen();
                }
                if(GUI.Button(new Rect(Screen.width/2-(buttonWidth/2), (Screen.height/10)*7.5f, 100, 30), "Show motto"))
                {
                    selection = "motto";
                    nextScreen();
                }

            break;
                
            case 1: //Gender selection
                if(gender == "")
                {
                    GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box: " + screenCount.ToString());
                    setBackButton();
                    if(GUI.Button(new Rect(Screen.width/2-(buttonWidth/2), (Screen.height/10)*6.5f, 100, 30), "Male"))
                    {
                        gender = "male";
                        if(selection == "image")
                        {
                            result = rand.Next(0, maleTexture.Length);
                            nextScreen();
                        }else{
                            result = rand.Next(0, maleQoutes.Length);
                            screenCount = 3;
                        }
                        
                    }
                    if(GUI.Button(new Rect(Screen.width/2-(buttonWidth/2), (Screen.height/10)*7.5f, 100, 30), "Female"))
                    {
                        gender = "female";
                        if(selection == "image")
                        {
                            result = rand.Next(0, femaleTexture.Length);
                            nextScreen();
                        }else{
                            result = rand.Next(0, femaleQoutes.Length);
                            screenCount = 3;
                        }
                    }
                    if(GUI.Button(new Rect(Screen.width/2-(buttonWidth/2), (Screen.height/10)*8.5f, 100, 30), "Other"))
                    {
                        gender = "other";
                        result = rand.Next(0, otherTexture.Length);
                        if(selection == "image")
                        {
                            nextScreen();
                        }
                        else
                        {
                            result = rand.Next(0, otherQoutes.Length);
                            screenCount = 3;
                        }
                        
                    }
                }else if(gender == "male")
                {
                    if(selection == "image")
                    {
                        result = rand.Next(0, maleTexture.Length);
                        nextScreen();
                    }else{
                        result = rand.Next(0, maleQoutes.Length);
                        screenCount = 3;
                    }
                    
                }else if(gender == "female")
                {
                    if(selection == "image")
                    {
                        result = rand.Next(0, femaleTexture.Length);
                        nextScreen();
                    }else{
                        result = rand.Next(0, femaleQoutes.Length);
                        screenCount = 3;
                    }
                }else if(gender == "other")
                {
                    if(selection == "image")
                    {
                        result = rand.Next(0, otherTexture.Length);
                        nextScreen();
                    }else{
                        result = rand.Next(0, otherQoutes.Length);
                        screenCount = 3;
                    }
                }
                
            break;
                
            case 2: //Image randomizer
                
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Image: " + screenCount.ToString());
                setBackButton();
                showImage();
                
            break;

            case 3: //Moto randomizer
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Motto: " + screenCount.ToString());
                setBackButton();
                showMotto();
            break;

            default:

                Debug.Log("Something went wrong...");

            break;

       }
        
    }

    ///Only one back button to use in all screens
    void setBackButton()
    {
        if(GUI.Button(new Rect(10, 70, 50, 30), "Click"))
        {
            backScreen();
        }
    }

    //Move forward between screens
    void nextScreen()
    {
        if(screenCount < totalScreens)
        {
            screenCount += 1;
            Debug.Log("Screen count: "+screenCount.ToString());
        }
    }

    //Go backward between screens
    void backScreen()
    {
        if(screenCount >= 0)
        {
            if(gender == "male" || gender == "female" || gender == "other")
            {
                //Reset counter and selections
                screenCount = 0; 
                gender = "";
                selection = "";
            }else{
              screenCount -= 1;  
            }
        }
    }

    //Get back Home
    void getHome()
    {
        screenCount = 0;
    }

    void showImage()
    {
        
        if(gender == "male")
        {
            GUI.Box(new Rect(Screen.width/2-(imageWidth/2), Screen.height/2, 350, 175), maleTexture[result]);
        }else if(gender == "female")
        {
            GUI.Box(new Rect(Screen.width/2-(imageWidth/2), Screen.height/2, 350, 175), femaleTexture[result]);
        }else if(gender == "other")
        {
            GUI.Box(new Rect(Screen.width/2-(imageWidth/2), Screen.height/2, 350, 175), otherTexture[result]);
        }
    }

    void showMotto()
    {
        if(gender == "male")
        {
            GUI.Label(new Rect(Screen.width/2-(600/2), Screen.height/2, 600, 100), maleQoutes[result]);
        }else if(gender == "female")
        {
            GUI.Label(new Rect(Screen.width/2-(600/2), Screen.height/2, 600, 100), femaleQoutes[result]);
        }else if(gender == "other")
        {
            GUI.Label(new Rect(Screen.width/2-(600/2), Screen.height/2, 600, 100), otherQoutes[result]);
        }
    }
}

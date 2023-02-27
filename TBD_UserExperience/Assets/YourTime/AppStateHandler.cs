using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class AppStateHandler
{
    //public static AppStateHandler Instance { get; private set; }
    static public string currentScene { get; private set; }
    static private AppStateHandler instance;
    private AppStateHandler() { }
    public static AppStateHandler Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new AppStateHandler();
                string openedScene = SceneManager.GetActiveScene().name.ToString();
                currentScene = openedScene;
            }
            return instance;
        }
        /*
        Debug.Log("I am up and running");
        currentScene = openedScene;

        if (Instance != null && Instance != AppStateHandler)
        {
            Destroy(this);
        }
        else
        {
            Instance = AppStateHandler();
            Instance.currentScene = "SplashScreen"; //Only gets called the first time the app starts
        }
        DontDestroyOnLoad(gameObject);
        navigationStack.Clear();
        navigationStack.Add("SplashScreen");*/
    }

    public List<string> navigationStack = new List<string>();


    public void SetCurrentScene(string openedScene)
    {
        currentScene = openedScene;
    }

    public void Test()
    {
        Debug.Log(currentScene); //Only gets called the frist time the app starts
    }

    public void SetActiveScene(string openedScene)
    {
        navigationStack.Add(openedScene);
        //Instance.currentScene = navigationStack.Last();
    }

    public void SubmitStars(int StarsNumber)
    {
        Debug.Log("Grade: " + StarsNumber);
        ChangeScene(false);
    }


    public void ChangeScene(bool changeToAbout) //TODO: Change so where to go is not hard coded
    {
        Debug.Log(navigationStack);
        if (changeToAbout)
        {
            SceneManager.LoadScene("About");
            Instance.SetActiveScene("About");
        }
        else
        {
            //SceneManager.LoadScene(Instance.currentScene);
        }
    }

    public void CloseExercise()
    {
        Debug.Log(navigationStack);
        for(int i = navigationStack.Count - 1; i > navigationStack.IndexOf("MainMenu"); i--)
        {
            Debug.Log("Remove: " + i + " " + navigationStack[i]);
            navigationStack.RemoveAt(navigationStack.Count - 1);
            
        }
    }

    public void GoBack()
    {
        if (currentScene == "AfterExercise")
        {
            CloseExercise();
        }
        else
        {
            navigationStack.RemoveAt(navigationStack.Count - 1); //Pop the last one to change to the new current
        }
        //Instance.currentScene = navigationStack.Last();

        //SceneManager.LoadScene(Instance.currentScene);
        
    }
    private void Awake()
    {

        /*if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            //Instance.currentScene = "SplashScreen"; //Only gets called the first time the app starts
        }
        DontDestroyOnLoad(gameObject);
        navigationStack.Clear();
        navigationStack.Add("SplashScreen");*/
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<PlayerController> players;

    //Game States
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;

 

    private void Awake()
    {
        //If instance does not exist yet
        if (instance == null)
        {
            instance = this;
            // Don't destroy it if we load a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //If there is already an instance, destroy gameObject
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ActivateTitleScreen();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void DeactivateAllStates()
    {
        //Deactivate all Game States
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }

    public void ActivateTitleScreen()
    {
        //Deactivate all states
        DeactivateAllStates();
        //Activate the title screen
        TitleScreenStateObject.SetActive(true);
        // TODO


    }

    public void ActivateMainMenu()
    {
        //Deactivate all states
        DeactivateAllStates();
        //Activate Main Menu
        MainMenuStateObject.SetActive(true);
        // TODO
    }

    public void ActivateOptions()
    {
        //Deactivate all states
        DeactivateAllStates();
        // Activate Options screen
        OptionsScreenStateObject.SetActive(true);
        //TODO
    }

    public void ActivateCredits()
    {
        //Deactivate all states
        DeactivateAllStates();
        //Activate Credits screen
        CreditsScreenStateObject.SetActive(true);
        //TODO

    }

    public void ActivateGameplay()
    {
        //Deactivate all states
        DeactivateAllStates();
        //Activate Gameplay
        GameplayStateObject.SetActive(true);
    }

    public void ActivateGameOver()
    {
        //Deactivate all states
        DeactivateAllStates();
        //Activate Game Over Screen
        GameOverScreenStateObject.SetActive(true);
    }
}

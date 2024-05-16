using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform playerSpawnTransform;

    //Prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject patrolPawnPrefab;
    public GameObject patrolAIControllerPrefab;
    public GameObject aggroPawnPrefab;
    public GameObject aggroAIControllerPrefab;
    public GameObject pansyPawnPrefab;
    public GameObject pansyAIControllerPrefab;
    public GameObject dopeyPawnPrefab;
    public GameObject dopeyAIControllerPrefab;

    public List<PlayerController> players;
    public PawnSpawnPoint[] spawnPoints;

    public MapGenerator mapGenerator;

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

        spawnPlayer();

        mapGenerator = GetComponent<MapGenerator>();

        mapGenerator.GenerateMap();

        spawnPoints = FindObjectsOfType<PawnSpawnPoint>();

       /* foreach(PawnSpawnPoint p in spawnPoints)
        {
            Debug.Log(p.gameObject.name);
        }*/

        SpawnPatrolAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);
        SpawnAggroAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);
        SpawnDopeyAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);
        SpawnPansyAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);
        
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

    public void spawnPlayer()
    {
        //Spawn the Player Controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the Pawn and connect it to the Controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        //Get the Player Controller component and the Pawn component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();


        //Hook them up!
        newController.pawn = newPawn;
    }

   public void SpawnPatrolAI(PawnSpawnPoint spawnPoint)
    {
        //Spawn the AI controller at (0,0,0) with no rotation
        GameObject newAIObj = Instantiate(patrolAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the Pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(patrolPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        //Attach appropriate components and hook AIController to Pawn
        Controller newController = newAIObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;

        newAIObj.GetComponent<AIController>().waypoints[0] = spawnPoint.transform;
        newAIObj.GetComponent<AIController>().waypoints[1] = spawnPoint.nextWaypoint.transform;
        newAIObj.GetComponent<AIController>().waypoints[2] = spawnPoint.nextWaypoint.nextWaypoint.transform;
        newAIObj.GetComponent<AIController>().waypoints[3] = spawnPoint.nextWaypoint.nextWaypoint.nextWaypoint.transform;

       
    }

    public void SpawnAggroAI(PawnSpawnPoint spawnPoint)
    {
        //Spawn the AI controller at (0,0,0) with no rotation
        GameObject newAIObj = Instantiate(aggroAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the Pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(aggroPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        //Attach appropriate components and hook AIController to Pawn
        Controller newController = newAIObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;
    }

    public void SpawnPansyAI(PawnSpawnPoint spawnPoint)
    {
        //Spawn the AI controller at (0,0,0) with no rotation
        GameObject newAIObj = Instantiate(pansyAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the Pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(pansyPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        //Attach appropriate components and hook AIController to Pawn
        Controller newController = newAIObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;
    }

    public void SpawnDopeyAI(PawnSpawnPoint spawnPoint)
    {
        //Spawn the AI controller at (0,0,0) with no rotation
        GameObject newAIObj = Instantiate(dopeyAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the Pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(dopeyPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        //Attach appropriate components and hook AIController to Pawn
        Controller newController = newAIObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;
    }
}

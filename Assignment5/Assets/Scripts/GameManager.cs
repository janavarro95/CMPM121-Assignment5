using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance;

    public Camera mainCamera;
    public ThirdPersonCamera thirdPersonCameraController;

    public GameSoundManager gameSoundManager;

    public GameObject respawn;

    public GameObject unityChan;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "PreloadScene")
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        DontDestroyOnLoad(this.gameObject);

        




        //thirdPersonCameraController.setCameraPosition(ThirdPersonCamera.CameraPosition.Front);
    }

    public void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            this.unityChan = GameObject.Find("unitychan");
            this.respawn = GameObject.Find("RespawnZone");
            mainCamera = Camera.main;
            thirdPersonCameraController = mainCamera.GetComponent<ThirdPersonCamera>();

        }
    }

    // Update is called once per frame
    void Update()
    {

        /*
           if (Input.GetButton ("Fire1")) { // left Ctlr	
                                            // Change Front Camera
            thirdPersonCameraController.setCameraState(ThirdPersonCamera.CameraPosition.Front);
           } else if (Input.GetButton ("Fire2")) {  //Alt	
                                                    // Change Jump Camera
            thirdPersonCameraController.setCameraState(ThirdPersonCamera.CameraPosition.Back);
            
        }
        */

        if (Collectable.CollectablesCollected == 10)
        {
            //unity chan goal!!!!
            //unity chan pose
            //return to main menu
        }
           
    }

    public void respawnUnityChan()
    {
        unityChan.transform.position = respawn.transform.position;
    }
}

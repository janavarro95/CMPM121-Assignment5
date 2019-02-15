using Assets;
using Assets.Scripts.Utilities.Delegates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public static int CollectablesCollected;

    private MeshRenderer objRenderer;
    private bool hasBeenCollected;


    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public AudioClip four;
    public AudioClip five;
    public AudioClip six;
    public AudioClip seven;
    public AudioClip eight;
    public AudioClip nine;
    public AudioClip ten;

    public List<AudioClip> happySurplusCollection;

    public List<Texture> possibleTextures;

    public Texture sprite;
    // Start is called before the first frame update

    private GameObject particles;

    private float sinValue;

    [SerializeField]
    private bool isGoalCollectable;
    private DeltaTimer timer;

    public AudioClip goalSound;

    public static bool goalCollected;

    void Start()
    {
        objRenderer = this.gameObject.GetComponent<MeshRenderer>();
        hasBeenCollected = false;

        if (this.isGoalCollectable ==false)
        {
            this.sprite = possibleTextures[Random.Range(0, 5)];
            objRenderer.material.mainTexture = sprite;
        }
        

        particles = this.gameObject.transform.Find("Particles").gameObject;
        particles.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (timer != null)
        {
            timer.Update();
        }

        if (hasBeenCollected) return;
        sinValue += .05f;
        Vector3 pos = this.gameObject.transform.position;
        pos.y += Mathf.Sin(sinValue)/250;
        this.gameObject.transform.position = pos;
        this.gameObject.transform.eulerAngles+= new Vector3(0,Mathf.Cos(sinValue),0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (hasBeenCollected) return;

        if (isGoalCollectable)
        {
            particles.SetActive(true);
            objRenderer.enabled = false;
            //Destroy(this.gameObject, 3);
            timer = new DeltaTimer(5, Assets.Scripts.Enums.TimerType.CountDown, false, new VoidDelegate(returnToMenu));
            GameManager.Instance.gameSoundManager.playSound(goalSound);
            timer.start();
            hasBeenCollected = true;
            goalCollected = true;
            GameManager.Instance.thirdPersonCameraController.setCameraPosition(UnityChan.ThirdPersonCamera.CameraPosition.Front);
            return;
        }

        hasBeenCollected = true;
        CollectablesCollected++;

        playChanCollectionSound();

        particles.SetActive(true);
        objRenderer.enabled = false;
        Destroy(this.gameObject,3);
    }

    private void returnToMenu()
    {
        Collectable.CollectablesCollected = 0;
        GameManager.Instance.gameSoundManager.titleMusic.Play();
        GameManager.Instance.gameSoundManager.runAroundMusic.Stop();
        goalCollected = false;
        SceneManager.LoadScene("MainMenu");
    }

    private void playChanCollectionSound()
    {
        if (CollectablesCollected == 1) GameManager.Instance.gameSoundManager.playSound(one);
        if (CollectablesCollected == 2) GameManager.Instance.gameSoundManager.playSound(two);
        if (CollectablesCollected == 3) GameManager.Instance.gameSoundManager.playSound(three);
        if (CollectablesCollected == 4) GameManager.Instance.gameSoundManager.playSound(four);
        if (CollectablesCollected == 5) GameManager.Instance.gameSoundManager.playSound(five);
        if (CollectablesCollected == 6) GameManager.Instance.gameSoundManager.playSound(six);
        if (CollectablesCollected == 7) GameManager.Instance.gameSoundManager.playSound(seven);
        if (CollectablesCollected == 8) GameManager.Instance.gameSoundManager.playSound(eight);
        if (CollectablesCollected == 9) GameManager.Instance.gameSoundManager.playSound(nine);
        if (CollectablesCollected == 10) GameManager.Instance.gameSoundManager.playSound(ten);
        if(CollectablesCollected > 10)
        {
            GameManager.Instance.gameSoundManager.playSound(happySurplusCollection[Random.Range(0, happySurplusCollection.Count)]);
        }
    }


}

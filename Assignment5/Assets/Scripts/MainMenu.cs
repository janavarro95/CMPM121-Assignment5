using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.Instance.gameSoundManager.titleMusic.Stop();
        GameManager.Instance.gameSoundManager.runAroundMusic.Play();
    }

    public void quitButtonClick()
    {
        Application.Quit();
    }
}

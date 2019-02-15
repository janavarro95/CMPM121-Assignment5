using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public AudioClip deathSound;
    public DeltaTimer timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer != null) timer.Update();
    }

    public void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.gameSoundManager.playSound(deathSound);
        timer = new DeltaTimer(3, Assets.Scripts.Enums.TimerType.CountDown, false, onTimerFinished);
        timer.start();
        
    }

    public void onTimerFinished()
    {
        GameManager.Instance.respawnUnityChan();
    }
}

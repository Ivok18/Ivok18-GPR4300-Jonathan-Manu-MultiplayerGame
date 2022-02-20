using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [HideInInspector] public GameObject LocalPlayer;
    public float timerAmount = 2f;
    private bool runSpawnTimer = true;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(runSpawnTimer)
        {
            StartRespawn();
        }
    }


    public void EnableRespawn()
    {
        timerAmount = 5f;
        runSpawnTimer = true;

    }

    public void StartRespawn()
    {
        timerAmount -= Time.deltaTime;

        if(timerAmount <= 0)
        {
            runSpawnTimer = false;  
        }

    }
}

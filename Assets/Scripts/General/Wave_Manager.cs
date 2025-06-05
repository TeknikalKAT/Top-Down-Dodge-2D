using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public GameObject[] lightningForms;
    public float maxSpawnTime = 2f;      
    public float minSpawnTime = 1f;
    public float waveTime= 20f;
}
public class Wave_Manager : MonoBehaviour
{
    [SerializeField] Wave[] waves;
    [SerializeField] Text waveTimeText;
    Wave currentWave;
    int currentWaveNumber;
    float spawnTime;
    float _waveTime;
    bool waveStart;
    private void Start()
    {
        currentWaveNumber = -1;
        waveStart = false;
        StartCoroutine(WaitPeriod());
    }
    private void Update()
    {
        if(waveStart)
        {
            WaveAction();
        }

        waveTimeText.text = Math.Round(_waveTime,2).ToString();
    }
    void WaveAction()
    {
        spawnTime -= Time.deltaTime;
        _waveTime -= Time.deltaTime;

        if(spawnTime <= 0)
        {
            SpawnLightning();
        }
        if(_waveTime <= 0)
        {
            _waveTime = 0;
            waveStart = false;
            StartCoroutine(WaitPeriod());
        }
    }

    void SpawnLightning()
    {
        //lightning properties
        Debug.Log("Spawned Lightning!");
        spawnTime = UnityEngine.Random.Range(currentWave.minSpawnTime, currentWave.maxSpawnTime);

    }
    IEnumerator WaitPeriod()   //time to start a wave
    {
        Debug.Log("New Wave Coming Up!");
        yield return new WaitForSeconds(5);
        if (currentWaveNumber + 1 != waves.Length)
        {
            currentWaveNumber += 1;
            currentWave = waves[currentWaveNumber];
            SetTimes();
            waveStart = true;
        }
        else
        {
            Debug.Log("Game Complete");
        }
    }
    void SetTimes()
    {
        spawnTime = UnityEngine.Random.Range(currentWave.minSpawnTime, currentWave.maxSpawnTime);
        _waveTime = currentWave.waveTime;
    }
}

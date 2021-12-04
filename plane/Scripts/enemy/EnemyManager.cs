using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{

    public GameObject RandomEnery =>
        this.eneryList.Count == 0 ? null : this.eneryList[Random.Range(0, this.eneryList.Count)];
    public int WaveNum => waveAmount;

    public float WaveWaitTime => waitWaveTime;

    public GameObject waveUI;
    public GameObject[] enemyPres;

    public int minEnemyAmount = 4;
    
    public int maxEnemyAmount  = 10;

    public float timebetween = 1f;

    public int waveAmount = 1;

    private int enemyAmout;

    private WaitForSeconds waitTimeBetweenSpwan;
    
    private WaitForSeconds waitWaveTimeSpwan;


    public List<GameObject> eneryList;

    private WaitUntil waitUntil;

    public bool spawnEnery = true;

    public float waitWaveTime = 8f;

    protected override void Awake()
    {
        base.Awake();
        eneryList = new List<GameObject>();
        waitTimeBetweenSpwan = new WaitForSeconds(this.timebetween);
        waitWaveTimeSpwan = new WaitForSeconds(this.waitWaveTime);
        this.waitUntil = new WaitUntil(NoEnemy);
    }

    IEnumerator Start()
    {
        while (this.spawnEnery)
        {
            yield return this.waitUntil;
            this.waveUI.SetActive(true);
            yield return this.waitWaveTimeSpwan;
            this.waveUI.SetActive(false);
            yield return StartCoroutine(nameof(RandomSpawnCoroutiorn));
        }
        
    }

    IEnumerator RandomSpawnCoroutiorn()
    {
        this.enemyAmout = Mathf.Clamp(this.enemyAmout, this.minEnemyAmount +this.waveAmount/3, this.maxEnemyAmount);
        for (int i = 0; i < enemyAmout; i++)
        {
            eneryList.Add(PoolManager.Release(this.enemyPres[Random.Range(0, enemyPres.Length)]));
            yield return waitTimeBetweenSpwan;

        }

        this.waveAmount += 1;
    }

    bool NoEnemy()
    {
        return this.eneryList.Count == 0;
    }

    public void RemoveList(GameObject enemy)
    {
        this.eneryList.Remove(enemy);
    }
}

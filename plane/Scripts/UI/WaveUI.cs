
using System;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    private Text waveText;
    void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        this.waveText = this.GetComponentInChildren<Text>();
    }

    private void OnEnable()
    {
        this.waveText.text = "- WAVE " + EnemyManager.instance.WaveNum + " - ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

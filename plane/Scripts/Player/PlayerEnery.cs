using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnery : Singleton<PlayerEnery>
{

    public EneryBar eneryBar;
    public  int max = 100;

    public  int percent = 1;

    public int enery;
    
    // Start is called before the first frame update
    void Start()
    {
        this.eneryBar.Initialazle(this.enery,max);
        this.Obtain(max);
    }

    public void Obtain(int value)
    {
        if (this.enery == max)
        {
            return;
        }
        this.enery += value;
        this.enery = Mathf.Clamp(this.enery,0, max);
        this.eneryBar.updateStatus(this.enery,max);
    }

    public bool isEnougth(int value)
    {
        return this.enery >= value;
    }

    public void Use(int value)
    {
        this.enery -= value;
        this.eneryBar.updateStatus(this.enery,max);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using System.Collections;
using System;

public class Youtube_Skills : MonoBehaviour, IUpgrade {

    public string Name;

    public int RequiredPoints;

    string IUpgrade.Name
    {
        get
        {
           return this.Name;
        }

        set
        {
            this.Name = value;
        }
    }

    int IUpgrade.RequiredPoints
    {
        get
        {
            return this.RequiredPoints;
        }

        set
        {
            this.RequiredPoints = value;
        }
    }

    public bool Upgrade()
    {
        Debug.Log("Upgrade values... For youtube");
        return true;

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

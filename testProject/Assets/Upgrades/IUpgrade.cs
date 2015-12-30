using UnityEngine;
using System.Collections;

public interface IUpgrade {

    //Name of the upgrade
    string Name
    {
        get;
        set;
    }

    //The required points to upgrade
    int RequiredPoints
    {
        get;
        set;
    }

    //The method that executes the upgrade (Returns false if upgrade can't be done, true if it can be done)
    bool Upgrade();

    

}

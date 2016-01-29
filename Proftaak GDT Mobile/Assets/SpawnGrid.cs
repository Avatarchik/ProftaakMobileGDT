using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
public class SpawnGrid : MonoBehaviour
{
    private List<SpawnPoint> _SpawnObjects = new List<SpawnPoint>();

    //Debug shit

    [Range(1, 500)]
    public int radius;

    void Awake()
    {
        //Get all objects on runtime
        _SpawnObjects = this.GetComponentsInChildren<SpawnPoint>().ToList();
    }
    
    public List<SpawnPoint> GetFreePoints(List<SpawnPoint> spawnPoints)
    {
        return spawnPoints.Where(x => !x.taken).ToList();
    }

    /// <summary>
    /// Method searches for a random location on the map. Give true for a list of availible points and false for all points.
    /// </summary>
    /// <param name="searchForFreePoints"></param>
    /// <returns></returns>
    public Vector2 GetRandomLocation(bool searchForFreePoints, List<SpawnPoint> points, bool setTaken)
    {
        if (points.IsNullOrEmpty())
        {
            return Vector2.zero;
        }
        SpawnPoint temp = points[(Random.Range(0, points.Count - 1))];
        temp.taken = setTaken;
        return temp.location;
    }

    public List<SpawnPoint> GetLocationsClosestToCenter(int radius, Vector2 center, bool debug)
    {
        List<SpawnPoint> closestPoints = new List<SpawnPoint>();

        foreach(SpawnPoint spawn in GetFreePoints(_SpawnObjects))
        {
           if(Vector2.Distance(center, spawn.location) <= radius)
            {
                closestPoints.Add(spawn);

                if (debug)
                {
                    Debug.Log(spawn.name + " : " + spawn.location.x + " | " + spawn.location.y);
                }
            }
            
        }

        return closestPoints;


    }
}

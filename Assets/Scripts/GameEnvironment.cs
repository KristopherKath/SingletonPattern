using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sealed keyword makes it so other classes cannot inherit from this class
public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    //This makes only one instance of the GameEnvironment singleton class
    public static GameEnvironment Singleton
    {
        get
        {
            //This is the equivalant of a constructor for a singleton
            if (instance == null)
            {
                instance = new GameEnvironment();
                instance.Goals.AddRange(GameObject.FindGameObjectsWithTag("goal"));
            }
            return instance;
        }
    }

    private List<GameObject> goals = new List<GameObject>();
    public List<GameObject> Goals { get { return goals; } }


    private List<GameObject> obstacles = new List<GameObject>();
    //Obstacles is a property that provides a get/set method. Combination of a variable and a method
    public List<GameObject> Obstacles { get { return obstacles; } }




    public GameObject GetRandomGoal() => goals[Random.Range(0, goals.Count)];

    public void AddObstacles(GameObject go) => obstacles.Add(go);
    public void RemoveObstacles(GameObject go)
    {
        obstacles.RemoveAt(obstacles.IndexOf(go));
        GameObject.Destroy(go);
    }
}

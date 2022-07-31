using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleManager : MonoBehaviour
{
    public List<GameObject> allEnemies = new List<GameObject>();
    public List<GameObject> allFriendlies = new List<GameObject>();


    void Awake()
    {
        FindAllEnemies();
        FindAllFriendlies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindAllFriendlies()
    {
        allFriendlies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Friendly"));
    }

    void FindAllEnemies()
    {
        allEnemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }
}

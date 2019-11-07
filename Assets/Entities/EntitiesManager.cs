using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesManager : MonoBehaviour
{
    private int id;

    // Start is called before the first frame update
    void Start()
    {
        id = 1;
        int length = FindObjectsOfType<Player>().Length;
        for (int i=0;i< length; i++)
        {
            FindObjectsOfType<Player>()[i].playerID = id;
            id++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

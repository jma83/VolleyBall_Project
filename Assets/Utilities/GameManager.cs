using System;

using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private Player currentPlayer;
    bool spawned = false;
    bool paused;
    
    
    private void Start()
    {
        if (spawned == false)
        {
            spawned = true;
            paused = true;
            DontDestroyOnLoad(gameObject);
           
        }
        else
        {
            Debug.Log("DESTURUCCION!");
            DestroyImmediate(gameObject);
        }
    }
    public void InitializeScene()
    {
        Debug.Log("INICIALIZO");
        Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");

        FindPlayer();
        Load();
    }
    private void OnApplicationQuit()
    {
        Save();
    }

    public void SetPausedGame(bool v)
    {
        paused = v;
    }

    public bool GetPausedGame()
    {
        return paused;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            Save();

    }

    public Player CurrentPlayer
    {       
        get { FindPlayer(); return currentPlayer; }
    }

    public void ExitGame()
    {
        Debug.Log("Hola y adios");
        Application.Quit();
    }

    private void FindPlayer()
    {
        if (currentPlayer == null)
        {
            currentPlayer = FindObjectOfType<Player>();
        }

    }
    public void Save()
    {
        //save scores

    }

    public void Load()
    {
       //load scores

    }

    
}
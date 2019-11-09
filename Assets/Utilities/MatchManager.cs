using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{

    int maxPoints;
    int numPlayers;
    int[] playerPoints;
    float targetTime;
    int defaultTime;

    // Start is called before the first frame update
    void Start()
    {
        numPlayers = GameObject.FindObjectsOfType<Player>().Length;
        playerPoints = new int[numPlayers];
        defaultTime = 4;
        targetTime = defaultTime;
        SetMaxPoints(5);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (targetTime >= 1)
        {
            targetTime -= Time.deltaTime;
        }
        else
        {
            GameManager.Instance.SetPausedGame(false);
        }
    }

    public bool IncreasePoint(int playerID)
    {
        playerID--;
        if (playerID >= numPlayers || playerID < 0)
            return false;

        GameManager.Instance.SetPausedGame(true);
        playerPoints[playerID]++;
        CheckWin(playerID);
        targetTime = defaultTime;
        return true;
    }

    public bool DecreasePoint(int playerID)
    {
        playerID--;
        if (playerID >= numPlayers || playerID < 0)
            return false;

        GameManager.Instance.SetPausedGame(true);
        playerPoints[playerID]++;
        targetTime = defaultTime;
        return true;
    }

    public void SetMaxPoints(int points)
    {
        maxPoints = points;
    }

    void CheckWin(int i)
    {
        /*
        if (playerPoints[i] >= maxPoints)
        {
            string str = "¡GANA EL JUGADOR " + playerPoints[i] + "!\n";
            WindowAlert.Instance.CreateSelectWindow(str,
                                                    true,
                                                    SceneManagerVolley.Instance.GoMatch,
                                                    SceneManagerVolley.Instance.GoMenu
                                                    );
        }*/
    }

    public int GetTimer()
    {
        return (int)targetTime;
    }

    public int GetPlayerPoints(int i)
    {
        if (i >= numPlayers || i < 0)
            return -1;
        return playerPoints[i];
    }

    public int[] GetAllPlayerPoints()
    {
        return playerPoints;
    }

    
    

}

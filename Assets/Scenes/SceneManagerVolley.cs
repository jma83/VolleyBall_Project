using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerVolley : Singleton<SceneManagerVolley>
{
    private string currentScene;
    private string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void InitScene()
    {
        currentScene = nextScene;
        nextScene = null;
        //The rest implements in children
    }

    public void InicializeNextScene(string s)
    {
        if (s != null){
            nextScene = s;
            SceneChangeManager.Instance.GoToScene(nextScene, null);
        }
    }

    public void GoMatch()
    {
        InicializeNextScene(GameConstants.SCENE_MATCH);        
    }
    public void GoMenu()
    {
        InicializeNextScene(GameConstants.SCENE_MENU);
    }
}

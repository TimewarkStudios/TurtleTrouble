using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public string LevelName;
    public void OnClick()
    {
        Application.LoadLevel(LevelName);   

        //Debug.Log(Application.isEditor);
        //if (Application.isEditor)
        //{
        //    string LevelScene = "_Scene/" + LevelName + ".unity";
        //    Debug.Log(LevelScene);
        //    UnityEditor.EditorApplication.OpenScene(LevelScene);    
        //}
        //else
        //{
        //    Application.LoadLevel(LevelName);
        //}

        
    }
}
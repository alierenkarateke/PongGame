using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Change scene according scene
    public void MoveToScene(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }

    // Close
    public void Quit()
    {
        Application.Quit();
    }
}

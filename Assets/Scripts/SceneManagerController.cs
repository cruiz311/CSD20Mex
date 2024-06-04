using Cinemachine;
using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    private void Update()
    {

    }
    public void OnClickChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

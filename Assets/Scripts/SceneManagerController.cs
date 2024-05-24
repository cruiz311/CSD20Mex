using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    public void OnClickChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

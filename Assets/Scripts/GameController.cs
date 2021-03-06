using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] TMP_Text pointer;
    [SerializeField] Animator flagAnimator;
    public static int pointCount = 0;

    void Update()
    {
        pointer.text = pointCount.ToString();

        if (pointCount == 10)
        {
            flagAnimator.SetBool("isFinished", true);
        }
    }

    public static void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        pointCount = 0;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
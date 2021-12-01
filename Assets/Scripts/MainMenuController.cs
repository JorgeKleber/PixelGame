using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void StartGame()
   {
       SceneManager.LoadScene("Scene1");
   }

   public void ShowSettings()
   {
       Debug.LogWarning("Ainda por implementar");
   }

   public void AboutScreen()
   {
       Debug.LogWarning("Ainda por implementar");
   }
}

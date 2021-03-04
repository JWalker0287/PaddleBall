using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   public void PlayPongVsAI()
   {
       SceneManager.LoadScene("PongVsAI");
   }
   public void PlayPongMultiplayer()
   {
       SceneManager.LoadScene("PongMultiplayer");
   }
   public void PlayBreakout()
   {
       SceneManager.LoadScene("Breakout");
   }
   public void Quit()
   {
       Application.Quit();
   }
}

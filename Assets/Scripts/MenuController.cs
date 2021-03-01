using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   public void PlayPong()
   {
       SceneManager.LoadScene("Pong");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonFunc : MonoBehaviour
{
   public StoryCamera StoryCamera;
   public GameObject MainMenu;
   public GameObject Developers;
   
   public void Exit(){
      Application.Quit();
   }


   public void StartGame(){
      StoryCamera.StartMove();
   }


   public void CloseCanvas(){
      
   }

   public void ShowDevelopers(){
      Developers.SetActive(true);
      MainMenu.SetActive(false);
   }
   
   
   
}

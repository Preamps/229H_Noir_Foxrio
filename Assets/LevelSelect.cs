using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
   public void OpenLevel(int levelId)
   {
	   string levelname = "lvl " +	levelId;
	   SceneManager.LoadScene(levelname);
   }
    public void QuitGame()
   {
	   Application.Quit();
   }
}

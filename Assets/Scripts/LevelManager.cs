using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	[SerializeField] int timeToWait = 4;

	private int currentSceneIndex;

	//public float autoLoadNextLevelAfter;

	private void Start()
	{
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		if(currentSceneIndex == 0)
		{
			StartCoroutine(WaitForTimeAndLoadNextLevel());
		}

		//if(autoLoadNextLevelAfter <= 0){
		//	//Debug.Log("Level auto load disabled, use a positive number in seconds");
		//}else{
		//	Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		//}		
	}

	private IEnumerator WaitForTimeAndLoadNextLevel()
	{
		yield return new WaitForSeconds(timeToWait);
		LoadNextLevel();
	}

	public void LoadLevel(string name)
	{		
		SceneManager.LoadScene(name);

		//Debug.Log("Level load requested for: "+ name);
		//Application.LoadLevel(name);
	}

	public void QuitRequest(){
		//Debug.Log("Quit");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		SceneManager.LoadScene(currentSceneIndex + 1);

		//Application.LoadLevel(Application.loadedLevel + 1 );	
	}
}

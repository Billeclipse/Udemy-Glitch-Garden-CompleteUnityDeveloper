using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	
	public float levelSeconds = 100f;
	
	private Slider slider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private GameObject winLabel;
	private bool isEndOfLevel = false;
	
	void Start () {		
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();	
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindYouWon();
		winLabel.SetActive(false);
	}
	
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;	
		if ( Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel){
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects();
		audioSource.Play ();
		winLabel.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}
	
	//Destroys all objects with tag destroyOnWin
	void DestroyAllTaggedObjects(){
		GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach(GameObject obj in taggedObjects){
			Destroy(obj);
		}
	}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}

	void FindYouWon (){
		winLabel = GameObject.Find ("You Won");
		if (!winLabel) {
			Debug.LogWarning ("Not You Won label found!");
		}
	}
}
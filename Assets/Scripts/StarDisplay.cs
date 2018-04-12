using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {
	
	private Text text;
	private int stars;
	
	public enum Status {SUCCESS, FAILURE};
	
	void Start () {
		stars = 100;
		text = GetComponent<Text>();
		UpdateDisplay();
	}
	
	void Update () {
	}
	
	public void AddStars(int amount){
		stars += amount;
		UpdateDisplay();
	}
	
	public Status UseStars(int amount){
		if( stars >= amount ){
			stars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;	
	}
	
	private void UpdateDisplay(){
		text.text = stars.ToString();
	}
}
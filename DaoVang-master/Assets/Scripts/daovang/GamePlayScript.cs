using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GamePlayScript : MonoBehaviour {
	public Text timeText;
	public Text scoreText;
	public Text targetText;
	public int score;
	public int time;
	public int targetScore;

	public GameObject LoseGame;
	public Text txtGold_L, txtTarget_L;
	public GameObject WinGame;
	public Text txtGold_W, txtTarget_W;



	public GameObject []levelsVang;
	public int level;
	public bool endgame = false;
	// Use this for initialization
	void Start () {
		startGame();
		level = 0;
		this.StartCoroutine("Do");
	}
	public IEnumerator Do ()
	{
		bool add = true;
		while(add){
			yield return new WaitForSeconds (1);
			if(time > 0) {
				time --;
			}
			if(time <= 0 && !endgame) {
				endGame();
//				StopCoroutine("Do");
			}
		}
	}

	void endGame() {
		Time.timeScale = 0;
		endgame = true;
		if (score >= targetScore)
        {
			txtGold_W.text = "Gold: " + score.ToString();
			txtTarget_W.text = "Target: " + targetScore.ToString();
			WinGame.SetActive(true);
		}
		else
        {
			txtGold_L.text = "Gold: " + score.ToString();
			txtTarget_L.text = "Target: " + targetScore.ToString();
			LoseGame.SetActive(true);
		}
		level ++;
	}

	void startGame() {
		LoseGame.SetActive(false);
		WinGame.SetActive(false);
		targetText.text = targetScore.ToString();
		endgame = false;
		time = 60;
		score = 0;
		for(int i = 0; i < levelsVang.Length; i++) {
			if(level == i) {
				levelsVang[i].SetActive(true);
			}else {
				levelsVang[i].SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = time.ToString();
		scoreText.text = score.ToString();
	}

	public void replay() {
		startGame();
	}
}

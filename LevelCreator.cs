using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCreator : MonoBehaviour
{
	public GameObject[] blanks;
	public Sprite[] arrows;
	public Rigidbody pelvisRB;
	public bool complete;
	public bool phaseComplete;
	public float swipeValue;
	public float breakTimer;
	public float phaseTimer;
	public int index;

	void Update()
	{
		ArrowGenerator();
		Scaler();
	}
	private void FixedUpdate()
	{
		BreakPhases();
		PlayerController();
	}
	void ArrowGenerator()
	{
		//Creates random arrows on top right bar.
		foreach (GameObject go in blanks)
		{
			if (go.GetComponent<Image>().sprite == null)
			{
				index = Random.Range(0, arrows.Length);
				go.GetComponent<Image>().sprite = arrows[index];
			}
		}
	}

	void Phases()
	{
		/*Images and forces are connected. For example if there is a Right arrow on bottom bar, after few seconds
		 force applies to left, because of centrifugal force. Values and durations can change, but we have to change mass and some forces too. */
		
		
		if (blanks[1].GetComponent<Image>().sprite.name == "Left")
		{
			if (phaseTimer < 3)
			{
				
				phaseTimer += Time.deltaTime;
				pelvisRB.velocity = new Vector3(7, 0, 0);
				if (phaseTimer >= 3)
				{
					
					phaseTimer = 0;
					phaseComplete = true;
				}
			}			
		}
		if (blanks[1].GetComponent<Image>().sprite.name == "Right")
		{
			if (phaseTimer < 3)
			{
				
				phaseTimer += Time.deltaTime;
				pelvisRB.velocity = new Vector3(-7, 0, 0);
				if (phaseTimer >= 3)
				{
					
					phaseTimer = 0;
					phaseComplete = true;
				}
			}
		}
		if (blanks[1].GetComponent<Image>().sprite.name == "sLeft")
		{
			if (phaseTimer < 3)
			{
				
				phaseTimer += Time.deltaTime;
				pelvisRB.velocity = new Vector3(3.5f * phaseTimer, 0, 0);
				if (phaseTimer >= 3)
				{
					
					phaseTimer = 0;
					phaseComplete = true;
				}
			}
		}
		if (blanks[1].GetComponent<Image>().sprite.name == "sRight")
		{
			if (phaseTimer < 3)
			{
				
				phaseTimer += Time.deltaTime;
				pelvisRB.velocity = new Vector3(-3.5f * phaseTimer, 0, 0);
				if (phaseTimer >= 3)
				{
					
					phaseTimer = 0;
					phaseComplete = true;
				}
			}
		}
	}

	void BreakPhases()
	{
		/*There are 5 seconds between phases, after that checks if phase is complete, bottom blank gets empty then,
		 gets top image, after that creates a random top arrow image. In this version of a game it's like endless,
		 if player keep its score above 0. If we need I can change it to designed level system.*/
		breakTimer += Time.deltaTime;
		if (breakTimer > 5)
		{
			Phases();
			if (phaseComplete == true)
			{
				complete = true;
				blanks[1].GetComponent<Image>().sprite = null;
				if (complete == true)
				{
					blanks[1].GetComponent<Image>().sprite = blanks[0].GetComponent<Image>().sprite;
					if (complete == true && blanks[0].GetComponent<Image>().sprite != null)
					{
						blanks[0].GetComponent<Image>().sprite = null;
						complete = false;
					}
				}
				breakTimer = 0;
				phaseComplete = false;
			}
		}
	}
	void PlayerController()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			pelvisRB.velocity = new Vector3(-swipeValue * Time.deltaTime, 0, 0);
			Debug.Log("a");
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pelvisRB.velocity = new Vector3(swipeValue * Time.deltaTime, 0, 0);
			Debug.Log("b");
		}
	}

	void Scaler()
	{
		if (phaseTimer > 0.5)
		{
			LeanTween.scale(blanks[1], new Vector3(4, 4, 4), 0.5f);
		}
		else LeanTween.scale(blanks[1], new Vector3(3, 3, 3), 0.5f);
	}
}

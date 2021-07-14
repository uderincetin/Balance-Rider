using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public Rigidbody pelvisRB;
    public GameObject bar;
    public GameObject point;
    public TextMeshProUGUI scoreText;
    public int score ;
    public float scoreTimer;
    public float negativeTimer;


    void Update()
    {
        //Top bar connected to body, but body moves max 5 units because of that I multiplied it. If game ends bar stops moving.
        if (score >= 0)
        {
            bar.transform.position = new Vector3(pelvisRB.transform.position.x * 70, bar.transform.position.y, bar.transform.position.z);
        }
        else return;
        
        //With this statements bar doesn't go outside of mainbar.
        if (bar.transform.localPosition.x > 175)
        {
            bar.transform.localPosition = new Vector3(175, bar.transform.localPosition.y, bar.transform.localPosition.z);
        }
        if (bar.transform.localPosition.x < -175)
        {
            bar.transform.localPosition = new Vector3(-175, bar.transform.localPosition.y, bar.transform.localPosition.z);
        }

        scoreText.text = "Score :" + score;
        /*Score depends on bar's location if bar color is red, player starts to lose score every 1 sec. 
          if player on safe zone, player gains points every 1 sec. also if statements are true timers become 0 and makes it a loop*/
        if (bar.transform.localPosition.x > 100 || bar.transform.localPosition.x < -100)
        {
            negativeTimer += Time.deltaTime;
            if (negativeTimer > 1)
            {
                score -= 100;
                negativeTimer = 0;
            }

        }
        else
        {
            scoreTimer += Time.deltaTime;
            if(scoreTimer > 1)
            {
                score += 10;
                scoreTimer = 0;
            }
        }
        /*It's basically score can be lower than 0 in this system but usually we don't want to say something like Score : -200,
         * I use'd ragdoll tool for most of the physics, but I needed to force for stand up a player.I think 0 is our lose condition, after that player falls.
         */
        if (score <= 0)
        {
            score = 0;
            point.SetActive(false);
        }
    }

}

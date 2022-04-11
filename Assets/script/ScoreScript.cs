using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public Text PlayerScoreText;
    private int playerScoreValue;
    // Start is called before the first frame update
    void Start()
    {
        playerScoreValue = 0;
        PlayerScoreText.text = "Score : " + playerScoreValue;
    }

    public void OnTriggerEnter2D(Collider2D gems)
    {
        if(gems.tag == "Gems")
        {
            playerScoreValue+=100;
            Destroy(gems.gameObject);
            PlayerScoreText.text = "Score : " + playerScoreValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

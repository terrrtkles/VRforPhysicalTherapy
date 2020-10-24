using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoring : MonoBehaviour
{
    public TextMesh scoreText;
    protected int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMesh>();
        score = 0;
        updateScore();
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
    }

    protected void updateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}

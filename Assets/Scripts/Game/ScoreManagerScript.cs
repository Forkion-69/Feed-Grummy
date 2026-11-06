using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{

    public static int score;
    public Text scoreText;
    public Text HealtText;
    

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        HealtText.text = "Health:" + GrummyManager.playerHealth.ToString();
    }


    public static void AddScore(int i)
    {
        score += i;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}

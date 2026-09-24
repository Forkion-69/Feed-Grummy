using UnityEngine;
using UnityEngine.SceneManagement;

public class GrummyManager : MonoBehaviour
{

    public static int playerHealth = 5;
    public static string deathScene = "DeathScene";

    public static void DeductHealth(int Damage)
    {
        playerHealth -= Damage;
    }
    
    public static void AddHealth(int heal)
    {
        playerHealth += heal;
    }

    public static void GameOver()
    {
        SceneManager.LoadScene(deathScene);
    }

    private void FixedUpdate()
    {
        if(playerHealth <= 0)
            GameOver();
    }

    void Start()
    {
        playerHealth = 5;
    }

}

using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [Header("References")]
    public GameObject fireballPrefab;
    public GameObject foodPrefab;
    public ProjectileHandler HeaderFile;

    [Header("Spawn Points")]
    public List<Vector3> SpawnPoints = new List<Vector3>();


    private void Start()
    {
        InvokeRepeating(nameof(Spawning),1f,HeaderFile.spawnerTime);
    }

    public void Spawning()
    {
        float _random1 = Random.Range(SpawnPoints[0].x, SpawnPoints[1].x);
        float _random2 = Random.Range(SpawnPoints[2].x,SpawnPoints[3].x);

        int _decide = Random.Range(0,3);

        switch (_decide)
        {
            case 0: 
            Instantiate(fireballPrefab,new Vector3(_random1,SpawnPoints[0].y,0),Quaternion.identity);
            Instantiate(fireballPrefab,new Vector3(_random2,SpawnPoints[2].y,0),Quaternion.identity);
            break;
            case 1: 
            Instantiate(foodPrefab,new Vector3(_random1,SpawnPoints[0].y,0),Quaternion.identity);
            Instantiate(foodPrefab,new Vector3(_random2,SpawnPoints[2].y,0),Quaternion.identity);
            break;
            case 2: 
            Instantiate(fireballPrefab,new Vector3(_random1,SpawnPoints[0].y,0),Quaternion.identity);
            Instantiate(foodPrefab,new Vector3(_random2,SpawnPoints[2].y,0),Quaternion.identity);
            break;
        }
        
    }

    public bool ProbabilityCheck(int itemProbability)
    {
        float rnd = Random.Range(1, 101);
        if (rnd <= itemProbability)
            return true;
        else
            return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


[System.Serializable]

#region Declarations

public class Wave
{
    public int wCount = 1;
    public int count = 3;
    public float speed = 3.5f;
    public float timeForBurst = 1f;
    public float waitTime = 3f;
}   

public enum WaveState
{
    SpeedChange,
    TimeChange,
    CountChange,
}

public enum ProjectileSpeedState
{
    Slow,
    Medium,
    Fast,
    Inhumane,
}

#endregion

public class ProjectileHandler : MonoBehaviour
{   
    [Header("References")]
    public GameObject fireballPrefab;
    public GameObject foodPrefab;

    [Header("Spawn Points")]
    public List<Vector3> SpawnPoints = new List<Vector3>();


    [Header("Vars")]
    public float fireballMoveSpeed= 3.5f;
    public float baseFoodSpeed = 3.5f;

    public float spawnerTime = 3;

    [SerializeField] private int periodCount = 1;

    [Header("Class & Enum")]

    public Wave Wave;
    public WaveState WaveState;
    private ProjectileSpeedState SpeedState;


    #region Runtime


    void Start()
    {
        SpeedState = 0;
        // StartCoroutine(nameof(GameLoop));

    }

    void Update()
    {
        switch (SpeedState)
        {
            case ProjectileSpeedState.Slow:
                fireballMoveSpeed = 3.5f;
                break;
            case ProjectileSpeedState.Medium:
                fireballMoveSpeed = 4f;
                break;
            case ProjectileSpeedState.Fast:
                fireballMoveSpeed = 4.8f;
                break;
            default:
                Debug.LogError("State OverFlow");
                break;
        }
    }

    #endregion

    #region GameLoop

    IEnumerator GameLoop()
    {
        while (true)
        {
            //wait for time waitTime
            yield return new WaitForSeconds(Wave.waitTime);

            //burst projectile by CountNumbers, speed state and time between
            yield return StartCoroutine(nameof(BurstSpawn));
            
            //trigger next change
            if(periodCount == 1)
            {
                StateSwitch();
            }else if(periodCount == 2)
            {
                TimeSwitch();
            }else if (periodCount == 3)
            {
                Wave.count++;
            }else{Debug.LogError("wtf bro");}
            
            Wave.wCount +=1;
            CountPeriod(1);
        }

    }

    #endregion 

    #region Spawning and stuff

    public IEnumerator BurstSpawn()
    {   
        for (int i = 0; i < Wave.count; i++)
        {
            yield return new WaitForSeconds(Wave.timeForBurst);

            float _random1 = UnityEngine.Random.Range(SpawnPoints[0].x, SpawnPoints[1].x);

            if (ProbabilityCheck(50))
            {
                if (ProbabilityCheck(50))
                {
                    Instantiate(foodPrefab,new Vector3(_random1,SpawnPoints[0].y,0),Quaternion.identity);
                }else{Instantiate(fireballPrefab,new Vector3(_random1,SpawnPoints[0].y,0),Quaternion.identity);}
            }
            else
            {
            if (ProbabilityCheck(50))
                {
                    Instantiate(foodPrefab,new Vector3(_random1,SpawnPoints[2].y,0),Quaternion.identity);
                }else{Instantiate(fireballPrefab,new Vector3(_random1,SpawnPoints[2].y,0),Quaternion.identity);}
            }

        }

        yield break;
    }

    #endregion
    #region Counters and Timers

    private void CountPeriod(int Increase)
    {
        if(periodCount < 4)
        {
            periodCount += Increase;
        }else{periodCount = 0;}
    }

    private void StateSwitch()
    {
        SpeedState = SpeedState switch
        {
            ProjectileSpeedState.Slow => ProjectileSpeedState.Medium,
            ProjectileSpeedState.Medium => ProjectileSpeedState.Fast,
            ProjectileSpeedState.Fast => ProjectileSpeedState.Slow,
            _ => ProjectileSpeedState.Slow       
        };
    }

    private void TimeSwitch()
    {
        float x;
        float quotient1 = 10f;

        x = (0.1f + Wave.waitTime)/quotient1;

        float y;
        float quotient2 = 50f;

        y = (0.01f + Wave.timeForBurst)/quotient2;

        Wave.timeForBurst -= y;
        Wave.waitTime -= x;
        Wave.timeForBurst = math.clamp(Wave.timeForBurst,0.1f,100f);
        Wave.waitTime = math.clamp(Wave.waitTime,1f,100f);
    }

    public bool ProbabilityCheck(int itemProbability)
    {
        float rnd = UnityEngine.Random.Range(1, 101);
        if (rnd <= itemProbability)
            return true;
        else
            return false;
    }

    #endregion

    #region nobody talks about this region
    public void NoTheySeriouslyDont()
    {
        StartCoroutine(nameof(BurstSpawn));
    }

    #endregion
}

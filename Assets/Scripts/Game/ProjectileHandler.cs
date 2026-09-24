using System.Collections;
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
        StartCoroutine(nameof(GameLoop));
    }

    void Update()
    {
        switch (SpeedState)
        {
            case 0:
                fireballMoveSpeed = 3.5f;
                break;
            case (ProjectileSpeedState)1:
                fireballMoveSpeed = 4f;
                break;
            case (ProjectileSpeedState)2:
                fireballMoveSpeed = 4.8f;
                break;
            case (ProjectileSpeedState)5:
                fireballMoveSpeed = 5.5f;
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
            

            //trigger next change
            if(periodCount == 1)
            {
                StateSwitch();
            }
            

            Wave.wCount +=1;
            //check factors for next change
            CountPeriod(1);
        }

    }

    #endregion 

    #region Counters and Timers

    private void CountPeriod(int Increase)
    {
        if(periodCount < 4)
        {
            periodCount++;
        }else{periodCount = 0;}
    }

    private void StateSwitch()
    {
        SpeedState = SpeedState switch
        {
            ProjectileSpeedState.Slow => ProjectileSpeedState.Medium,
            ProjectileSpeedState.Medium => ProjectileSpeedState.Fast,
            ProjectileSpeedState.Fast => ProjectileSpeedState.Inhumane,
            ProjectileSpeedState.Inhumane => ProjectileSpeedState.Slow,
            _ => ProjectileSpeedState.Slow       
        };
    }

    #endregion
}

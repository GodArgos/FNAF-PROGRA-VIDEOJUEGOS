using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    #region Singleton
    public static TimeManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [Header("Variables")]
    [Space(5)]
    [Tooltip("Hours the night will have.")]
    public int hours = 6;
    [Tooltip("Time for each game hour (in seconds).")]
    public float time = 90;

    private int targetHour;
    private float targetTime;

    private void Start()
    {
        targetHour = hours;
        targetTime = time;
    }

    private void Update()
    {
        if(targetHour > 0)
        {
            targetTime -= Time.deltaTime;

            if(targetTime <= 0)
            {
                Debug.Log("HOUR " + targetHour + " HAS ENDED.");
                targetHour--;
                targetTime = time;
            }
        }
        else
        {
            Debug.Log("THE NIGHT HAS ENDED.");
        }
    }
}

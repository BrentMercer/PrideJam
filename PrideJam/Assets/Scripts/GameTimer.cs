using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GameTimer : ScriptableObject
{
    public float Timer = 50f;
    public float StartTimerValue = 50;
    public int CountBy = 0;
    public void StartCount()
    {
        CountBy = 1;
    }
    public void StopCount()
    {
        CountBy = 0;
    }
    public void ResetTimer()
    {
        Timer = StartTimerValue;
    }
    public void NextLevelTimer(int Level)
    {
        ResetTimer();
        Timer -= Level * 5;
    }
}

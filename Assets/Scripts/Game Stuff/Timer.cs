using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public bool countTime;
    public bool activateTrigger;

    // Start is called before the first frame update
    void Start()
    {
        countTime = false;
    }

    public void BeginTimer()
    {
        countTime = true;
        timer = 0f;
        StartCoroutine(StartCounting());
    }

    public void LoopTimer(float increments)
    {
        countTime = true;
        timer = 0f;
        StartCoroutine(TimerLoop(increments));
    }

    public void StopCounting()
    {
        countTime = false;
    }

    private IEnumerator StartCounting()
    {
        while (countTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator TimerLoop(float increments)
    {
        while (countTime)
        {
            timer += Time.deltaTime;
            if (timer >= increments)
            {
                activateTrigger = true;
                timer = 0f;
                yield return null;
                activateTrigger = false;
            }
                yield return null;
        }
    }
}

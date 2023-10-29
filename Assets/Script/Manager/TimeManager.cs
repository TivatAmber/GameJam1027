using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public float globalTime;
    // Start is called before the first frame update
    void Start()
    {
        globalTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        globalTime += Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public float globalTime;
    [SerializeField] TextMeshProUGUI meshPro;
    // Start is called before the first frame update
    void Start()
    {
        globalTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        globalTime += Time.deltaTime;
        meshPro.text = (Mathf.Round(globalTime)).ToString();
    }
}

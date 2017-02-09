using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageLamp : MonoBehaviour {

    public delegate void OnNextBeatEvent();
    public static OnNextBeatEvent nextBeatEventListeners;

    public GameObject bigLightsRoot;
    public GameObject smallLightsRoot;

    private List<Renderer> bigLights;
    private List<Renderer> smallLights;

    Material bigOff;
    Material bigOn;
    Material smallOff;
    Material smallOn;

    int bigCursor = -1;
    int frameCount = 0;

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        //frameCount++;
        //if (frameCount % 60 == 0)
        //    OnNextEvent();
	}

    void InitConfig()
    {
        var config = GameConfig.instance;
        bigOff = config.matBigLightOff;
        bigOn = config.matBigLightOn;
        smallOff = config.matSmallLightOff;
        smallOn = config.matSmallLightOn;
    }

    void InitReferences()
    {
        bigLights = new List<Renderer>();
        smallLights = new List<Renderer>();

        foreach (Transform item in bigLightsRoot.transform)
        {
            bigLights.Add(item.GetComponent<Renderer>());
        }

        foreach (Transform item in smallLightsRoot.transform)
        {
            smallLights.Add(item.GetComponent<Renderer>());
        }
    }

    void InitLightStates()
    {
        foreach (var light in smallLights)
        {
            TurnS(light, true);
        }

        foreach (var light in bigLights)
        {
            TurnB(light, false);
        }
    }

    void Init()
    {
        InitConfig();
        InitReferences();
        InitLightStates();
        nextBeatEventListeners += OnNextEvent;
    }

    void InitWithRandomLight()
    {
        bigCursor = UnityEngine.Random.Range(0, bigLights.Count);
    }

    void TurnS(Renderer smallLight, bool turnOn)
    {
        if (turnOn)
        {
            smallLight.material = smallOn;
        }
        else
        {
            smallLight.material = smallOff;
        }
    }

    void TurnB(Renderer bigLight, bool turnOn)
    {
        if (turnOn)
        {
            bigLight.material = bigOn;
        }
        else
        {
            bigLight.material = bigOff;
        }
    }

    public void OnNextEvent()
    {
        if (bigLights.Count > 0)
        {
            if (bigCursor >= 0)
            {
                TurnB(bigLights[bigCursor], false);
            }

            bigCursor = (bigCursor + 1) % bigLights.Count;

            TurnB(bigLights[bigCursor], true);
        }

    }
}

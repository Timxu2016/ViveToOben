using UnityEngine;
using System.Collections;

public class GameConfig : MonoBehaviour {

    public static GameConfig instance { get { return _instance; } }
    private static GameConfig _instance;

    void Awake()
    {
        _instance = this;
    }


    public Material matBigLightOff;
    public Material matBigLightOn;
    public Material matSmallLightOff;
    public Material matSmallLightOn;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

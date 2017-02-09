using UnityEngine;
using System.Collections;

public class RandomBeatController: MonoBehaviour {

    public GameObject[] Cylinders;
    public float updatetime = 1f;

    public float maxheight = 5f;
    public float minheight = 0.5f;

    float setheight;
    float temptime;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (temptime >= updatetime)
        {
            temptime = 0;
            UpdateHeight();
        }

        temptime += Time.deltaTime;

    }

    void UpdateHeight ()
    {
        for(int i = 0; i < Cylinders.Length; ++i)
        { 
            Vector3 tempScale = Cylinders[i].transform.localScale;
            setheight = Random.Range(minheight, maxheight);
            Cylinders[i].transform.localScale = new Vector3(tempScale.x, tempScale.y, setheight);
        }
    }

}

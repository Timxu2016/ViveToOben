using UnityEngine;
using System.Collections;

public class MeteroSpawn : MonoBehaviour
{
    public GameObject[] metero;
    public float time;

    void Awake()
    {
        for(int i=0;i<3;i++)
            Instantiate(metero[i]);
    }

	void Update () 
    {
        time += Time.deltaTime;
        if (time >= 30f)
        {
            for(int i=0;i<3;i++)
                Instantiate(metero[i]);
            time = 0;
        }
	}
}

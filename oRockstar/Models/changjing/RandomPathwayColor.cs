using UnityEngine;
using System.Collections;

public class RandomPathwayColor : MonoBehaviour {

    public Texture[] textures;
    public Texture[] textures_low;

    public float updatetime = 1f;
    float temptime;

    int setTextureIndex;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (temptime >= updatetime)
        {
            temptime = 0;
            UpdatePahtwayColor();
        }

        temptime += Time.deltaTime;

    }

    void UpdatePahtwayColor()
    {

        setTextureIndex = Random.Range(0, textures.Length-1);

        print(setTextureIndex);

        GetComponent<Renderer>().material.SetTexture("_MainTex", textures[setTextureIndex]);
        GetComponent<Renderer>().material.SetTexture("_MKGlowTex", textures[setTextureIndex]);
        GetComponent<Renderer>().material.SetTexture("_EmissionMap", textures[setTextureIndex]);

    }
}

using UnityEngine;
using System.Collections;

public class Anim : MonoBehaviour 
{
    public float speed = 4f;
    private float time;

	void Update ()
    {
        time += Time.deltaTime;
        transform.position += speed * Time.deltaTime * transform.forward;
        if (time > 20f)
            DestroyImmediate(this.gameObject);
	}
}

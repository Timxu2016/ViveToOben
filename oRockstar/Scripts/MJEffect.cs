using UnityEngine;
using System.Collections;


public class HitEffect
{
    float startTime;
    GameObject effectObj;
    float playTime = 0.5f;

    public HitEffect()
    {
        startTime = -100;
    }

    public HitEffect(GameObject _effectObj)
        : this()
    {
        Initialize(_effectObj);
    }

    public void Initialize(GameObject _effectObj)
    {
        effectObj = _effectObj;
    }

    public void Activate()
    {
        startTime = Time.time;
        effectObj.SetActive(true);
        ParticleSystem ps = effectObj.GetComponent<ParticleSystem>();
        ps.Stop();
        ps.Play();
    }

    public void Update()
    {
        float currentTime = Time.time;
        bool is_showing = (currentTime > startTime && currentTime < startTime + playTime);
        if (is_showing != effectObj.gameObject.activeSelf)
        {
            effectObj.gameObject.SetActive(is_showing);
        }
    }
}
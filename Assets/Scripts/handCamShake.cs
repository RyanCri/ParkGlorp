using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handCamShake : MonoBehaviour
{
    public float _amplitude = 1.15f;
    public float _frequency = 1.0f;

    public Transform _camera = null;

    private Vector3 MakeMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency) * _amplitude;
        pos.x += Mathf.Cos(Time.time * _frequency) * _amplitude * 2;
        // print(pos.y);
        return pos;
    }
    
    private void PlayMotion(Vector3 motion)
    {
        _camera.rotation = Quaternion.Euler(motion);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayMotion(MakeMotion());
    }
}
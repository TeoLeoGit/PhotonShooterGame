using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTargetFollower : MonoBehaviour
{
    public static AimTargetFollower instance;

    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

    }
    public void Init()
    {
        _transform = GameObject.Find("AimTarget").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_transform != null)
            transform.position = _transform.position; 

    }
}

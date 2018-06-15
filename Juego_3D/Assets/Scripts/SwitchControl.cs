﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwitchControl : MonoBehaviour
{
    public Transform platform;
    public Vector3 targetPoint;
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Active()
    {
        Debug.Log("Activater" + name);
        //Call ienumerator here on a coroutine
        StartCoroutine(MovePlatformToTargetPoint());
    }
    //se hace en un proceso aparte
    IEnumerator MovePlatformToTargetPoint()
    {
        while(platform.position != targetPoint){
            platform.position = Vector3.MoveTowards(platform.position, targetPoint, speed * Time.deltaTime);
            //Retornar un frame
            yield return null;
        }
        //seder
        yield return null;
    }
}
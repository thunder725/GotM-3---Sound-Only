using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerSoundTest : MonoBehaviour
{
    public float maxPos, speed;
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;

        if (transform.position.z > maxPos)
        {
            transform.position = Vector3.zero;
        }
    }
}

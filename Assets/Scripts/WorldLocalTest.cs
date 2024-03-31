using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLocalTest : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        //transform.Rotate(Vector3.up *Time.deltaTime * 180f, Space.Self);
        transform.Rotate(Vector3.up *Time.deltaTime * 180f, Space.World);
        //transform.Translate(Vector3.forward * 5f * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.forward * 5f * Time.deltaTime, Space.World);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentHomeLocation : MonoBehaviour
{
    public Vector3 homeLocation;

    private void Start()
    {
        var blockLocation = GetComponent<Transform>();
        homeLocation = blockLocation.localPosition;
    }
}

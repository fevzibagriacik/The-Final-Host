using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class referance : MonoBehaviour
{
    public Vector3 positionn;

    private void Awake()
    {
        positionn = transform.position;
    }
}

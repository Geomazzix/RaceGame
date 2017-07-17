using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPartManager : MonoBehaviour
{
    [SerializeField]
    private TrackPart[] _TrackPieces;

    private enum BuildDirection
    {
        north,
        west,
        south,
        east
    };

    BuildDirection _BuildDirection;


    //Sets member variables.
    private void Awake()
    {
        _BuildDirection = BuildDirection.north;
    }



    private void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The direction the start of the road is pointing.
public enum PointDirection
{
    north,
    west,
    south,
    east
};


//Base class for all the trackparts.
public class TrackPart : MonoBehaviour
{
    //Member declarations.

    //Directions.
    [SerializeField] private PointDirection _FirstEntryDirection;
    [SerializeField] private PointDirection _SecondEntryDirection;
    [SerializeField] private PointDirection _ThirdEntryDirection;

    //X and Z offsets.
    [SerializeField] private float _HorizontalRayLengthFromPivot;
    [SerializeField] private float _VerticalRayLengthFromPivot;

    //Y offset.
    [SerializeField] private float _FirstEntryHeight;
    [SerializeField] private float _SecondEntryHeight;
    [SerializeField] private float _ThirdEntryHeight;


    //Properties. (getsets)

    //Directions.
    public PointDirection FirstEntryDirection {get { return _FirstEntryDirection; } }
    public PointDirection SecondEntryDirection {get { return _SecondEntryDirection; } }
    public PointDirection ThirdEntryDirection { get { return _ThirdEntryDirection; } }

    //X and Z offset.
    public float HorizontalRayLengthFromPivot { get { return _HorizontalRayLengthFromPivot; } }
    public float VerticalRayLengthFromPivot { get { return _VerticalRayLengthFromPivot; } }

    //Y offset.
    public float FirstEntryHeight { get { return _FirstEntryHeight; } }
    public float SecondEntryHeight { get { return _SecondEntryHeight; } }
    public float ThirdEntryHeight { get { return _ThirdEntryHeight; } }
}
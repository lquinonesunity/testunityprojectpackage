using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[TrackBindingType(typeof(Light), TrackBindingFlags.AllowCreateComponent)]
public class LightTrack : TrackAsset
{
    
}

[TrackBindingType(typeof(Light), TrackBindingFlags.AllowCreateComponent)]
public class DialogTrack : TrackAsset
{
    
}

[TrackColor(1.0f,1.0f,1.0f)]
public class DialogTrackTwo : TrackAsset
{
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class PlayAnimationSample : MonoBehaviour
{
    public AnimationClip clip;
    public PlayableGraph _playableGraph;

    private void Start()
    {
        //create the graph
        _playableGraph = PlayableGraph.Create("My Graph");
        
        //set the timemode
        _playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
        
        //create the playable output (thr graph, th name, the playable system(this case Animator))
        AnimationPlayableOutput playableOut = AnimationPlayableOutput.Create(_playableGraph, "AinmationName", GetComponent<Animator>());
        
        // wrap the clip in a playable = clip Playable
        AnimationClipPlayable clipPlayable = AnimationClipPlayable.Create(_playableGraph, clip);
        
        // connect the playable(playable output) to a output
        playableOut.SetSourcePlayable(clipPlayable);
        
        //wrap the clip in a playable
        _playableGraph.Play();
    }

    private void OnDisable()
    {
        // destroy all playables and playable outputs created by the graph
        _playableGraph.Destroy();
    }
}

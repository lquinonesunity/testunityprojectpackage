using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

[RequireComponent(typeof(Animator))]

public class PlayWithTimeControlSample : MonoBehaviour
{
    public AnimationClip clip;
    public float time;
    private PlayableGraph playableGraph;
    private AnimationClipPlayable playableClip;

    private void Start()
    {
        playableGraph = PlayableGraph.Create();
        var playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", GetComponent<Animator>());

        // Wrap the clip in a playable
        playableClip = AnimationClipPlayable.Create(playableGraph, clip);

        // Connect the Playable to an output
        playableOutput.SetSourcePlayable(playableClip);

        // Play the Graph
        playableGraph.Play();
        
        // Stops time fromo progrssing automatically
        playableClip.Pause();
    }

    private void Update()
    {
        // Control the time manually
        playableClip.SetTime(time);
    }

    private void OnDisable()
    {
        // Destroy all Playables and Outputs created by the graph
        playableGraph.Destroy();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;
using com.unity.features.team.samples;

[RequireComponent(typeof(Animator))]
public class PauseSubGraphAnimationSample : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float weight;
    
    public AnimationClip clip0;
    public AnimationClip clip1;
    private PlayableGraph playableGraph;
    private AnimationMixerPlayable mixerPlayable;

    public AnimationClipPlayable playableAnimClip_Test01;
    public AnimationClipPlayable playableAnimClip_Test02;

    private void Start()
    {
        // Creates the graph, the mixer and binds them to the Animator
        playableGraph = PlayableGraph.Create();
        var playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", GetComponent<Animator>());
        mixerPlayable = AnimationMixerPlayable.Create(playableGraph, 2);
        playableOutput.SetSourcePlayable(mixerPlayable);
        
        // Creates animationClip Playable and connects them to the mixer
        //var clipPlayable0 = AnimationClipPlayable.Create(playableGraph, clip0);
        //var clipPlayable1 = AnimationClipPlayable.Create(playableGraph, clip1);
        
        playableAnimClip_Test01 = AnimationClipPlayable.Create(playableGraph, clip0);
        playableAnimClip_Test02 = AnimationClipPlayable.Create(playableGraph, clip1);
        

        playableGraph.Connect(playableAnimClip_Test01, 0, mixerPlayable, 0);
        playableGraph.Connect(playableAnimClip_Test02, 0, mixerPlayable, 1);
        
        //mixerPlayable.SetInputWeight(0, 1.0f);
        //mixerPlayable.SetInputWeight(1, 1.0f);
        
        //clipPlayable1.SetPlayState(PlayState.Paused); //Deprecated
        //clipPlayable1.Pause();
        
        // Play the Graph
        playableGraph.Play();
    }
    
    
    private void FixedUpdate()
    {
        weight = Mathf.Clamp01(weight);
        mixerPlayable.SetInputWeight(0, 1.0f-weight);
        mixerPlayable.SetInputWeight(1, weight);
    }

    public void PauseClip()
    {
        playableAnimClip_Test02.Pause();
    }

    public void PlayClip()
    {
        playableAnimClip_Test02.Play();
    }

    private void OnDisable()
    {
        // Destroys all Playables and Outputs created by the graph
        playableGraph.Destroy();
    }
}

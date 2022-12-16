using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class MixAnimClipAnimController : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float weight;
    
    public AnimationClip mclip;
    public RuntimeAnimatorController controller;
    
    private PlayableGraph _playableGraph;
    private AnimationMixerPlayable mixerPlayable;

    private void Start()
    {
        // cretes the graph, the mixer and the bind to the animator
        _playableGraph = PlayableGraph.Create("Mixer");

        // the playable output
        var playableOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation", GetComponent<Animator>());

        // the mixer
        mixerPlayable = AnimationMixerPlayable.Create(_playableGraph, 2);
        
        // bind the mixet witht th output
        playableOutput.SetSourcePlayable(mixerPlayable);
        
        
        // the pair of playables
        
        // create the animationclipplayable and connect to the mixer
        var clipPlayable = AnimationClipPlayable.Create(_playableGraph, mclip);
        
        // playable made with the animation controller
        var ctrlPlayable = AnimatorControllerPlayable.Create(_playableGraph, controller);
        
        
        // connection to the graph
        _playableGraph.Connect(clipPlayable, 0, mixerPlayable, 0);
        _playableGraph.Connect(ctrlPlayable, 0, mixerPlayable, 1);
        
        
        //plya the graph
        _playableGraph.Play();
        
        //default start with Timeline
        //mixerPlayable.SetInputWeight(0,0);
    }

    /*private void Update()
    {
        weight = Mathf.Clamp01(weight);
        mixerPlayable.SetInputWeight(0, 1.0f-weight);
        mixerPlayable.SetInputWeight(1, weight);
    }*/
    
    private void FixedUpdate()
    {
        weight = Mathf.Clamp01(weight);
        mixerPlayable.SetInputWeight(0, 1.0f-weight);
        mixerPlayable.SetInputWeight(1, weight);
    }

    private void OnDisable()
    {
        _playableGraph.Destroy();
    }

    public void SetTimeline()
    {
        // all the mix to 0
        mixerPlayable.SetInputWeight(0,1);//0
        mixerPlayable.SetInputWeight(1, 0);
    }
    

    public void SetAnimController()
    {
        // all the mix to 0
        mixerPlayable.SetInputWeight(0,0);//0
        mixerPlayable.SetInputWeight(1, 1);
    }
}

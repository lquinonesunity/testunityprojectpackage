using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class BlendTreeCode : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float weight;
    
    public AnimationClip clip01;
    public AnimationClip clip02;

    //public float weight;

    private PlayableGraph _playableGraph;

    private AnimationMixerPlayable mixerPlayable;

    private void Start()
    {
        // Creates the graph, the mixer and the binds them to the animator
        _playableGraph = PlayableGraph.Create();
        
        // the playable output
        var playableOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation", GetComponent<Animator>());
        
        // the mixer
        mixerPlayable = AnimationMixerPlayable.Create(_playableGraph, 2);
        
        // bint the mixer to the playable output
        playableOutput.SetSourcePlayable(mixerPlayable);
        
        
        
        // create the animation clip playables --° turn the clips to playables
        var clipPlayable_01 = AnimationClipPlayable.Create(_playableGraph, clip01);
        var clipPlayable_02 = AnimationClipPlayable.Create(_playableGraph, clip02);
        
        // now connect to the mixer
        _playableGraph.Connect(clipPlayable_01, 0, mixerPlayable, 0);
        _playableGraph.Connect(clipPlayable_02, 0, mixerPlayable, 1);
        
        // finally play the graph
        _playableGraph.Play();

    }

    private void Update()
    {
        // clamp:sujetar dos valores
        weight = Mathf.Clamp01(weight);
        Debug.Log(weight);
        mixerPlayable.SetInputWeight(0, 1.0f-weight);
        mixerPlayable.SetInputWeight(1, weight);
    }

    private void OnDisable()
    {
        _playableGraph.Destroy();
    }
}
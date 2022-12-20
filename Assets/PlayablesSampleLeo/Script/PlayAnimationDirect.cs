using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;


public class PlayAnimationDirect : MonoBehaviour
{
    public AnimationClip mclip;
    PlayableGraph _playableGraph;

    private void Start()
    {
        AnimationPlayableUtilities.PlayClip(GetComponent<Animator>(), mclip, out _playableGraph);
    }

    private void OnDisable()
    {
        _playableGraph.Destroy();
        
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

/*
This example demonstrates how to create custom playables 
with the PlayableBehaviour public class. 
This example also demonstrate how to override the PrepareFrame() virtual method
to control nodes on the PlayableGraph.
Custom playables can override any of the other virtual methods of the 
PlayableBehaviour class.

In this example, the nodes being controlled are a series of animation clips (clipsToPlay). The SetInputMethod() modifies the blend weight of each animation clip, ensuring that only one clip plays at a time, and the SetTime() method adjusts the local time so playback starts at the moment the animation clip is activated.
 */

public class PlayQueuePlayable : PlayableBehaviour
{
    private int m_CurrentClipIndex = -1;
    private float m_TimeToNextClip;
    private Playable mixer;

    public PlayableGraph playableGraph;

    public void Initialize(AnimationClip[] clipstoPlay, Playable owner, PlayableGraph graph)
    {
        // set an input to the playable object
        owner.SetInputCount(1);
        
        // defining the mixer with the number of clips as outputs
        mixer = AnimationMixerPlayable.Create(graph, clipstoPlay.Length);
        
        // connect the mixer with the graph
        graph.Connect(mixer, 0, owner, 0);
        
        // setting the weight to 1 on the input 0
        owner.SetInputWeight(0, 1);
        
        // connecting all the clips to the mixer
        for (int clipIndex = 0; clipIndex < mixer.GetInputCount(); ++clipIndex)
        {
            graph.Connect(AnimationClipPlayable.Create(graph, clipstoPlay[clipIndex]), 0, mixer, clipIndex);
            mixer.SetInputWeight(clipIndex, 1.0f);
        }

    }

    public override void PrepareFrame(Playable owner, FrameData info)
    {
        if (mixer.GetInputCount() == 0)
            return;
        
        // Advance to next clip
        m_TimeToNextClip -= (float)info.deltaTime;
        
        // when the clip ends
        if (m_TimeToNextClip <= 0.0f)
        {
            m_CurrentClipIndex++; // jump to next clip
            if (m_CurrentClipIndex >= mixer.GetInputCount())// if finish to run all clips
                m_CurrentClipIndex = 0;

            var currentClip = (AnimationClipPlayable)mixer.GetInput(m_CurrentClipIndex);//getting the input
            
            // reset the time so that the clip starts at the correct position
            currentClip.SetTime(0);
            m_TimeToNextClip = currentClip.GetAnimationClip().length;// setting the next clip time duration
        }
        
        //adjust the weight and the inputs
        for (int clipIndex = 0; clipIndex < mixer.GetInputCount(); ++clipIndex)
        {
            // setting the weight to all the clips and set 1 to the clip that will be played
            mixer.SetInputWeight(clipIndex, clipIndex == m_CurrentClipIndex ? 1.0f : 0.0f);
        }
    }
    
    
}
// No using the play system
[RequireComponent(typeof(Animator))]
public class PlayQueueSample : MonoBehaviour
{
    public AnimationClip[] clipstoPlay;
    private PlayableGraph playableGraph;
    private void Start()
    {
        playableGraph = PlayableGraph.Create();
        var playQueuePlayable = ScriptPlayable<PlayQueuePlayable>.Create(playableGraph);
        var playQueue = playQueuePlayable.GetBehaviour();
        playQueue.Initialize(clipstoPlay, playQueuePlayable, playableGraph);
        
        var playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation Behaviour", GetComponent<Animator>()); 
        playableOutput.SetSourcePlayable(playQueuePlayable, 0);
        
        playableGraph.Play();
        
    }
 
     void OnDisable()
     {
         //destroy all playables
         playableGraph.Destroy();
     }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;


public class PlayAnimation : MonoBehaviour
{
    //Assing the clip
    public AnimationClipPlayable playable;
    public AnimationClip mc;
    public PlayableGraph m_playableGraph;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Create the Graph
        m_playableGraph = PlayableGraph.Create("MyNewPlayableGraph");

        //the type of update
        m_playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);

        //Create the output of the graph to conect the aniamtor
        //1st arg: the graph
        //2nd arg: the name of the output
        //3rd ard: the animator
        var playableOutput = AnimationPlayableOutput.Create(m_playableGraph, "MyAnim", GetComponent<Animator>());

        // OLD
        // Playing the clip with a animationclip playable
        //AnimationClipPlayable my_playable = AnimationClipPlayable.Create(m_playableGraph, mc);
        //my_playable.Play();



        //wrap the clip in a animation playable
        //1st arg: the graph
        //2nd arg: the clip
        AnimationClipPlayable clipPlayable = AnimationClipPlayable.Create(m_playableGraph, mc);
        
        clipPlayable.SetSpeed(0.1f);

        // Connect the playable clip to the output
        playableOutput.SetSourcePlayable(clipPlayable);
        
        //now play the graph
        m_playableGraph.Play();
        
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// animation mixerPlayable

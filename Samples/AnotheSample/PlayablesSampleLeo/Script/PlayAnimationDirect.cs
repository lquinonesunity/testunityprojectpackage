using System;
using System.Collections;
using System.Collections.Generic;
using DLLTest;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;


public class PlayAnimationDirect : MonoBehaviour
{
    public AnimationClip mclip;
    PlayableGraph _playableGraph;

    public Transform prefab_ref;

    private void Start()
    {
        AnimationPlayableUtilities.PlayClip(GetComponent<Animator>(), mclip, out _playableGraph);
        //Debug.Log(addval (5, 20));
        var h = new MyUtilities();
        h.AddValues(4,3);
        Debug.Log(h.c);
        
        InstatiateObject();
    }

    public void InstatiateObject()
    {
        Instantiate(prefab_ref, new Vector3(0.0f, 0, 0), Quaternion.identity);
    }

    private void OnDisable()
    {
        _playableGraph.Destroy();
        
    }
}
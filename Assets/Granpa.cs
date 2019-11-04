using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Granpa : MonoBehaviour
{
    [SerializeField]
    AnimationClip intro;
    [SerializeField]
    AnimationClip talking;
    [SerializeField]
    AnimationClip outro;

    Animator anim;

    [Button]
    public void PlayIntro()
    {
        PlayClip(intro);
    }

    [Button]
    public void PlayTalk()
    {
        PlayClip(talking);
    }

    [Button]
    public void PlayOutro()
    {
        PlayClip(outro);
    }

    void PlayClip (AnimationClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("no clip assigned but tried to play one.");
            return;
        }

        if (anim == null)
            anim = GetComponent<Animator>();

        anim?.Play(clip.name);
    }
}

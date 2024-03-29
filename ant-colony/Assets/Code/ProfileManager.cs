﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(ArrayAnimatorScript))]
public class ProfileManager : MonoBehaviour
{

    private static ProfileManager _instance;
    public static ProfileManager Instance { get { return _instance; } }

    public List<ProfilePic> Profiles;

    public ArrayAnimatorScript SpeakingAnimation;

    [System.Serializable]
   public struct ProfilePic { public string tag; public Sprite[] sprites; }
    void Awake() {
        if (_instance == null){
            _instance = this;
        }
    }

    void Start() {
    }
    public void ShowProfileForTag(string tag) {
        ProfilePic profileToShow = new ProfilePic();
        foreach(ProfilePic profile in Profiles) {
            if (profile.tag.Equals(tag)) {
                profileToShow = profile;
            }
        }
        GetComponent<ArrayAnimatorScript>().Stop();
        GetComponent<SpriteRenderer>().sprite = profileToShow.sprites[0];
        GetComponent<ArrayAnimatorScript>().AnimationArray = profileToShow.sprites;
    }

    void Update() {
        if (DialogueManager.Instance.IsSpeaking) {
            GetComponent<ArrayAnimatorScript>().Play();
        } else {
            GetComponent<ArrayAnimatorScript>().Stop();
        }
    }
    
}

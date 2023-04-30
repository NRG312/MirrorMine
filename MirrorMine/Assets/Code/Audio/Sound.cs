using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public enum AudioTypes { sound,music}
    public AudioTypes audioType;

    public AudioClip clip;
    public string Name;
    public bool Loop;
    [HideInInspector] public AudioSource source;
    [Range(0,1)]
    public float volume;
}

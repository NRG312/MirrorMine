using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Slider SoundSlider;
    public Slider MusicSlider;

    [SerializeField]private AudioMixerGroup musicMixerGroup;
    [SerializeField]private AudioMixerGroup soundMixerGroup;
    public Sound[] Clips;

    [HideInInspector]public float SoundVolume;
    [HideInInspector] public float MusicVolume;


    //SceneManagment
    [HideInInspector]public Scene scene;
    [HideInInspector]public bool isLevel1;
    [HideInInspector]public bool isLevel2;
    [HideInInspector]public bool isPub;
    [HideInInspector] public bool isMenu;

    private void Start()
    {
        instance = this;
        //

        SoundVolume = PlayerPrefs.GetFloat("SoundVolume");
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        foreach  (Sound s in Clips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.Loop;

            switch (s.audioType)
            {
                case Sound.AudioTypes.sound:
                    s.source.outputAudioMixerGroup = soundMixerGroup;
                    break;

                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }
        }
        if (SoundSlider != null)
        {
            SoundSlider.value = SoundVolume;
        }
        if (MusicSlider != null)
        {
            MusicSlider.value = MusicVolume;
        }
        //CheckingAudio
        isLevel1 = true;
        CheckingScenesForMusic();
    }
    public void CheckingScenesForMusic()
    {
        if (isLevel1 == true)
        {
            StopSounds("TavernSounds");
            PlaySounds("CaveSounds");
        }
        if (isLevel2 == true)
        {
            StopSounds("TavernSounds");
            PlaySounds("CaveSounds");
        }
        if (isPub == true)
        {
            StopSounds("CaveSounds");
            PlaySounds("TavernSounds");
        }
        if (isMenu == true)
        {
            StopSounds("TavernSounds");
            StopSounds("CaveSounds");
        }
    }

    public void PlaySounds(string name)
    {
        Sound s = Array.Find(Clips, sound => sound.Name == name);
        s.source.Play();
    }
    public void StopSounds(string name)
    {
        Sound s = Array.Find(Clips, sound => sound.Name == name);
        s.source.Stop();
    }

    public void ChangeVolumeSounds(float Amount)
    {
        SoundVolume = Amount;
        PlayerPrefs.SetFloat("SoundVolume", SoundVolume);
        VolumeAudioMixer();
    }
    public void ChangeVolumeMusic(float Amount)
    {
        MusicVolume = Amount;
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        VolumeAudioMixer();
    }
    public void VolumeAudioMixer()
    {
        musicMixerGroup.audioMixer.SetFloat("Music Volume",(float)Math.Log10(MusicVolume) * 30);
        soundMixerGroup.audioMixer.SetFloat("Sound Volume", (float)Math.Log10(SoundVolume) * 30);
    }
}

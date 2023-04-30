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

    private void Start()
    {
        instance = this;


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

        CheckingScenesForMusic();
    }
    private void CheckingScenesForMusic()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "TestLevelKrystian")
        {
            PlaySounds("CaveSounds");
        }
        if (scene.name == "Level 1")
        {
            PlaySounds("CaveSounds");
        }
        if (scene.name == "Level 2")
        {
            PlaySounds("CaveSounds");
        }
        if (scene.name == "Level 3")
        {
            PlaySounds("CaveSounds");
        }
        if (scene.name == "Pub")
        {
            PlaySounds("TavernSounds");
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
        musicMixerGroup.audioMixer.SetFloat("Music Volume",(float)Math.Log10(MusicVolume) * 20);
        soundMixerGroup.audioMixer.SetFloat("Sound Volume", (float)Math.Log10(SoundVolume) * 20);
    }
}

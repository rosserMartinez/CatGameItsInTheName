using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    TEST,
    CLOSE_TO_OBJ,
    KAKAROTT,
	ElectricHum,
	LightbulHum,
	BreakerSwitch,
	OpenDoor
}

[System.Serializable]
public struct NamedAudio
{
    public AudioType audioType;
    public AudioClip audioClip;
}

[RequireComponent(typeof(AudioSource))]
public class AudioSystem : MonoBehaviour
{
    public List<NamedAudio> audioClips = null;

    [HideInInspector]
    public AudioSource mainAudioSource;
    [HideInInspector]
    public static AudioSystem instance;

    private void Start()
    {
        if (AudioSystem.instance == null)
            AudioSystem.instance = this;
        else
            Destroy(gameObject);

        mainAudioSource = GetComponent<AudioSource>();
        //playLocalAudio(AudioType.TEST, transform.position, true);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            playGlobalAudio(AudioType.TEST, true);
        else if (Input.GetKeyDown(KeyCode.T))
            playLocalAudio(AudioType.KAKAROTT, transform.position, 1f);

	}

    public static void playGlobalAudio(AudioType _type, bool _looped = false)
    {
        instance.mainAudioSource.clip = getClip(_type);
        instance.mainAudioSource.loop = _looped;

        instance.mainAudioSource.Play();
    }

	public static GameObject playLocalAudio(AudioType _type, Vector3 _sourcePosition, float _volume, bool _looped = false)
    {
        if (!hasClip(_type))
            return null;

        GameObject newObject = new GameObject();

        newObject.transform.position = _sourcePosition;

        newObject.name = _type.ToString();

        AudioSource newSource = newObject.AddComponent<AudioSource>();

        newSource.clip = getClip(_type);

        newSource.loop = _looped;

		newSource.volume = _volume;

        newSource.Play();

        newObject.AddComponent<DestroyOnAudioStop>();

        return newObject;
    }


    static bool hasClip(AudioType _type)
    {
        foreach(NamedAudio audioClip in AudioSystem.instance.audioClips)
        {
            if (audioClip.audioType == _type)
                return true;
        }

        return false;
    }

    static AudioClip getClip(AudioType _type)
    {
        foreach (NamedAudio audioClip in AudioSystem.instance.audioClips)
        {
            if (audioClip.audioType == _type)
                return audioClip.audioClip;
        }

        return null;
    }
}

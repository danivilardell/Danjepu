using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] //Cuando se crea una clase personalizada y quieres que se vea en el inspector.

public class Sound_Class
{
    public AudioClip clip;

    public string name;

    [Range(0f, 1f)] //Para poner una slider en el inspector
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

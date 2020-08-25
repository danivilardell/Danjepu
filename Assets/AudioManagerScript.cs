using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManagerScript : MonoBehaviour
{
    public Sound_Class[] sounds;

    public static AudioManagerScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Para no destruir el AudioManager al cambiar de escena.
        DontDestroyOnLoad(gameObject);


        foreach (Sound_Class s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //Aquí pongo el Main Theme.
    void Start()
    {
        PlaySound("Main Theme");
    }

    public void PlaySound(string name)
    {
        Sound_Class s = Array.Find(sounds, sound => sound.name == name);
        //Por si no existe el sonido volvemos para que no pete el programa.
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }
}

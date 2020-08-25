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

    //Actualizo el volumen del "Main Theme" con las sliders.
    public void Theme_Volume(float NewVolume)
    {
        Sound_Class s = Array.Find(sounds, sound => sound.name == "Main Theme");
        s.source.volume = NewVolume;
    }

    //Actualizo el volumen de los efectos de sonido con las sliders.
    public void Sound_Effects_Volume(float NewVolume)
    {
        foreach (Sound_Class s in sounds)
        {
            if (s.name != "Main Theme")
            {
                s.source.volume = NewVolume;
            }
        }
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;                    //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                    //Drag a reference to the audio source which will play the music.

    public static SoundManager instance = null;        //Allows other scripts to call functions from SoundManager.   


    public float lowPitchRange = .95f;                //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.


    private Dictionary<string, AudioClip> dictionarySongLevel; // contiens les sons du niveau
    private Dictionary<string, AudioClip> dictionaryPlayerSong; // contiens les sons du joueur

    private UnityEngine.Object[] tabSong; // permet de recuperer les sons une fois chargé (utilise en transision)


    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }


    /**
     * Permet de charger l'ensemble des song present dans le fichier correspondant au chemin donné
     * 
     * @param path : chemin d'acces du dossier contenant les fichiers sonores
     * @param dico : dictionnaire recuperant les informations
     * */
    private void loadSound(String path, Dictionary<string, AudioClip> dico)
    {

        try
        {
            tabSong = Resources.LoadAll(path, typeof(AudioClip)); // on charge les musiques


            foreach (var s in tabSong)
            {
                Debug.Log(s.name);
                dico.Add(s.name, (AudioClip)s);

            }
        }
        catch (Exception e)
        {
            Debug.Log("Chargement des ressources sonores fails, erreur :  ");
            Debug.Log(e);
        }
    }
    /**
     * charge l'ensemble des sons d'un niveau 
     * 
     * @param levelNumber : numero du niveau correspondant
     * */
    public void loadLevel(int levelNumber)
    {


        string path = "Sounds/Level_" + levelNumber.ToString(); // on definit le chemin d'acces au son en fonction du niveau
        dictionarySongLevel.Clear();
        loadSound(path, dictionarySongLevel);

    }
    /**
     * charge les sons du joueur
     * */
    public void loadPlayer()
    {


        string path = "Sounds/PlayerSongs"; // on definit le chemin d'acces au son en fonction du niveau
        loadSound(path, dictionaryPlayerSong);

    }

    /**
     * joue un son du joueur
     * */
    public void playPlayerSong(string name)
    {

        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = dictionaryPlayerSong[name];

        //Play the clip.
        efxSource.Play();
    }
    /*
     * joue un son du niveau
     * */

    public void playLevelSong(string name)
    {

        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = dictionarySongLevel[name];

        //Play the clip.
        efxSource.Play();




        /*This is a safer, but slow, method of accessing
        //values in a dictionary.
        if(dictionarySong.TryGetValue(name, out temp))
        {
            //success!
        }
        else
        {
            //failure!
        }
         * 
         * 
         * */

    }
    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(AudioClip clip)
    {

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }
}

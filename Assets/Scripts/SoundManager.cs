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

    /*
    private Dictionary<string, AudioClip> dictionarySongLevel; // contiens les sons du niveau
    private Dictionary<string, AudioClip> dictionaryPlayerSong; // contiens les sons du joueur
    private Dictionary<string, AudioClip> dictionaryMenuSong; // contiens les sons du Menu

    private UnityEngine.Object[] tabSong; // permet de recuperer les sons une fois chargé (utilise en transision)
    */

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
     * 
    private void loadSound(String path, Dictionary<string, AudioClip> dico)
    {

        try
        {
            
            // tabSong = Resources.LoadAll(path, typeof(AudioClip)); // on charge les musiques

            Debug.Log(" -- LOAD MENU path : "+path+"  --");
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
     * 
    public void loadLevel(int levelNumber)
    {


        string path = "/Sounds/Level_" + levelNumber.ToString(); // on definit le chemin d'acces au son en fonction du niveau
        dictionarySongLevel.Clear();
        loadSound(path, dictionarySongLevel);

    }
    /**
     * charge les sons du joueur
     * 
    public void loadPlayer()
    {


        string path = "/Sounds/PlayerSongs"; // on definit le chemin d'acces au son en fonction du niveau
        loadSound(path, dictionaryPlayerSong);

    }

    public void loadMenu()
    {
        
        string path = "/Sounds/Menu/"; // on definit le chemin d'acces au son en fonction du niveau
        loadSound(path, dictionaryMenuSong);


    }
    /*
     * joue un effet sonore
     * 
    private void playSong(string name, Dictionary<string, AudioClip> dico, AudioSource source)
    {


        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        source.pitch = randomPitch;


        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        source.clip = dico[name];

        //Play the clip.
        source.Play();

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
         * 

    }

    public void playMenuSongEffet(string name)
    {

        playSong(name, dictionaryMenuSong,efxSource);
    }

    /**
     * joue un effet sonore du joueur
     * 
    public void playPlayerSongEffect(string name)
    {
        playSong(name, dictionaryPlayerSong, efxSource);
    }
    /*
     * joue un effet sonore du niveau
     * 

    public void playLevelSongEffect(string name)
    {
        playSong(name, dictionarySongLevel, efxSource);

    }
    /**
     * Joue un son de manière cyclique (Loop) 
     * 
     * 
    public void playLevelSongMusic(string name)
    {

        playSong(name, dictionarySongLevel, musicSource);

    }
    /**
     *permet de jouer un son de maniere cyclique (Loop) 
     **/
        //Used to play single sound clips.
        public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        musicSource.clip = clip;

        //Play the clip.
        musicSource.Play();
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

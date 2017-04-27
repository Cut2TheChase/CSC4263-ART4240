///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the audio player for the main level theme.
///Author -- Mitchell Aucoin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundKeeper : MonoBehaviour
{
    private static SoundKeeper instance = null;
	public AudioClip bossMusic;

    public static SoundKeeper Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

	public void bossMusicPlay(){
		GetComponent<AudioSource> ().clip = bossMusic;
		GetComponent<AudioSource> ().Play ();
	}
}

using KartGame.Track;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnLoad : MonoBehaviour
{

    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        //   DontDestroyOnLoad(gameObject);
        PlayMusic();
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayMusic()
    {
        backgroundMusic.Play();
    }
}

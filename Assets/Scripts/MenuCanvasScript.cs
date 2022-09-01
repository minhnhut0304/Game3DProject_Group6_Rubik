using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load different scenes

public class MenuCanvasScript : MonoBehaviour
{
    public GameObject menuPanel; // Declare menu panel game object
    public GameObject playButton; // Declare play button gameObject
    public GameObject playlistPanel; // Declare playlist panel gameObject
    public GameObject menuButton; // Declare menu button gameObject
    public bool playlistPanelEnabled; // Declare a boolean for our playList panel object that will be set to false at game start

    public static MenuCanvasScript instance; // Creates a static variable for a MenuCanvasScript instance

    public bool playing = false; // Playing boolean set to false
    public AudioSource musicSource; // AudioSource component in Canvas game object
    public AudioClip[] playlistOne; // Array that will hold tracks for playlist one
    public AudioClip[] playlistTwo; // Array that will hold tracks for playlist two
    public AudioClip[] playlistThree; // Array that will hold tracks for playlist three

    private bool muted = false; // Muted boolean set to false

    private void Awake() // Called when a scene is loaded
    {
        DontDestroyOnLoad(gameObject); // Don't destroy this gameObject when loading different scenes
        if (instance == null) // If the MenuCanvasScript instance variable is null
        {
            instance = this; // Set this object as this instance
        }
        else
        {
            Destroy(gameObject); // Destroy this gameObject
        }
            
        menuPanel.SetActive(true); // Set our menu panel gameObject to active           
        playlistPanelEnabled = false; // Set our boolean to false    
        playlistPanel.SetActive(false); // Disable our playlist panel gameObject
        menuButton.SetActive(false); //  Disable our menu button gameObject
        playButton.SetActive(true);  // Enable the play button gameObject
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // If we press the escape button
        {
            if (playlistPanelEnabled) // If the boolean is set to true when escape is pressed
            {
                playlistPanel.SetActive(false); // Disable the playlist panel
                playButton.SetActive(true); // Enable the play button
            }
            else // If the boolean is set to false when escape is pressed
            {
                playlistPanel.SetActive(true); // Enable the playlist panel
                playButton.SetActive(false); // Disable the play button
            }
            playlistPanelEnabled = !playlistPanelEnabled; // Reverse our playlistPanelEnabled boolean
        }
    }

    public void PressPlayButton() // Function called when we press the play button
    {
        SceneManager.LoadScene("Game"); // Load the game scene
        menuPanel.SetActive(false); // Disable the menu panel gameObject
        playlistPanelEnabled = false; // Set our boolean to false
        playlistPanel.SetActive(false); // Disable our playlist panel gameObject
        menuButton.SetActive(true); //  Enable the menu button gameObject
    }

    public void PressMenuButton()
    {
        SceneManager.LoadScene("Menu"); // Load the menu scene
        menuPanel.SetActive(true); // Set our menu panel gameObject to active           
        playlistPanelEnabled = false; // Set our boolean to false    
        playlistPanel.SetActive(false); // Disable our playlist panel gameObject
        menuButton.SetActive(false); // Disable the menu button gameObject
        playButton.SetActive(true); // Enable the play button gameObject
    }

    public void PressPlaylistButtonOne() // Function to start PlaylistOne coroutine
    {
        StartCoroutine(PlaylistOne());
    }
    public void PressPlaylistButtonTwo() // Function to start PlaylistTwo coroutine
    {
        StartCoroutine(PlaylistTwo());
    }
    public void PressPlaylistButtonThree() // Function to start PlaylistThree coroutine
    {
        StartCoroutine(PlaylistThree());
    }

    IEnumerator PlaylistOne() // Will loop through tracks in playlistOne AudioClip array
    {
        if (!playing) // If the playing boolean is false
        {
            playing = true; // Set playing boolean to true
        }

        if (muted) // if the muted boolean is equal to true
        {
            muted = false; // Set the muted boolean to false
            musicSource.volume = 1; // Set the AudioSource volume to full volume
        }

        yield return null; // Wait for next frame

        while (playing) // While the playing boolean is equal to true, loop through the following
        {
            for (int i = 0; i < playlistOne.Length; i++) // Run this loop while the variable "i" (set to 0 at start of loop) is less than the amount of tracks in the playlistOne array
            {
                musicSource.clip = playlistOne[i]; // Set musicSource clip to playlistOne track number "i"

                musicSource.Play(); // Play the AudioSource

                while (musicSource.isPlaying) // While AudioSource is playing a track
                {
                    yield return null; // Wait for next frame
                }
            }
        }
    }

    IEnumerator PlaylistTwo() // Will loop through tracks in playlistTwo AudioClip array
    {
        if (!playing) // If the playing boolean is false
        {
            playing = true; // Set playing boolean to true
        }

        if (muted) // if the muted boolean is equal to true
        {
            muted = false; // Set the muted boolean to false
            musicSource.volume = 1; // Set the AudioSource volume to full volume
        }

        yield return null; // Wait for next frame

        while (playing) // While the playing boolean is equal to true, loop through the following
        {
            for (int i = 0; i < playlistTwo.Length; i++)// Run this loop while the variable "i" (set to 0 at start of loop) is less than the amount of tracks in the playlistTwo array
            {
                musicSource.clip = playlistTwo[i]; // Set musicSource clip to playlistTwo track number "i"

                musicSource.Play(); // Play the AudioSource

                while (musicSource.isPlaying) // While AudioSource is playing a track
                {
                    yield return null; // Wait for next frame
                }
            }
        }
    }

    IEnumerator PlaylistThree() // Will loop through tracks in playlistThree AudioClip array
    {
        if (!playing) // If the playing boolean is false
        {
            playing = true; // Set playing boolean to true
        }

        if (muted) // if the muted boolean is equal to true
        {
            muted = false; // Set the muted boolean to false
            musicSource.volume = 1; // Set the AudioSource volume to full volume
        }

        yield return null; // Wait for next frame

        while (playing) // While the playing boolean is equal to true, loop through the following
        {
            for (int i = 0; i < playlistThree.Length; i++) // Run this loop while the variable "i" (set to 0 at start of loop) is less than the amount of tracks in the playlistThree array
            {
                musicSource.clip = playlistThree[i]; // Set musicSource clip to playlistThree track number "i"

                musicSource.Play(); // Play the AudioSource

                while (musicSource.isPlaying) // While AudioSource is playing a track
                {
                    yield return null; // Wait for next frame
                }
            }
        }
    }

    public void PressMuteButton() // If the mute button is pressed
    {
        if (muted) // If the muted boolean is equal to true
        {
            musicSource.volume = 1; // Set the AudioSource volume to full volume
        }
        else // If the muted boolean is equal to false
        {
            musicSource.volume = 0;  // Set the AudioSource volume to no volume
        }
        muted = !muted; // Switch the value of the muted boolean
    }
}

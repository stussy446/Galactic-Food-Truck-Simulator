using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialStateManager : MonoBehaviour
{
    public static TutorialStateManager Instance;

    public InputManager playerInput;

    public Customer customer;
    public GameObject translator;
    public GameObject replicator;
    public GameObject button;

    public TutorialAbstract currentState;
    public TutorialMovement tutorialMovement = new TutorialMovement();
    public TutorialCustomerInteraction tutorialCustomer = new TutorialCustomerInteraction();
    public TutorialTranslatorInteraction tutorialTranslator = new TutorialTranslatorInteraction();
    public TutorialReplicatorInteraction tutorialReplicator = new TutorialReplicatorInteraction();
    public TutorialButtonInteraction tutorialButton = new TutorialButtonInteraction();
    public TutorialEnd tutorialEnd = new TutorialEnd();

    public AudioSource source;
    public TMP_Text subtitleText;
    public MainMenuManager mainMenuManager;
    public List<AudioClip> tutorialAudios = new List<AudioClip>();
    private Dictionary<AudioClip, string> subtitledAudio;
    private AudioClip activeClip;
    private string activeSubtitle;
    private int clipIndex = 0;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        subtitledAudio= new Dictionary<AudioClip, string>() 
        {
            {tutorialAudios[0], "Okay, the last guy didn't last a day, so let's see if you can. Listen up! You have two simple tasks. Feed the customers. Save the Universe. And your training starts right now. You can press WASD to move around and use your mouse to look around." },
            {tutorialAudios[1], "Good. Every so often a hungry... person? No, that's not right. A hungry being will come along. Approach them and press E to get their order."},
            {tutorialAudios[2], "Did you understand that? Me neither. Luckily for you, to your left, we have a translator. Interact with it and turn the knob in the middle until you find a language you understand. Once you do, go ahead and press the spacebar to stop interacting with anything." },
            {tutorialAudios[3], "Now go over to the food replicator screen and click on the food that the customer ordered" },
            {tutorialAudios[4], "Easy right? Now, to the second task. Go over to that dark room over there. Over time, that green bar is gonna go down. You need to hold on to that big red button to save the universe." },
            {tutorialAudios[5], "" }
        };

        currentState = tutorialMovement;
        activeClip = tutorialAudios[clipIndex];
        activeSubtitle = subtitledAudio[activeClip];
        source.clip = activeClip;
        subtitleText.text = activeSubtitle;
        source.Play();
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
        CheckToSkipTutorial();
    }

    public void SwitchStates(TutorialAbstract newState)
    {
        currentState = newState;
        currentState.EnterState(this);
        NextAudioClip();
        source.Play();
    }

    /// <summary>
    /// Gets the next clip in the tutorial and sets it as the audiosource's clip
    /// </summary>
    public void NextAudioClip()
    {
        clipIndex++;
        activeClip = tutorialAudios[clipIndex];
        activeSubtitle = subtitledAudio[activeClip];
        subtitleText.text = activeSubtitle;
        source.clip = activeClip;
    }

    /// <summary>
    /// Skips the tutorial if the user pressed T
    /// </summary>
    private void CheckToSkipTutorial()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchStates(tutorialEnd);
            LoadGame();
        }
    }

    /// <summary>
    /// Loads into the main game
    /// </summary>
    public void LoadGame()
    {
        mainMenuManager.gameObject.SetActive(true);
        mainMenuManager.GetComponent<Image>().enabled = false;


        foreach (Transform item in mainMenuManager.gameObject.transform)
        {
            item.gameObject.SetActive(false);
        }
    
        source.Stop();
        subtitleText.gameObject.SetActive(false);
        mainMenuManager.LoadNextScene();
    }
}

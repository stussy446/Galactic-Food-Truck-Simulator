using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public List<AudioClip> tutorialAudios = new List<AudioClip>();
    private AudioClip clipToPlay;
    private int clipIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        currentState = tutorialMovement;
        clipToPlay = tutorialAudios[clipIndex];
        source.clip = clipToPlay;
        source.Play();
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
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

    public void NextAudioClip()
    {
        clipIndex++;
        clipToPlay = tutorialAudios[clipIndex];
        source.clip = clipToPlay;
    }

    private void CheckToSkipTutorial()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(2);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        currentState = tutorialMovement;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchStates(TutorialAbstract newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}

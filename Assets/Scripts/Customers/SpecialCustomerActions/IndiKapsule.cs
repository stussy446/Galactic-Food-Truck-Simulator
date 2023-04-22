using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiKapsule : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.Play("CapsuleAnim");
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            animator.SetTrigger("Shoot");
            muzzleFlash.Play();
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            animator.SetTrigger("DoReload");
        }
    }
}

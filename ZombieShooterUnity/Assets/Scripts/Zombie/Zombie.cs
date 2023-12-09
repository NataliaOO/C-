using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Player player;
    CapsuleCollider capsuleCollider;
    MovementAnimator movement;
    Animator animator;
    ParticleSystem particalSystem;
    ZombieCounter zombieCounter;
    bool dead;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        movement = GetComponent<MovementAnimator>();
        particalSystem = GetComponentInChildren<ParticleSystem>();
        zombieCounter = FindObjectOfType<ZombieCounter>();
        navMeshAgent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) return;

        navMeshAgent.SetDestination(player.transform.position);
        transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
    }

    public void Kill() {
        if (!dead) {
            dead = true;
            particalSystem.Play();

            zombieCounter.AddKill();

            Destroy(capsuleCollider);
            Destroy(movement);
            Destroy(navMeshAgent);

            animator.SetTrigger("died");
        }
    }
}
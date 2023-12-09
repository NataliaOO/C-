using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] GameObject directly;

    NavMeshAgent navMeshAgent;
    public float moveSpeed;
    private float range = 100f;
    public Transform gunBarrel;
    Shot shot;

    // Start is called before the first frame update
    void Start()
    {
        shot = FindObjectOfType<Shot>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        //navMeshAgent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 dir = Vector3.zero;
        dir.x = horizontal;
        dir.z = vertical;
        navMeshAgent.velocity = dir.normalized * moveSpeed;

        if (horizontal != 0 || vertical != 0) {
            transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity);
        }
    }

    public void Shoot() {
            var from = gunBarrel.position;
            var target = directly.transform.position;
            var to = new Vector3(target.x, target.y, target.z);
            var direction = (to - from).normalized;

            RaycastHit hit;
            if(Physics.Raycast(from, direction, out hit, range)) {
                
                if (hit.transform != null) {
                    var zombie = hit.transform.GetComponent<Zombie>();
                    if (zombie != null) {
                        zombie.Kill();
                    }
                }

                to = new Vector3(hit.point.x, from.y, hit.point.z);

            } else {
                to = from + direction * 100;
            }

            shot.Show(from, to);
    }
}
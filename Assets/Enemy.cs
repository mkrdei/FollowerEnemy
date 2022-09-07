using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    [SerializeField]
    private float distanceToAttack = 5f;
    [SerializeField]
    private float movementSpeed = 3f;
    private Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerClose())
            AttackPlayer();
    }

    private bool PlayerClose()
    {
        if(Vector3.Distance(player.transform.position, transform.position)<=distanceToAttack)
        {
            return true;
        }else
        {
            return false;
        }
    }
    private void AttackPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction*movementSpeed*Time.deltaTime;
    }
    public void Respawn()
    {
        transform.position = spawnPoint;
        rb.velocity = Vector3.zero;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    private Rigidbody rb;
    protected Joystick joystick;
    private Vector3 movementDirection;
    private Vector3 respawnPosition;
    [SerializeField]
    private float movementSpeed = 5f;
    private float horizontalAxis,verticalAxis;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithJoystick();
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collider " + collider.transform.name);
        if(collider.transform.tag=="Enemy")
        {
            Respawn();
            collider.transform.GetComponent<Enemy>().Respawn();
        }
    }
    private void MoveWithJoystick()
    {
        horizontalAxis = joystick.Horizontal;
        verticalAxis = joystick.Vertical;
        movementDirection = new Vector3(horizontalAxis, 0.0f, verticalAxis);
        movementDirection *= movementSpeed;
        rb.velocity = movementDirection*Time.fixedDeltaTime;
    }

    private void Respawn()
    {
        transform.position = spawnPoint.position;
    }
}

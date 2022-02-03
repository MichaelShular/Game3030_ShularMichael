using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ArenaMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 7;

    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(inputVector.magnitude > 0))
        {
            moveDirection = Vector3.zero;
        }

        moveDirection = -transform.up * inputVector.y + -transform.right * inputVector.x;

        Vector3 movementDirection = moveDirection * (movementSpeed * Time.deltaTime);

        transform.position += movementDirection;
    }
    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }
}

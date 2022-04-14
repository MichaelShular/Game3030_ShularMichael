using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public GameObject gameController;

    [SerializeField] float movementSpeed = 7;

    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 lookInput = Vector2.zero;

    public float aimSensativity = 1;
    public GameObject followTransform;

    public GameObject currentInteractableObjects;

    public bool isInterating;

    // Start is called before the first frame update
    void Start()
    {
        isInterating = false;
        currentInteractableObjects = null;
    }

    // Update is called once per frame
    void Update()
    {
        playerInteration();
        playerRotation();
        playerMovement();
    }

    private void playerInteration()
    {
        if (isInterating && currentInteractableObjects != null)
        {
            if (currentInteractableObjects.CompareTag("Blood"))
            {
                gameController.GetComponent<DiseaseConstructScript>().updateBloodAmount(currentInteractableObjects.transform.parent.GetComponent<BloodStats>()._bloodAmount);
                Destroy(currentInteractableObjects.transform.parent.gameObject);
            }
            else
            {
                Instantiate(currentInteractableObjects.GetComponent<InteractableObjectsController>().miniGameCanvas);
                gameController.GetComponent<GameControllerScript>().StopTimer();
            }
            //Debug.Log("asda");
            gameController.GetComponent<DiseaseConstructScript>().UIForBlood.SetActive(false);
            //Destroy(currentInteractableObjects.gameObject);

            isInterating = false;
        }
    }
    private void playerRotation()
    {
        followTransform.transform.rotation *= Quaternion.AngleAxis(inputVector.x * aimSensativity, Vector3.up);

        //followTransform.transform.rotation *= Quaternion.AngleAxis(inputVector.y * aimSensativity, Vector3.left);

        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTransform.transform.localEulerAngles.x;

        if (angle > 180 && angle < 300)
        {
            angles.x = 300;
        }
        else if (angle < 180 && angle > 80)
        {
            angles.x = 80;
        }

        followTransform.transform.localEulerAngles = angles;
        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);

        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
    }
    private void playerMovement()
    {
        if (!(inputVector.magnitude > 0))
        {
            moveDirection = Vector3.zero;
        }

        moveDirection = transform.forward * inputVector.y /*+ transform.right * inputVector.x*/;

        Vector3 movementDirection = moveDirection * (movementSpeed * Time.deltaTime);

        transform.position += movementDirection;
    }
    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    public void OnLookingAround(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }
    public void OnInteract(InputValue value)
    {
        isInterating = value.isPressed;
    }
}

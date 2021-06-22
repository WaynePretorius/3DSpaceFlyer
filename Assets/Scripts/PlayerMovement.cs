using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variable declared in conjuction with movement and clamping the ship to the edges of the screen
    [Header("Movement Settings")]
    [SerializeField] float controlMovementSpeed = 25f;
    [SerializeField] float xClampMin = -5f;
    [SerializeField] float xClampMax = 5f;
    [SerializeField] float yClampMin = -5f;
    [SerializeField] float yClampMax = 5f;
    float verticalMovement;
    float horizontalMovement;

    //Variables declared for the local rotation, so the ship does not always look to the centre of the screen
    [Header("Rotation Settings")]
    [SerializeField] float transformPitchFacor = -1.2f;
    [SerializeField] float pitchThrowFactor = -10f;
    [SerializeField] float transformYawFactor = 1.5f;
    [SerializeField] float rollThrowFactor = -30f;

    //game states
    bool isFiring = false;

    //caching of abojects
    [Header("Gameobjects needed")]
    [SerializeField] GameObject[] lasers;

    // Update is called once per frame
    void Update()
    {
        MoveShip();
        RotateShip();
        DetectFireButton();
    }

    //Function that will move the ship
    void MoveShip()
    {
        //get the input from the user and store it as a float
        horizontalMovement = Input.GetAxis(Tags.AXIS_HORIZONTAL);
        verticalMovement = Input.GetAxis(Tags.AXIS_VERTICAL);

        //use the input to find the ship position on the screen, clamp it so the ship does not move out of the screen
        float xOffSet = horizontalMovement * Time.deltaTime * controlMovementSpeed;
        float rawXPos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXPos, xClampMin, xClampMax);

        //use the input to find the ship position on the screen, clamp it so the ship does not move out of the screen
        float yOffSet = verticalMovement * Time.deltaTime * controlMovementSpeed;
        float rawYPos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYPos, yClampMin, yClampMax);

        //Move the ship in the screen
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    //Function that will rotate the ship on the yaw(y), pitch(x) and Roll(z)
    void RotateShip()
    {
        //rotating the ship on the y axis, and giving it a bit of a nudge to look like it is going up or down
        float pitchPosition = transform.localPosition.y * transformPitchFacor;
        float pitchThrow = verticalMovement * pitchThrowFactor;

        float pitch = pitchPosition + pitchThrow;
        float yaw = transform.localPosition.x * transformYawFactor;
        float roll = horizontalMovement * rollThrowFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    //Fires projectiles from the ship
    void DetectFireButton()
    {
        
        if (Input.GetButton(Tags.AXIS_FIRE1))
        {
            isFiring = true;
            IsFiring(isFiring);
        }
        else
        {
            isFiring = false;
            IsFiring(isFiring);
        }

    }

    //function that utilizes the firing state
    void IsFiring(bool fire)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionEnable = laser.GetComponent<ParticleSystem>().emission;
            emissionEnable.enabled = fire;
        }
    }
}

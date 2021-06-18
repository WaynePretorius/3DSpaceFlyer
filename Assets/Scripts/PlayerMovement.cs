using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float controlMovementSpeed = 25f;
    [SerializeField] float xClampMin = -5f;
    [SerializeField] float xClampMax = 5f;
    [SerializeField] float yClampMin = -5f;
    [SerializeField] float yClampMax = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();
        ShipFire();
    }

    //Function that will move the ship
    void MoveShip()
    {
        //get the input from the user and store it as a float
        float horizontalMovement = Input.GetAxis(Tags.AXIS_HORIZONTAL);
        float verticalMovement = Input.GetAxis(Tags.AXIS_VERTICAL);

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

    //Fires projectiles from the ship
    void ShipFire()
    {
        return;
    }
}

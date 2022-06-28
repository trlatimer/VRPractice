using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRDirectInteractor climbingHand;
    //private ContinuousMovement continuousMovement;
    private ActionBasedContinuousMoveProvider continuousMovement;

    void Start()
    {
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ActionBasedContinuousMoveProvider>();
    }

    void FixedUpdate()
    {
        if (climbingHand)
        {
            continuousMovement.enabled = false;
            Climb();
        }
        else
        {
            continuousMovement.enabled = true;
        }
    }

    void Climb()
    {
        //InputDevices.GetDeviceAtXRNode(climbingHand).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        Vector3 velocity = climbingHand.gameObject.GetComponent<ControllerVelocity>().Velocity;

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}

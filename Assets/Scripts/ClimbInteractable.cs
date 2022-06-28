using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (args.interactorObject is XRDirectInteractor)
            Climber.climbingHand = (XRDirectInteractor) args.interactorObject;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (args.interactorObject is XRDirectInteractor)
        {
            if (Climber.climbingHand && Climber.climbingHand.name == ((XRDirectInteractor)args.interactorObject).name)
                Climber.climbingHand = null;
        }
    }
}

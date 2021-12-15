using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class gate_opening : XRSocketInteractor
{
    // Start is called before the first frame update
    public string targetTag = string.Empty;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && MatchUsingTag(interactable); 
    }

    // Update is called once per frame
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable);
    }

    private bool MatchUsingTag (XRBaseInteractable interactable)
    {
        return interactable.CompareTag(targetTag);
    }

}


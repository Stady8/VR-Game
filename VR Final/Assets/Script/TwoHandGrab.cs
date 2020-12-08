using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandGrab : XRGrabInteractable
{

    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>();
    private XRBaseInteractor secondInteractor;
    private Quaternion attachInitialRoation;
    public enum TwoHandRotationType {None, First, Second};
    public TwoHandRotationType twoHandRotationType;
    public bool snapToSecondHand = true;
    private Quaternion initalRoationOffset;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in secondHandGrabPoints)
        {
            item.onSelectEntered.AddListener(OnSecondHandGrab);
            item.onSelectExited.AddListener(OnSecondHandRelease);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(secondInteractor && selectingInteractor) 
        {
            if(snapToSecondHand){
            selectingInteractor.attachTransform.rotation = GetTwoHandRotation();//Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
            }
            else{
                 selectingInteractor.attachTransform.rotation = GetTwoHandRotation() * initalRoationOffset;
            }
     }

        base.ProcessInteractable(updatePhase);
    }

private Quaternion GetTwoHandRotation(){
    Quaternion targetRotation;
    if(twoHandRotationType == TwoHandRotationType.None){
        targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);

    }else if(twoHandRotationType == TwoHandRotationType.First){
         targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.attachTransform.up);

    }
    else{
        targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, secondInteractor.attachTransform.up);

    }
return targetRotation;
    }



public void OnSecondHandGrab(XRBaseInteractor interactor)
{
    secondInteractor = interactor;
    initalRoationOffset = Quaternion.Inverse(GetTwoHandRotation()) * selectingInteractor.attachTransform.rotation;
}

public void OnSecondHandRelease(XRBaseInteractor interactor)
{
    secondInteractor = null;
}

protected override void OnSelectEntered(XRBaseInteractor interactor){
    base.OnSelectEntered(interactor);
    attachInitialRoation = interactor.attachTransform.localRotation;
}

protected override void OnSelectExited(XRBaseInteractor interactor){
    base.OnSelectExited(interactor);
     secondInteractor = null;
     interactor.attachTransform.localRotation = attachInitialRoation;
}


public override bool IsSelectableBy(XRBaseInteractor interactor){

bool isalreadygrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
return base.IsSelectableBy(interactor) && !isalreadygrabbed;
}
}

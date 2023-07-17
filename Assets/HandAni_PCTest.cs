using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class HandAni_PCTest : MonoBehaviour
{
    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    public InputActionProperty leftDeactivate;
    public InputActionProperty rightDeactivate;

    //Stores handPrefab to be Instantiated
    public GameObject handPrefab;

    //Stores what kind of characteristics we're looking for with our Input Device when we search for it later
    public InputDeviceCharacteristics inputDeviceCharacteristics;
    public float HandLR;
    //Stores the InputDevice that we're Targeting once we find it in InitializeHand()
    private Animator _handAnimator;

    public bool isGrabbed = false;
    private void Start()
    {
        InitializeHand();
    }

    private void InitializeHand()
    {
        GameObject spawnedHand = Instantiate(handPrefab, transform);
        _handAnimator = spawnedHand.GetComponent<Animator>();
    }


    // Update is called once per frame
    private void Update()
    {
        if (!isGrabbed)
        {
            if (HandLR == 1)
            {
                UpdateHandRight();
            }
            else
            {
                UpdateHandLeft();
            }
        }
        
    }

    private void UpdateHandLeft()
    {
        if (leftDeactivate.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f)
        {
            _handAnimator.SetFloat("Grip", leftActivate.action.ReadValue<float>());
        }
        else _handAnimator.SetFloat("Grip", 0);

        if (leftActivate.action.ReadValue<float>() == 0 && leftDeactivate.action.ReadValue<float>() > 0.1f)
        {
            _handAnimator.SetFloat("Trigger", leftDeactivate.action.ReadValue<float>());
        }
        else _handAnimator.SetFloat("Trigger", 0);
        
        
        
        
        

    }
    private void UpdateHandRight()
    {
        if (rightDeactivate.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f)
        {
            _handAnimator.SetFloat("Grip", rightActivate.action.ReadValue<float>());
        }
        else _handAnimator.SetFloat("Grip", 0);

        if (rightActivate.action.ReadValue<float>() == 0 && rightDeactivate.action.ReadValue<float>() > 0.1f)
        {
            _handAnimator.SetFloat("Trigger", rightDeactivate.action.ReadValue<float>());
        }
        else _handAnimator.SetFloat("Trigger", 0);
    }
    public void grab()
    {
        isGrabbed = true;
    }
    public void degrab()
    {
        isGrabbed = false;
    }
    
}

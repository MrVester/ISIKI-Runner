using GG.Infrastructure.Utils.Swipe;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    [SerializeField]
    private SwipeListener swipeListener;
    private CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }
    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
    private void OnSwipe(string swipe)
    {
        switch (swipe)
        {
            case "Up":
                {
                    characterController.TriggerJump();
                    break;
                }
            case "Left":
                {
                    characterController.OnLeftSwipe();
                    break;
                }
            case "Right":
                {
                    characterController.OnRightSwipe();
                    break;
                }
            default: break;
        }
    }
}

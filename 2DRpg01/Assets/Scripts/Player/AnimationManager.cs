using Player.Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(MovementController))]
    public class AnimationManager : MonoBehaviour
    {
        private InputController _inputController;
        private Animator _animator;
        private MovementController _movementController;

        void Start()
        {
            _inputController = GetComponent<InputController>();
            _animator = GetComponent<Animator>();
            _movementController = GetComponent<MovementController>();
        }


        void Update()
        {
            UpdateAnimations();
        }

        private void UpdateAnimations()
        {
            _animator.SetBool("IsWalking", _movementController.isWalking);
            if (_inputController.HorizontalVal != 0 || _inputController.VerticalVal != 0)
            {
                _animator.SetFloat("Horizontal", _inputController.HorizontalVal);
                _animator.SetFloat("Vertical", _inputController.VerticalVal);
            }
            
        }

    }
}
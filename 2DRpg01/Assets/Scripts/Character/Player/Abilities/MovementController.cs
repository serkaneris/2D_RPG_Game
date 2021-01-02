using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [RequireComponent(typeof(InputController))]
    public class MovementController : MonoBehaviour
    {
        private InputController _inputController;
        public float moveSpeed;
        public bool isWalking;
        void Start()
        {
            _inputController = GetComponent<InputController>();
        }

        void Update()
        {
            if (_inputController.HorizontalVal != 0 || _inputController.VerticalVal != 0)
            {
                if (!isWalking)
                {
                    isWalking = true;
                    //animator.SetBool("IsWalking", isWalking);

                }
                Move();
            }
            else
            {
                if (isWalking)
                {
                    isWalking = false;
                    //animator.SetBool("IsWalking", isWalking);
                }
            }
        }

        private void Move()
        {
            transform.Translate(_inputController.HorizontalVal * Time.deltaTime * moveSpeed, _inputController.VerticalVal * Time.deltaTime * moveSpeed, 0f);
        }
    }




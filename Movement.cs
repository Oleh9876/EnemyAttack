using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace EnemyAttack.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviourPunCallbacks

    {
        [SerializeField] private float movementSpeed = 0f;

        private CharacterController characterController = null;
        private Transform mainCameraTransform = null;
        private Animator animator;

        [SerializeField]

        private float forwardMoveSpeed = 7.5f;

        [SerializeField]

        private float backwardMoveSpeed = 7.5f;

        [SerializeField]

        private float turnSpeed = 5f;

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
            animator = GetComponentInChildren<Animator>();
            Cursor.lockState = CursorLockMode.Locked;
            mainCameraTransform = Camera.main.transform;
        }

        void Update()
        {
            if(photonView.IsMine)
                
            {
                TakeInput();
            }
           
           


        }

        private void TakeInput()

        {
          
            var horizontal = Input.GetAxis("Mouse X");

            var vertical = Input.GetAxis("Vertical");

            var movement = new Vector3(horizontal, 0, vertical);

            animator.SetFloat("Speed", vertical);

            transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);



            if (vertical != 0)

            {
                float moveSpeedToUse = (vertical) > 0 ? forwardMoveSpeed : backwardMoveSpeed;

                characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);

            }

        }

       
    }
}
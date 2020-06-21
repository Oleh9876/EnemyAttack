using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  
    [SerializeField]
    public float mouseSensitivity = 0.1f;
    private CinemachineComposer composer;
   private void Start()
    {
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();

    }

   
   private void Update()
    {
        float vertical = Input.GetAxis("Mouse Y") * mouseSensitivity;
        composer.m_TrackedObjectOffset.y += vertical;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -5, 5);


    }
}

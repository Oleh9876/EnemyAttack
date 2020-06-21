using Cinemachine;
using Photon.Pun;
using UnityEngine;

namespace EnemyAttack
{
    public class PlayerSpawner : MonoBehaviourPun
    {
        [SerializeField] private GameObject playerPrefab = null;
        [SerializeField] private CinemachineVirtualCamera playerCamera = null;
       
        private void Start()
        {
            var player = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
            playerCamera.Follow = player.transform;
            playerCamera.LookAt = player.transform;
        }
    }
}

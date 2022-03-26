using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform spawnPoint;
    PlayerFollow playerFollow;
    // Start is called before the first frame update
    void Start()
    {
        playerFollow = FindObjectOfType<PlayerFollow>();
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        playerFollow.SetCameraFollow(player.GetComponent<AimStateManager>().GetCameraLookAtPos());
    }


}

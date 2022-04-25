using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerManager : MonoBehaviour
{

    PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Debug.Log("Instantiated Player Controller");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

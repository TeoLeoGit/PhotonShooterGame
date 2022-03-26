using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class Launcher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //setting in appID and created scriptable object
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        SceneManager.LoadScene("Lobby");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }
    // Update is called once per frame
}

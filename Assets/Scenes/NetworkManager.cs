using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // Connect to Photon servers
        PhotonNetwork.ConnectUsingSettings();
    }

    // Other Photon-related callbacks and methods can go here
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class connectToServer : MonoBehaviourPunCallbacks
{
    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // You are connected to the Master Server, now join the lobby or create/join a room
        PhotonNetwork.JoinLobby();
    }



   public override void OnJoinedLobby()
   {
          SceneManager.LoadScene("Lobby");
   }
   
   
}

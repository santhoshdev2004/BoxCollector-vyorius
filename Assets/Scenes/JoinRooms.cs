using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;
using TMPro;

public class JoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField  createInput;
    public TMP_InputField joinInput;

    public void CreateRoom()
    {
       PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
       PhotonNetwork.JoinRoom(joinInput.text);
    }

    // Corrected method name to OnJoinedRoom
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Main Scene");
    }
}

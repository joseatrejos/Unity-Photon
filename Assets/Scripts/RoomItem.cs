using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomItem : MonoBehaviour
{
    [SerializeField] TMP_Text txtRoomName;

    Button btnJoinRoom;

    void Awake()
    {
        btnJoinRoom = GetComponent<Button>();
        btnJoinRoom.onClick.AddListener(JoinRoomClick);
    }

    void JoinRoomClick()
    {
        Launcher.instance.JoinRoomClick(RoomName);
    }

    public string RoomName => txtRoomName.text;

    public void SetroomName(string roomName) => txtRoomName.text = roomName;
}

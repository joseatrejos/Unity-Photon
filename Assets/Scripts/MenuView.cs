using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField] Button btnCreateRoom;
    [SerializeField] Button btnJoinGame;

    void Awake()
    {
        btnCreateRoom.onClick.AddListener(CreateRoomClick);
        btnJoinGame.onClick.AddListener(FindRoomClick);
    }

    void CreateRoomClick()
    {
        Launcher.instance.CreateRoom();
        Debug.Log("Room creation view");
    }

    void FindRoomClick()
    {
        Launcher.instance.FindRoomViewClick();
        Debug.Log("Game search");
    }
}

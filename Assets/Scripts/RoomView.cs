using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomView : MonoBehaviour
{
    [SerializeField] TMP_Text txtRoomName;

    [SerializeField] Button btnLeaveRoom;

    [SerializeField] RectTransform playerListContainer;

    [SerializeField] Object srcPlayerNicknameItem;

    void Awake()
    {
        btnLeaveRoom.onClick.AddListener(LeaveCurrentRoom);
    }

    public void SetRoomName(string roomName) => txtRoomName.text = roomName;

    void OnEnable()
    {
        SetRoomName(Launcher.instance.CurrentRoomName);
    }

    void LeaveCurrentRoom()
    {
        SetRoomName(string.Empty);
        Launcher.instance.LeaveCurrentRoom();
    }

    void ClearPlayerListContainer()
    {
        foreach (GameObject go in playerListContainer)
        {
            Destroy(go);
        }
    }

    public void FillPlayerListContainer(Player[] playerList)
    {
        ClearPlayerListContainer();

        foreach (Player player in playerList)
        {
            GameObject go = (GameObject)Instantiate(srcPlayerNicknameItem, playerListContainer);
            TMP_Text playerNicknameItem = go.GetComponent<TMP_Text>();
            playerNicknameItem.text = player.NickName;
        }
    }

    public void AddPlayerToListContainer(Player player)
    {
        GameObject go = (GameObject)Instantiate(srcPlayerNicknameItem, playerListContainer);
        TMP_Text playerNicknameItem = go.GetComponent<TMP_Text>();
        playerNicknameItem.text = player.NickName;
    }

    public void RemovePlayerFromListContainer(Player player)
    {
        foreach (GameObject go in playerListContainer)
        {
            TMP_Text playerNickNameItem = go.GetComponent<TMP_Text>();
            if (playerNickNameItem.text == player.NickName)
            {
                Destroy(go);
                break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher instance;

    [SerializeField] GameObject loading;

    [SerializeField] GameObject menuView;

    [SerializeField] GameObject createRoomView;

    [SerializeField] GameObject roomView;

    [SerializeField] RoomView roomViewObj;

    [SerializeField] GameObject setNicknameView;

    [SerializeField] GameObject findRoomView;

    [SerializeField] FindRoomView findRoomViewObj;

    bool firstTime = true;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        loading.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connection started");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinLobby();
    }
    
    public override void OnJoinedLobby()
    {
        if(firstTime)
        {
            loading.SetActive(false);
            setNicknameView.SetActive(true);
            Debug.Log("Set Nickname display");
            firstTime = false;
        }
        else
        {
            loading.SetActive(false);
            menuView.SetActive(true);
            Debug.Log("Back to menu");
        }
    }

    public void CreateRoom()
    {
        menuView.SetActive(false);
        createRoomView.SetActive(true);
    }

    public void CreateNewRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
        createRoomView.SetActive(false);
        loading.SetActive(true);
    }

    public void CancelRoomCreation()
    {
        createRoomView.SetActive(false);
        menuView.SetActive(true);
        Debug.Log("Back to main menu");
    }

    public override void OnJoinedRoom()
    {
        loading.SetActive(false);
        roomView.SetActive(true);
        Debug.Log($"Created room: {PhotonNetwork.CurrentRoom.Name}");
        roomViewObj.FillPlayerListContainer(PhotonNetwork.PlayerList);
    }

    public override void OnPlayerEnteredRoom(Player player)
    {
        roomViewObj.AddPlayerToListContainer(player);
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        roomViewObj.RemovePlayerFromListContainer(player);
    }

    public void LeaveCurrentRoom()
    {
        PhotonNetwork.LeaveRoom();
        roomView.SetActive(false);
        //menuView.SetActive(true);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Left the room");
    }

    public string CurrentRoomName => PhotonNetwork.CurrentRoom.Name;

    public void SetNickname(string nickname)
    {
        PhotonNetwork.NickName = nickname;
        setNicknameView.SetActive(false);
        menuView.SetActive(true);
        Debug.Log("MenuView displayed");
    }

    public void FindRoomViewClick()
    {
        menuView.SetActive(false);
        findRoomView.SetActive(true);
    }

    public void LeaveFoundRoomViewClick()
    {
        findRoomView.SetActive(false);
        menuView.SetActive(true);
        Debug.Log("Back to main menu");
    }

    public void JoinRoomClick(string roomName)
    {
        findRoomView.SetActive(false);
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        findRoomViewObj.FillRoomList(roomList);
    }
}

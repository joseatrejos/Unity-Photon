using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateRoomView : MonoBehaviour
{
    [SerializeField] TMP_InputField roomNameField;

    [SerializeField] Button btnCreateNewRoom;

    [SerializeField] Button btnCancel;

    void Awake()
    {
        btnCreateNewRoom.onClick.AddListener(CreateNewRoom);
        btnCancel.onClick.AddListener(Cancel);
    }

    string RoomName => roomNameField.text;
    bool RoomNameIsEmpty => string.IsNullOrEmpty(RoomName);

    void CreateNewRoom()
    {
        if (RoomNameIsEmpty)
        {
            Debug.Log("No room name defined.");
            return;
        }
        Launcher.instance.CreateNewRoom(RoomName);
    }

    void Cancel()
    {
        Launcher.instance.CancelRoomCreation();
    }
}
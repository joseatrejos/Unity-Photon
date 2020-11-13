using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class FindRoomView : MonoBehaviour
{
    [SerializeField] ScrollRect sRectRoomList;
    [SerializeField] Button btnLeaveFoundRoomView;
    [SerializeField] Object srcRoomItem;

    void Awake()
    {
        btnLeaveFoundRoomView.onClick.AddListener(Launcher.instance.LeaveFoundRoomViewClick);
    }

    void ClearRoomList()
    {
        foreach(GameObject go in sRectRoomList.content)
        {
            Destroy(go);
        }
    }

    public void FillRoomList(List<RoomInfo> rooms) 
    {
        ClearRoomList();

        foreach(RoomInfo room in rooms)
        {
            GameObject go = (GameObject)Instantiate(srcRoomItem, sRectRoomList.content);
            RoomItem roomItem = go.GetComponent<RoomItem>();
            roomItem.SetroomName(room.Name);
        }
    }
}

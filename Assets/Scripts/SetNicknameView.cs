using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetNicknameView : MonoBehaviour
{
    [SerializeField] TMP_InputField InNickname;
    [SerializeField] Button BtnSetNickname;

    void Awake()
    {
        BtnSetNickname.onClick.AddListener(ClickSetNickname);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickSetNickname()
    {
        if (NicknameEmpty) return;
        Launcher.instance.SetNickname(Nickname);
    }

    bool NicknameEmpty => string.IsNullOrEmpty(InNickname.text);

    string Nickname => InNickname.text;
}

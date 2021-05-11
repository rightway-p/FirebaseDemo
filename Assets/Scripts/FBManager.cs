using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Firebase 네임스페이스 선언
using Firebase;
using Firebase.Database;

// Firebase에 저장할 데이터 구조
public class User
{
    public string userName;
    public int gold;
    //public string[] equipItems;

    public User(string _userName, int _gold)
    {
        this.userName = _userName;
        this.gold     = _gold;
    }
}

public class FBManager : MonoBehaviour
{
    // 저장할 데이터 UI 항목
    public InputField userName;
    public InputField gold;

    // 파이어베이스 레퍼런스를 전역 선언
    private DatabaseReference reference;
    // 파이어베이스 데이터베이스의 고유주소(URI)
    private readonly string uri = "https://fir-demo-9af63-default-rtdb.firebaseio.com/";

    void Awake()
    {
        // 앱 속성 생성
        AppOptions options = new AppOptions();
        options.DatabaseUrl = new System.Uri(uri);
        // 앱을 생성
        FirebaseApp app = FirebaseApp.Create(options);
    }

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
}

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
        // 루트 레퍼런스를 할당
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    /*
        데이터 등록
        - SetRawJsonValueAsync()
        - JsonUtitiy.ToJson()    
    */
    public void InsertData()
    {
        // UI 입력값 
        string _userName = userName.text;
        int _gold        = int.Parse(gold.text); //String -> Int

        // 데이터 저장을 위한 클래스 생성
        User user = new User(_userName, _gold);

        // JSON 포맷으로 포맷팅
        string json = JsonUtility.ToJson(user);
        // UserData 노드를 생성하고 하위에 데이터를 추가
        reference.Child("UserData").Child(_userName).SetRawJsonValueAsync(json);
    }
}

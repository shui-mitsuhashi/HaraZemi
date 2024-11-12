// Unityでシリアル通信、Arduinoと連携する雛形

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomething : MonoBehaviour
{
    // 制御対象のオブジェクト用に宣言しておいて、Start関数内で名前で検索
    GameObject targetObject;
    Player targetScript; // UnityプロジェクトにPlayerオブジェクトがいる前提

    // シリアル通信のクラス、クラス名は正しく書くこと
    public SerialHandler serialHandler;

  void Start()
    {
        // 制御対象のオブジェクトを取得
        targetObject = GameObject.Find("Player"); // UnityのヒエラルキーにPlayerオブジェクトがいること。
        // 制御対象に関連付けられたスクリプトを取得。
        // 大文字、小文字を区別するので、player.csを作ったのなら「p」layer。
        targetScript = targetObject.GetComponent<Player>(); // こちらはスクリプトの名前

        // 信号受信時に呼ばれる関数としてOnDataReceived関数を登録
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void Update()
    {
        //文字列を送信するなら例えばココ
        //serialHandler.Write("hogehoge");
    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        // ここでデコード処理等を記述
        if(message == null)
            return;

        //targetScript.debugText.text = (message);

        string recevedDate;
        int t;

        //ボリューム１
        recevedDate = message.Substring(1, 4);
        int.TryParse(recevedDate, out t);
        targetScript.vol[0] = t;

        //ボリューム２
        recevedDate = message.Substring(5, 4);
        int.TryParse(recevedDate, out t);
        targetScript.vol[1] = t;

        //スイッチ１
        recevedDate = message.Substring(9, 1);
        int.TryParse(recevedDate, out t);
        targetScript.sw[0] = t;

        //スイッチ２
        recevedDate = message.Substring(10, 1);
        int.TryParse(recevedDate, out t);
        targetScript.sw[1] = t;

        //スイッチ３
        recevedDate = message.Substring(11, 1);
        int.TryParse(recevedDate, out t);
        targetScript.sw[2] = t;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rule : MonoBehaviour
{
    int _Hand1 = 0;
    int _Hand2 = 0;


    GameObject _Score1 = null;
    GameObject _Score2 = null;


    GameObject _Charge1 = null;
    GameObject _Charge2 = null;

    GameObject _Log = null;


    [SerializeField] int _ScoreNum1 = 10;
    [SerializeField] int _ScoreNum2 = 10;


    [SerializeField] int _CountNum1 = 0;
    [SerializeField] int _CountNum2 = 0;

    [SerializeField] int _DamageNormal = 1;
    [SerializeField] int _DamageCharge = 4;
    [SerializeField] int _DamageDefence = 1;

    Janken _player1 = Janken.Normal;
    Janken _player2 = Janken.Normal;
    // Start is called before the first frame update
    void Start()
    {
        _Score1 = GameObject.Find("MyLife");
        _Score2 = GameObject.Find("YourLife");
        Text score_text1 = _Score1.GetComponent<Text>();
        score_text1.text = "Player1Life:" + _ScoreNum1;
        Text score_text2 = _Score2.GetComponent<Text>();
        score_text2.text = "Player2Life:" + _ScoreNum2;


        _Charge1 = GameObject.Find("MyCount");
        _Charge2 = GameObject.Find("YourCount");
        Text charge_text1 = _Charge1.GetComponent<Text>();
        charge_text1.text = "Player1Charge:" + _CountNum1;
        Text charge_text2 = _Charge2.GetComponent<Text>();
        charge_text2.text = "Player2Charge:" + _CountNum2;

        _Log = GameObject.Find("Draw");
        Text draw = _Log.GetComponent<Text>();
        draw.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_CountNum1 == 3)
            {
                _Hand1 = 5;
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(_CountNum2 == 3)
            {
                _Hand2 = 5;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(_CountNum2 == 3)
            {
                _Hand1 = 6;
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(_CountNum1 == 3)
            {
                _Hand2 = 6;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _Hand1 = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            _Hand1 = 2;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _Hand1 = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            _Hand1 = 4;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            _Hand2 = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            _Hand2 = 2;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            _Hand2 = 3;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            _Hand2 = 4;
        }

        if (_Hand1 == 5 && _Hand2 == 5)
        {
            _CountNum1 = 0;
            Text charge_text1 = _Charge1.GetComponent<Text>();
            charge_text1.text = "Player1Charge:" + _CountNum1;
            _CountNum2 = 0;
            Text charge_text2 = _Charge2.GetComponent<Text>();
            charge_text2.text = "Player2Charge:" + _CountNum2;
            _Hand1 = 0;
            _Hand2 = 0;
            Text draw = _Log.GetComponent<Text>();
            draw.text = "二人はチャージ攻撃を使った。相殺された";
        }
        if (_Hand1 == 5 && _Hand2 == 1)
        {
            Text draw = _Log.GetComponent<Text>();
            
            if (_CountNum2 < 3)
            {
                _CountNum2 += 1;
                Text charge_text2 = _Charge2.GetComponent<Text>();
                charge_text2.text = "Player2Charge:" + _CountNum2;
                draw.text = "player1はチャージ攻撃をした。player2に4ダメージ。player2はチャージした";
            }
            else
            {  
                draw.text = "player1はチャージ攻撃をした。player2に4ダメージ。player2はチャージした。しかしチャージできなかった";
                
            }
            _ScoreNum2 -= _DamageCharge;
            Text score_text2 = _Score2.GetComponent<Text>();
            score_text2.text = "Player2Life:" + _ScoreNum2;
            _Hand1 = 0;
            _Hand2 = 0;
            _CountNum1 = 0;
            Text charge_text1 = _Charge1.GetComponent<Text>();
            charge_text1.text = "Player1Charge:" + _CountNum1;
            //draw.text = null;
        }
        if (_Hand1 == 5 && _Hand2 == 6)
        {
            _ScoreNum2 -= _DamageDefence;
            Text score_text2 = _Score2.GetComponent<Text>();
            score_text2.text = "Player2Life:" + _ScoreNum2;
            _Hand1 = 0;
            _Hand2 = 0;
            _CountNum1 = 0;
            Text charge_text1 = _Charge1.GetComponent<Text>();
            charge_text1.text = "Player1Charge:" + _CountNum1;
            Text draw = _Log.GetComponent<Text>();
            draw.text = "player1はチャージ攻撃をした。しかしplayer2はチャージ攻撃防御を使った。player2に1ダメージ";
        }
        if (_Hand1 == 5 && _Hand2 > 1)
        {
            _ScoreNum2 -= _DamageCharge;
            Text score_text2 = _Score2.GetComponent<Text>();
            score_text2.text = "Player2Life:" + _ScoreNum2;
            _Hand1 = 0;
            _Hand2 = 0;
            _CountNum1 = 0;
            Text charge_text1 = _Charge1.GetComponent<Text>();
            charge_text1.text = "Player1Charge:" + _CountNum1;
            Text draw = _Log.GetComponent<Text>();
            draw.text = "player1はチャージ攻撃をした。player2に4ダメージ";
        }
        
        if (_Hand1 == 1 && _Hand2 == 5)
        {
            Text draw = _Log.GetComponent<Text>();
            
            if (_CountNum1 < 3)
            {
                _CountNum1 += 1;
                Text charge_text1 = _Charge1.GetComponent<Text>();
                charge_text1.text = "Player1Charge:" + _CountNum1;
                draw.text = "player2はチャージ攻撃をした。player1に4ダメージ。player1はチャージした";
            }
            else
            {
                draw.text = "player2はチャージ攻撃をした。player1に4ダメージ。player1はチャージした。しかしチャージできなかった";
            }
            _ScoreNum1 -= _DamageCharge;
            Text score_text1 = _Score1.GetComponent<Text>();
            score_text1.text = "Player1Life:" + _ScoreNum1;
            _Hand1 = 0;
            _Hand2 = 0;
            _CountNum2 = 0;
            Text charge_text2 = _Charge2.GetComponent<Text>();
            charge_text2.text = "Player2Charge:" + _CountNum2;
            //draw.text = null;
        }
        if (_Hand1 == 6 && _Hand2 == 5)
        {
            _ScoreNum1 -= _DamageDefence;
            Text score_text1 = _Score1.GetComponent<Text>();
            score_text1.text = "Player1Life:" + _ScoreNum1;
            _Hand1 = 0;
            _Hand2 = 0;
            _CountNum2 = 0;
            Text charge_text2 = _Charge2.GetComponent<Text>();
            charge_text2.text = "Player2Charge:" + _CountNum2;
            Text draw = _Log.GetComponent<Text>();
            draw.text = "player2はチャージ攻撃をした。しかしplayer1はチャージ攻撃防御を使った。player1に1ダメージ";
        }
        if (_Hand1 > 1 && _Hand2 == 5)
        {
            _ScoreNum1 -= _DamageCharge;
            Text score_text1 = _Score1.GetComponent<Text>();
            score_text1.text = "Player1Life:" + _ScoreNum1;
            _Hand1 = 0;
            _Hand2 = 0;
            _CountNum2 = 0;
            Text charge_text2 = _Charge2.GetComponent<Text>();
            charge_text2.text = "Player2Charge:" + _CountNum2;
            Text draw = _Log.GetComponent<Text>();
            draw.text = "player2はチャージ攻撃をした。player1に4ダメージ";
        }
        
        if (_Hand1 == 1 && _Hand2 == 1)
        {
            Text draw = _Log.GetComponent<Text>();
            _Hand1 = 0;
            _Hand2 = 0;
            if (_CountNum1 < 3 && _CountNum2 < 3)
            {
                _CountNum1 += 1;
                Text charge_text1 = _Charge1.GetComponent<Text>();
                charge_text1.text = "Player1Charge:" + _CountNum1;

                _CountNum2 += 1;
                Text charge_text2 = _Charge2.GetComponent<Text>();
                charge_text2.text = "Player2Charge:" + _CountNum2;
                draw.text = "二人はチャージした";
            }
            else if (_CountNum1 < 3)
            {
                _CountNum1 += 1;
                Text charge_text1 = _Charge1.GetComponent<Text>();
                charge_text1.text = "Player1Charge:" + _CountNum1;
                draw.text = "player1はチャージした。player2はチャージできなかった";
            }
            else if (_CountNum2 < 3)
            {
                _CountNum2 += 1;
                Text charge_text2 = _Charge2.GetComponent<Text>();
                charge_text2.text = "Player2Charge:" + _CountNum2;
                draw.text = "player2はチャージした。player1はチャージできなかった";
            }
            else if(_CountNum1 == 3 && _CountNum2 == 3)
            {
                draw.text = "二人はチャージした。しかし二人はチャージできなかった";
            }
            
            //draw.text = null;
        }
        else if (_Hand1 == 1 && _Hand2 > 1)
        {
            Text draw = _Log.GetComponent<Text>();
            
            if (_CountNum1 < 3)
            {
                _CountNum1 += 1;
                Text charge_text1 = _Charge1.GetComponent<Text>();
                charge_text1.text = "Player1Charge:" + _CountNum1;
                draw.text = "player2はplayer1に1ダメージ。player1はチャージした";
            }
            else
            {
                draw.text = "player2はplayer1に1ダメージ。player1はチャージした。player1はチャージできなかった";
            }
            _ScoreNum1 -= _DamageNormal;
            Text score_text1 = _Score1.GetComponent<Text>();
            score_text1.text = "Player1Life:" + _ScoreNum1;
            _Hand1 = 0;
            _Hand2 = 0;
            //draw.text = null;
        }
        else if (_Hand1 > 1 && _Hand2 == 1)
        {
            Text draw = _Log.GetComponent<Text>();
            
            if (_CountNum2 < 3)
            {
                _CountNum2 += 1;
                Text charge_text2 = _Charge2.GetComponent<Text>();
                charge_text2.text = "Player2Charge:" + _CountNum2;
                draw.text = "player1はplayer2に1ダメージ。player2はチャージした";
            }
            else
            {
                draw.text = "player1はplayer2に1ダメージ。player2はチャージした。player2はチャージできなかった";
            }
            _ScoreNum2 -= _DamageNormal;
            Text score_text2 = _Score2.GetComponent<Text>();
            score_text2.text = "Player2Life:" + _ScoreNum2;
            _Hand1 = 0;
            _Hand2 = 0;
            //draw.text = null;
        }
        else if (_Hand1 > 1 && _Hand2 > 1)
        {
            Text draw = _Log.GetComponent<Text>();
            if (_Hand1 == _Hand2)
            {
                draw.text = "あいこ";
            }
            else if 
                ((_Hand1 == 2 && _Hand2 == 3) ||
                (_Hand1 == 3 && _Hand2 == 4) ||
                (_Hand1 == 4 && _Hand2 == 2))
            {
                draw.text = "player1はplayer2に1ダメージ";
                _ScoreNum2 -= _DamageNormal;
                Text score_text2 = _Score2.GetComponent<Text>();
                score_text2.text = "Player2Life:" + _ScoreNum2;
            }
            else
            {
                draw.text = "player2はplayer1に1ダメージ";
                _ScoreNum1 -= _DamageNormal;
                Text score_text1 = _Score1.GetComponent<Text>();
                score_text1.text = "Player1Life:" + _ScoreNum1;
            }
            _Hand1 = 0;
            _Hand2 = 0;
            //draw.text = null;
        }
        if (_ScoreNum1 <= 0)
        {
            Debug.Log("player2");
            SceneManager.LoadScene("Player2Win");
        }
        if (_ScoreNum2 <= 0)
        {
            Debug.Log("player1");
            SceneManager.LoadScene("Player1Win");
        }
    }
}
enum Janken
{
    Normal,
    Gu,
    Tyoki,
    Pa,
    Charge,
    ChargeAtack,
    ChargeDefence
}


using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject mainImage; //アナウンスをする画像
    public GameObject buttonPanel; //ボタンをグループ化しているパネル

    public GameObject retryButton; //リトライボタン
    public GameObject nextButton; //ネクストボタン

    public Sprite gameClearSprite; //ゲームクリアの絵
    public Sprite gameOverSprite; //ゲームオーバーの絵

    TimeController timeCnt; //TimeController.csの参照
    public GameObject timeText;  //ゲームオブジェクトであるTimeText

    public GameObject scoreText; //スコアテキスト

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //同じCanvasについているTimeControllerスクリプトを取得
        timeCnt = GetComponent<TimeController>();

        buttonPanel.SetActive(false); //存在を非表示

        //時間差でメソッドを発動
        Invoke("InactiveImage", 1.0f);


        UpdateScore();　//トータルスコアが出るように更新

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == "gameclear")
        {
            buttonPanel.SetActive(true); //ボタンパネルの復活
            mainImage.SetActive(true); //メイン画像の復活
            //メイン画像オブジェクトのImageコンポーネントが所持している変数sprite に ”ステージクリア”の絵を代入
            mainImage.GetComponent<Image>().sprite = gameClearSprite;
            //リトライボタンオブジェクトのButtonコンポーネントが所持している変数interactableを無効（ボタン機能を無効）
            retryButton.GetComponent<Button>().interactable = false;

            //ステージクリアによってステージスコアが確定したので
            //トータルスコアに加算
            GameManager.totalScore += GameManager.stageScore;
            GameManager.stageScore = 0; //次に備えてステージスコアはリセット

            timeCnt.isTimeOver = true; //タイムカウント停止
            //いったんdisplayTimeの数字を変数timesに渡す
            float times = timeCnt.displayTime;

            if (timeCnt.isCountDown) //カウントダウン
            {
                //残時間をそのままタイムボーナスとしてトータルスコアに加算
                GameManager.totalScore += (int)times * 10;
            }
            else //カウントアップ
            {
                float gameTime = timeCnt.gameTime; //基準時間の取得
                GameManager.totalScore += (int)(gameTime - times) * 10;
            }

            UpdateScore(); //UIに最終的な数字を反映

            //２重３重にスコアを加算しないようgameclearのフラグは早々に変化
            GameManager.gameState = "gameend";

        }
        else if (GameManager.gameState == "gameover")
        {
            buttonPanel.SetActive(true); //ボタンパネルの復活
            mainImage.SetActive(true); //メイン画像の復活
            //メイン画像オブジェクトのImageコンポーネントが所持している変数sprite に ”ゲームオーバー”の絵を代入
            mainImage.GetComponent<Image>().sprite = gameOverSprite;
            //ネクストボタンオブジェクトのButtonコンポーネントが所持している変数interactableを無効（ボタン機能を無効）
            nextButton.GetComponent<Button>().interactable = false;

            //カウント止める
            timeCnt.isTimeOver = true;

            GameManager.gameState = "gameend";
        }
        else if (GameManager.gameState == "playing")
        {
            //いったんdisplayTimeの数字を変数timesに渡す
            float times = timeCnt.displayTime;
            timeText.GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(times).ToString();

            //スコアもリアルタイムに更新
            UpdateScore();
        }
    }

    //メイン画像を非表示するためだけのメソッド
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    //スコアボードを更新
    void UpdateScore()
    {
        int score = GameManager.stageScore + GameManager.totalScore;
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
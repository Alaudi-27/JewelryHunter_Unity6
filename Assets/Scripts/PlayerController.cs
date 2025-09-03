using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; //PlayerについているRigidbody2Dを扱うための変数

    float axisH; //入力の方向を記憶するための変数
    public float speed = 3.0f; //プレイヤーのスピードを調整

    public float jumpPower = 9.0f; //ジャンプ力
    bool goJump = false; //ジャンプフラグ（true:真on、false:偽off）

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //Playerについているコンポーネント情報を取得
    }

    // Update is called once per frame
    void Update()
    {
        //Velocityの元となる値の取得（右なら1.0f、左なら-1.0f、なにもなければ0)
        axisH = Input.GetAxisRaw("Horizontal");

        if (axisH > 0)
        {
            //右を向く
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (axisH < 0)
        {
            //左を向く
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //GetButtonDownメソッド→引数に指定したボタンが押されたらtrueを返す、押されてなければfalseを返す
        if (Input.GetButtonDown("Jump"))
        {
            Jump();//Jumpメソッドの発動
        }

    }

    //1秒間に50回(50fps)繰り返すように制御しながら行う繰り返しメソッド
    void FixedUpdate()
    {
        //Velocityに値を代入
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

        //ジャンプフラグが立ったら
        if (goJump == true)
        {
            //ジャンプさせる→プレイヤーを上に押し出す
            rbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            goJump = false; //フラグをOFFに戻す
        }
    }

    //ジャンプボタンが押されたときに呼び出されるメソッド
    void Jump()
    {
        goJump = true; //ジャンプフラグをON
    }

}

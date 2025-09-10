using UnityEngine;

public class CanonController : MonoBehaviour
{
    [Header("生成プレハブ/時間/速度/範囲")]
    public GameObject objPrefab;
    public float delayTime = 3.0f;
    public float fireSpeed = 4.0f;
    public float length = 8.0f;

    [Header("発射口")]
    public Transform gateTransform;

    GameObject player;
    float passedTimes = 0;

    AudioSource audioSource;
    public AudioClip se_Shoot;

    //距離チェック
    bool CheckLength(Vector2 targetPos)
    {
        bool ret = false;
        float d = Vector2.Distance(transform.position, targetPos);
        if (length >= d)
        {
            ret = true;
        }
        return ret;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //
        player = GameObject.FindGameObjectWithTag("Player");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        passedTimes += Time.deltaTime;
        //
        if (CheckLength(player.transform.position))
        {
            //待機時間経過
            if (passedTimes > delayTime)
            {
                passedTimes = 0; //
                //砲弾をプレハブから作る
                Vector2 pos = new Vector2(gateTransform.position.x, gateTransform.position.y);
                GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
                //砲身が向いている方向に発射する
                Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                float angleZ = transform.localEulerAngles.z;
                float x = Mathf.Cos(angleZ * Mathf.Deg2Red);
                float y = Mathf.Sin(angleZ * Mathf.Deg2Red);
                Vector2 v = new Vector2(x, y); * fireSpeed;
                rbody.AddForce(v, ForceMode2D.Impulse);

                audioSource.PlayOneShot(se_Shoot);
            }
        }
    }
}

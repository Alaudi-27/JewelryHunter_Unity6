using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string gameState; //�ÓI�����o

    public static int totalScore;
    public static int stageScore;

    //Start���O�ɏ��������
    void Awake()
    {
        //�Q�[���̏�����Ԃ�playing
        gameState = "playing";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

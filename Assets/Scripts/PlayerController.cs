using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidobody2D rbody; //Player�ɂ��Ă���Rigidbdy2D���������߂̕ϐ�

    float axisH; //���͂̕������L�����邽�߂̕ϐ�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetConponent<Rigidbody2D>(); //Player�ɂ��Ă���R���|�[�l���g�����擾 
    }

    // Update is called once per frame
    void Update()
    {
        //Velovcity�̌��ƂȂ�l�̎擾�i�E�Ȃ�1.0f�A���Ȃ�-1.0f�A�Ȃɂ��Ȃ����0�j
        axisH = Input.GetAxisRaw("Horizontal");

        //Velocity�ɒl����
        rbody.linearVelocity = new Vector2(axisH.0);

    }
}

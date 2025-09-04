using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    float x, y, z; //�J�����̍��W�����߂邽�߂̕ϐ�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Player�^�O���������Q�[���I�u�W�F�N�g��T���āA�ϐ�player�ɑ��
        player = GameObject.FindGameObjectWithTag("Player");
        //�J������Z���W�͏����l�̂܂܈ێ�������
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //��������v���C���[��X���W�AY���W�̈ʒu��ϐ��Ɏ擾
        x = player.transform.position.x;
        y = player.transform.position.y;

        //��茈�߂��e�ϐ�x,y,z�̒l���J�����̃|�W�V�����Ƃ���
        transform.position = new Vector3(x, y, z);
    }
}

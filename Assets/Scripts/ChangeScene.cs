using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; //�؂�ւ������V�[�������w��

    //�V�[����؂�ւ���@�\�����������\�b�h�쐬
    public void Load()
    {
        //�V�[�����؂�ւ��ۂ͂�����ɂ��Ă��X�e�[�W�X�R�A�̓��Z�b�g
        GameManager.stageScore = 0;

        //�����Ɏw���������O�̃V�[���ɐ؂�ւ����Ă���郁�\�b�h�̌Ăяo��
        SceneManager.LoadScene(sceneName);
    }

}

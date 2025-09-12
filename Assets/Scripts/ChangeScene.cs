using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; //切り替えたいシーン名を指名

    //シーンを切り替える機能を持ったメソッド作成
    public void Load()
    {
        //シーンが切り替わる際はいずれにしてもステージスコアはリセット
        GameManager.stageScore = 0;

        //引数に指名した名前のシーンに切り替えしてくれるメソッドの呼び出し
        SceneManager.LoadScene(sceneName);
    }

}

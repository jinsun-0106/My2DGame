using UnityEngine;
using TMPro;

namespace MyBird
{
    /// <summary>
    /// 플레이 화면 스코어 그리기
    /// </summary>
    public class ScoreUI : MonoBehaviour
    {
        //Variables
        public TextMeshProUGUI scoreUI;

        //Unity Event Method
        private void Update()
        {
            scoreUI.text = GameManager.Score.ToString();
        }

    }
}

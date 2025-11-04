using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

namespace MyBird
{
    /// <summary>
    /// 게임 오버 UI를 관리하는 클래스
    /// </summary>
    public class DrawGameOverUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI bestScoreText;

        public GameObject newText;

        private string sceneName = "TitleScene";
        #endregion

        #region Unity Event Method
        //게임오버 UI 값 설정
        private void OnEnable()
        {
            scoreText.text = GameManager.Score.ToString();

            //베스트 스코어 가져오기
            int bestScore = PlayerPrefs.GetInt("BestScore", 0);

            //베스트 스코어와 현재 스코어 비교해서 베스트 스코어 갱신
            if(GameManager.Score > bestScore)
            {
                bestScore = GameManager.Score;

                //베스트 스코어 저장
                PlayerPrefs.SetInt("BestScore", bestScore);

                //UI
                newText.SetActive(true);

            }

            bestScoreText.text = bestScore.ToString();


        }

        private void Update()
        {
            
        }

        #endregion

        #region Custom Method
        public void Retry()
        {
            string nowScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(nowScene);

        }

        public void Menu()
        {
            SceneManager.LoadScene(sceneName);
        }

        #endregion

    }
}

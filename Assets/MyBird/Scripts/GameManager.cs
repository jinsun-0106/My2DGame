using UnityEngine;

namespace MyBird
{
    /// <summary>
    /// 게임 전체(흐름)를 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임 시작 여부 체크
        private static bool isStrat;

        //게임 오버 체크
        private static bool isDeath;

        //게임 스코어
        private static int score;

        public static float spawnValue = 0f;
        #endregion

        #region Property
        public static bool IsStart
        {
            get { return isStrat; }
            set { isStrat = value; }
        }

        public static bool IsDeath
        {
            get { return isDeath; }
            set { isDeath = value; }
        }

        public static int Score
        {
            get { return score; }
            set { score = value; }
        }
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            isStrat = false;
            isDeath = false;
            score = 0;
            spawnValue = 0f;
        }

        private void Update()
        {
            //유니티에서만 사용됨
#if UNITY_EDITOR
            //치팅 - 저장 데이터 삭제
            if(Input.GetKeyDown(KeyCode.P))
            {
                PlayerPrefs.DeleteAll();
            }
#endif
        }
        #endregion
    }
}

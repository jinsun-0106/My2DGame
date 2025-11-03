using UnityEngine;

namespace MyBird
{
    /// <summary>
    /// 게임 전체(흐름)를 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        private static bool isStrat;
        #endregion

        #region Property
        public static bool IsStart
        {
            get { return isStrat; }
            set { isStrat = value; }
        }
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            isStrat = false;
        }
        #endregion
    }
}

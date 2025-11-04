using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyBird
{
    public class Title : MonoBehaviour
    {
        #region
        private string sceneName = "PlayScene";
        #endregion

        #region Custom Method
        public void PlayButton()
        {
            SceneManager.LoadScene(sceneName);
            //Debug.Log("플레이화면으로");
        }

        #endregion
    }
}

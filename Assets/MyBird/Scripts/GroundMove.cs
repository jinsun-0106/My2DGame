using UnityEngine;

namespace MyBird
{
    /// <summary>
    /// 그라운드 배경 이동(롤링) 구현
    /// </summary>
    public class GroundMove : MonoBehaviour
    {
        #region Variables
        //이동속도
        [SerializeField]
        private float moveSpeed = 3f;

        #endregion

        #region Unity Event Method
        private void Update()
        {
            //그라운드 롤링 이동
            RollingMove();
        }
        #endregion

        #region Custom Method
        void RollingMove()
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);

            if (this.transform.localPosition.x <= -8.4)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x + 8.4f, this.transform.localPosition.y, this.transform.localPosition.z);
            }           
            
        }

        #endregion
    }
}

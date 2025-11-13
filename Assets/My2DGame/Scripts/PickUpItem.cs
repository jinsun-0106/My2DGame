using UnityEngine;

namespace My2DGame
{
    /// <summary>
    /// 플레이어 충돌 시 HP값이 아이템 능력치 만큼 회복
    /// 만약 플레이어 HP가 max으면 못 먹게 한다
    /// 아이템을 먹으면 맵에서 킬
    /// </summary>
    public class PickUpItem : MonoBehaviour
    {
        #region Variables
        //회복량
        [SerializeField] private float healRestore = 10f;

        //회전 속도
        [SerializeField] private float rotationSpeed = 10f;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //아이템 회전
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //아이템 픽업
            bool isPickup = Pickup(collision);

            if(isPickup)
            {
                Destroy(this.gameObject);
            }
        }
        #endregion

        #region Custom Method
        //픽업 시 아이템 효과 구현, 픽업 성공 시 true, 실패 시 false; - hp회복
        protected virtual bool Pickup(Collider2D collision)
        {
            bool isUse = false;

            Damageable damageable = collision.GetComponent<Damageable>();

            if (damageable != null)
            {
                isUse = damageable.Heal(healRestore);
            }

            return isUse;

        }
        #endregion
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

namespace My2DGame
{
    /// <summary>
    /// 플레이어를 제어하는 클래스
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        //참조
        private Rigidbody2D rb2D;
        private Animator animator;

        //이동 속도 - 걷는 속도
        [SerializeField]
        private float walkSpeed = 3f;

        //이동속도 - 뛰는 속도
        [SerializeField]
        private float runSpeed = 6f;

        //이동 입력값
        private Vector2 inputMove = Vector2.zero;

        //걷기 애니메이션
        private bool isMove = false;

        //뛰기 애니메이션
        private bool isRun = false;

        //반전
        private bool isFacingRight = true;

        #endregion

        #region Property
        
        public bool IsFacingRight
        {
            get { return isFacingRight; }
            private set
            {
                //반전 구현
                if(IsFacingRight != value)
                {
                    this.transform.localScale *= new Vector2(-1, 1);
                }

                isFacingRight = value;
            }
        }

        public bool IsMove
        {
            get { return isMove; }
            private set 
            {  
                isMove = value;
                animator.SetBool(AnimationString.IsMove, value);
            }
        }

        public bool IsRun
        {
            get { return isRun; }
            private set
            {
                isRun = value;
                animator.SetBool(AnimationString.IsRun, value);
            }
        }

        //현재 이동 속도 - 읽기 전용
        public float CurrentMoveSpeed
        {
            get
            {
                if(IsMove)    //이동 가능
                {
                    if(IsRun)
                    {
                        return runSpeed;
                    }
                    else
                    {
                        return walkSpeed;
                    }
                }
                else    //이동 불가
                {
                    return 0f;
                }
            }
        }
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조
            rb2D = this.GetComponent<Rigidbody2D>();

            //애니메이션 참조
            animator = this.GetComponent<Animator>();

        }

        private void FixedUpdate()
        {

            //좌우이동
            rb2D.linearVelocity = new Vector2(inputMove.x * CurrentMoveSpeed, rb2D.linearVelocity.y);
            //rb2D.linearVelocity = new Vector2(inputMove.x * walkSpeed, inputMove.y * walkSpeed);          //좌우위아래 이동

        }

        #endregion

        #region Custom method
        //반향 전환
        void SetFacingDirection(Vector2 moveInput)
        {
            if(moveInput.x > 0f && IsFacingRight == false)            //오른쪽으로 이동
            {
                IsFacingRight = true;
            }
            else if (moveInput.x < 0f && IsFacingRight == true)      //왼쪽으로 이동
            {
                IsFacingRight = false;
            }
        }

        public void PlayerMove(InputAction.CallbackContext context)
        {
            inputMove = context.ReadValue<Vector2>();
            //Debug.Log(inputMove);

            IsMove = (inputMove != Vector2.zero);

            //방향 전환
            SetFacingDirection(inputMove);
        }

        public void PlayerRun(InputAction.CallbackContext context)
        {
            if(context.started)     //버튼을 눌렀을 때 (누르기 시작했을 때)
            {
                IsRun = true;
            }
            else if(context.canceled)   //버튼을 뗄 때
            {
                IsRun = false;                
            }
        }

        public void PlayerJump(InputAction.CallbackContext context)
        {
            if (context.started)     //버튼을 눌렀을 때 (누르기 시작했을 때)
            {
                animator.SetTrigger("JumpTrigger");
                rb2D.gravityScale = -1f;
            }
            else if (context.canceled)   //버튼을 뗄 때
            {
                rb2D.gravityScale = 1f;
            }
        }

        #endregion
    }
}

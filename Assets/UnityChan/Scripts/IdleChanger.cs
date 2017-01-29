using UnityEngine;
using System.Collections;

namespace UnityChan
{
    // Require these components when using this script
    [RequireComponent(typeof(Animator))]

	public class IdleChanger : MonoBehaviour
	{
	
		private Animator anim;						// Animatorへの参照
		private AnimatorStateInfo currentState;		// 現在のステート状態を保存する参照
        public bool isGUI = true;
        
        static int standingState = Animator.StringToHash("Base Layer.Standing@loop");
        static int walkingState = Animator.StringToHash("Base Layer.Walking@loop");

        public Transform lookAtObj = null;

        private float startPosZ;

        // Use this for initialization
        void Start ()
		{
			// 各参照の初期化
			anim = GetComponent<Animator> ();
			currentState = anim.GetCurrentAnimatorStateInfo (0);
            startPosZ = transform.position.z;
            transform.position = new Vector3(transform.position.x, transform.position.y, startPosZ);
        }
	
		// Update is called once per frame
		void  Update ()
		{
            
            transform.LookAt(new Vector3(lookAtObj.position.x, 0, lookAtObj.position.z), new Vector3(0,1,0));

            //左クリック時の処理
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("Jump", true);
                transform.position = new Vector3(transform.position.x, transform.position.y, startPosZ);
                
            }

            //カーソルが移動した時の処理
            //targetとの距離がしきい値dxより大きくなったら歩く
            float dx = transform.position.x - lookAtObj.position.x;

            if (lookAtObj != null)
            {
                
                if (Mathf.Abs(dx) > 0.3f)
                {
                    currentState = anim.GetCurrentAnimatorStateInfo(0);
                    anim.SetBool("Walk", true);
                }
                else
                {
                    anim.SetBool("Walk", false);
                    currentState = anim.GetCurrentAnimatorStateInfo(0);
                }
            }
            

            if (currentState.fullPathHash == walkingState)
            {
                transform.position = new Vector3(transform.position.x - Mathf.Sign(dx)*0.01f, transform.position.y, startPosZ);
            }

            if (currentState.fullPathHash == standingState)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, startPosZ);
            }
        }

    }
}

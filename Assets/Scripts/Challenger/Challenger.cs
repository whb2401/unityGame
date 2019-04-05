using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessChallenges
{
    public class Challenger : MonoBehaviour
    {
        public enum ChallengerAction
        {
            Idle,//发呆
            Move,//移动
            Run,//跑动
            Death,//死亡
            Stun,//晕眩

        }

        public enum ChallengerActionStatus
        {
            Nomal,//正常
            ActionRestricted,//移动受限
            ActionSlowly,//动作缓慢
        }


        public enum ChallengerStatus
        {
            Normal,//正常
            HurtInvalid,//伤害免疫

        }

        //private Bag bag;
        //private EquipmentBar bar;

        public float WalkSpeed = 0.3f;
        public float AllSpeed = 1f;
        public Animator animator;
        private Dictionary<Coroutine, ChallengerAction> actions = new Dictionary<Coroutine, ChallengerAction>();

        private ChallengerAction CurrentAction = ChallengerAction.Idle;


        void Start()
        {
            CurrentAction = ChallengerAction.Idle;
        }

        public void MoveWtihTouch(object o, TouchCotroller.TouchResult result)
        {
            if (result != null)
            {
                if (result.hitInfo.collider == null || result.hitInfo.collider.gameObject.layer != 9)
                {
                    return;
                }
                var targetPos = result.hitInfo.point;

                var direction = targetPos - this.transform.position;
                Move(targetPos, direction, AllSpeed);
            }
            else
            {
                Debug.Log("[EndllessChallenger]touch result is null");
            }
        }

        void Move(Vector3 targetPos, Vector3 direction, float speed)
        {
            StopMoveAction();
            PlayAnimation(ChallengerAction.Move);
            CurrentAction = ChallengerAction.Move;
            var coroutine = StartCoroutine(MoveAction(targetPos, direction, speed));
            
            actions.Add(coroutine, CurrentAction);
        }

        void StopMoveAction()
        {
            List<Coroutine> move_actions = new List<Coroutine>();
            foreach (var action in actions)
            {
                if (action.Value == ChallengerAction.Move || action.Value == ChallengerAction.Run)
                {
                    move_actions.Add(action.Key);
                }
            }
            foreach (var action in move_actions)
            {
                StopCoroutine(action);
                actions.Remove(action);
            }
        }

        IEnumerator MoveAction(Vector3 targetPos, Vector3 direction, float speed)
        {
            var idleWorldPos = this.transform.position;
            var idleToTarget = targetPos - idleWorldPos;

            var willWalkPathLen = idleToTarget.magnitude;

            while (true)
            {
                var workingPathLen = (this.transform.position - idleWorldPos).magnitude;
                if (workingPathLen <= willWalkPathLen)
                {
                    transform.position += idleToTarget.normalized * WalkSpeed * speed;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up), speed * WalkSpeed);
                    yield return 0;
                }
                else
                {
                    ActionEnd();
                    yield break;
                }
            }
        }

        void Update()
        {
        }

        void PlayAnimation(ChallengerAction action)
        {
            if (action != CurrentAction)
            {
                animator.SetTrigger(action.ToString().ToLower());
            }
        }

        void ActionEnd()
        {
            PlayAnimation(ChallengerAction.Idle);
            CurrentAction = ChallengerAction.Idle;
        }
    }
}



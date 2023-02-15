using UnityEngine;

namespace Witch.State
{
    public class WitchAttackState : WitchBaseState
    {
        public override void EnterState(WitchStateManager witchStateManager)
        {
        }

        public override void UpdateState(WitchStateManager witchStateManager)
        {
            witchStateManager.CheckWitchIsDead();
            
            var closestOpponent = witchStateManager.MinionFindOpponent.FindClosestOpponent();

            if (closestOpponent == null)
            {
                witchStateManager.SwitchState(witchStateManager.IdleState);
                return;
            }

            //LookAtOpponent(witchStateManager.transform, closestOpponent.position);
            witchStateManager.LookAtOpponent.LookAt(closestOpponent.position);
            AttemptAttack(witchStateManager);
        }

        private void AttemptAttack(WitchStateManager witchStateManager)
        {
            var attackSystem = witchStateManager.WitchAttack;

            if (Time.time >= attackSystem.NextAttackTime)
            {
                attackSystem.SetNextAttackTime();
                witchStateManager.MinionAnimationController.TriggerAttackAnim();
            }
        }

        // private void LookAtOpponent(Transform witchStateTransform, Vector3 opponentPos)
        // {
        //     var direction = opponentPos - witchStateTransform.position;
        //     direction.y = 0;
        //     witchStateTransform.forward = Vector3.Lerp(witchStateTransform.forward, direction, 5 * Time.deltaTime);
        // }
    }
}
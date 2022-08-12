using UnityEngine;
using RootMotion.FinalIK;

namespace HutongGames.PlayMaker.Actions
{
    // The base abstract class for all Interaction System related actions
    [ActionCategory("Final IK")]
    [Tooltip("Starts a hit reaction with the HitReaction component.")]
    public class HitReactionAction : FsmStateAction
    {

        [RequiredField]
        [CheckForComponent(typeof(HitReaction))]
        [CheckForComponent(typeof(FullBodyBipedIK))]
        [Tooltip("The gameobject with the HitReaction component")]
        public FsmOwnerDefault hitReaction;

        [Tooltip("The object that was hit")]
        public FsmGameObject hitObject;

        [Tooltip("The direction of the ray")]
        public FsmVector3 direction;

        [Tooltip("The hit force")]
        public FsmFloat force;

        [Tooltip("The RaycastHit point")]
        public FsmVector3 hitPoint;

        public override void Reset()
        {
            hitReaction = null;
            hitObject = new FsmGameObject() { UseVariable = true };
            direction = new FsmVector3() { UseVariable = true };
            force = new FsmFloat() { UseVariable = true };
            hitPoint = new FsmVector3() { UseVariable = true };
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(hitReaction);
            if (go == null) return;

            var r = go.GetComponent<HitReaction>();
            if (r == null) return;

            var c = hitObject.Value.GetComponent<Collider>();
            if (c == null) return;

            r.Hit(c, direction.Value * force.Value, hitPoint.Value);

            Finish();
        }
    }
}

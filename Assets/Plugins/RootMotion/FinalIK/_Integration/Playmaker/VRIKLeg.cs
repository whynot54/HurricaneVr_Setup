using UnityEngine;
using RootMotion.FinalIK;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Final IK")]
    [Tooltip("Manages VRIK Leg settings")]
    public class VRIKLeg : IKAction
    {
        [System.Serializable]
        public enum Side
        {
            Left = 0,
            Right = 1
        }

        public Side side;

        [ActionSection("Arm Settings")]

        [Tooltip("The target Transform")]
        public FsmGameObject target;

        [Tooltip("The elbow will be bent towards this Transform if 'Bend Goal Weight' > 0.")]
        public FsmGameObject bendGoal;

        [HasFloatSlider(0, 1)]
        [Tooltip("Position weight.")]
        public FsmFloat positionWeight;

        [HasFloatSlider(0, 1)]
        [Tooltip("Rotation weight.")]
        public FsmFloat rotationWeight;

        [HasFloatSlider(0, 1)]
        [Tooltip("If greater than 0, will bend the elbow towards the 'Bend Goal' Transform.")]
        public FsmFloat bendGoalWeight;

        [HasFloatSlider(-180, 180)]
        [Tooltip("Angular offset of the elbow bending direction.")]
        public FsmFloat swivelOffset;

        [HasFloatSlider(0, 1)]
        [Tooltip("If 0, the bend plane will be locked to the rotation of the pelvis and rotating the foot will have no effect on the knee direction. If 1, to the target rotation of the leg so that the knee will bend towards the forward axis of the foot. Values in between will be slerped between the two.")]
        public FsmFloat bendToTargetWeight;

        [HasFloatSlider(0.01f, 2)]
        [Tooltip("Use this to make the arm shorter/longer.")]
        public FsmFloat legLengthMlp;

        protected override void ResetAction()
        {
            target = new FsmGameObject { UseVariable = true };
            bendGoal = new FsmGameObject { UseVariable = true };
            positionWeight = new FsmFloat { UseVariable = true };
            rotationWeight = new FsmFloat { UseVariable = true };
            bendGoalWeight = new FsmFloat { UseVariable = true };
            swivelOffset = new FsmFloat { UseVariable = true };
            bendToTargetWeight = new FsmFloat { UseVariable = true };
            legLengthMlp = new FsmFloat { UseVariable = true };

            // Default values
            positionWeight = 0f;
            rotationWeight = 0f;
            bendToTargetWeight = 0.5f;
            legLengthMlp = 1f;
        }

        protected override void UpdateAction()
        {
            var solver = (component as RootMotion.FinalIK.VRIK).solver;
            var leg = side == Side.Left ? solver.leftLeg : solver.rightLeg;

            leg.target = GetTransform(target);
            leg.bendGoal = GetTransform(bendGoal);
            leg.positionWeight = positionWeight.Value;
            leg.rotationWeight = rotationWeight.Value;
            leg.bendGoalWeight = bendGoalWeight.Value;
            leg.swivelOffset = swivelOffset.Value;
            leg.bendToTargetWeight = bendToTargetWeight.Value;
            leg.legLengthMlp = legLengthMlp.Value;
        }

        protected override System.Type GetComponentType()
        {
            return typeof(RootMotion.FinalIK.VRIK);
        }

        private Transform GetTransform(FsmGameObject g)
        {
            return g.Value == null ? null : g.Value.transform;
        }
    }
}
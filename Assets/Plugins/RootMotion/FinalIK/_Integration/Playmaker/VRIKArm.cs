using UnityEngine;
using RootMotion.FinalIK;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Final IK")]
    [Tooltip("Manages VRIK arm settings")]
    public class VRIKArm : IKAction
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
        [Tooltip("The weight of shoulder rotation.")]
        public FsmFloat shoulderRotationWeight;

        [HasFloatSlider(0, 1)]
        [Tooltip("The weight of twisting the shoulders back when arms are lifted up.")]
        public FsmFloat shoulderTwistWeight;

        [HasFloatSlider(0, 1)]
        [Tooltip("If greater than 0, will bend the elbow towards the 'Bend Goal' Transform.")]
        public FsmFloat bendGoalWeight;

        [HasFloatSlider(-180, 180)]
        [Tooltip("Angular offset of the elbow bending direction.")]
        public FsmFloat swivelOffset;

        [HasFloatSlider(0.01f, 2)]
        [Tooltip("Use this to make the arm shorter/longer.")]
        public FsmFloat armLengthMlp;

        protected override void ResetAction()
        {
            target = new FsmGameObject { UseVariable = true };
            bendGoal = new FsmGameObject { UseVariable = true };
            positionWeight = new FsmFloat { UseVariable = true };
            rotationWeight = new FsmFloat { UseVariable = true };
            shoulderRotationWeight = new FsmFloat { UseVariable = true };
            shoulderTwistWeight = new FsmFloat { UseVariable = true };
            bendGoalWeight = new FsmFloat { UseVariable = true };
            swivelOffset = new FsmFloat { UseVariable = true };
            armLengthMlp = new FsmFloat { UseVariable = true };

            // Default values
            positionWeight = 1f;
            rotationWeight = 1f;
            shoulderRotationWeight = 1f;
            shoulderTwistWeight = 1f;
            armLengthMlp = 1f;
        }

        protected override void UpdateAction()
        {
            var solver = (component as RootMotion.FinalIK.VRIK).solver;
            var arm = side == Side.Left ? solver.leftArm : solver.rightArm;

            arm.target = GetTransform(target);
            arm.bendGoal = GetTransform(bendGoal);
            arm.positionWeight = positionWeight.Value;
            arm.rotationWeight = rotationWeight.Value;
            arm.shoulderRotationWeight = shoulderRotationWeight.Value;
            arm.shoulderTwistWeight = shoulderTwistWeight.Value;
            arm.bendGoalWeight = bendGoalWeight.Value;
            arm.swivelOffset = swivelOffset.Value;
            arm.armLengthMlp = armLengthMlp.Value;
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
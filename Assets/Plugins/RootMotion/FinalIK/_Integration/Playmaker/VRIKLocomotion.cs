using UnityEngine;
using RootMotion.FinalIK;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Final IK")]
    [Tooltip("Manages VRIK Locomotion settings")]
    public class VRIKLocomotion : IKAction
    {
        [ActionSection("Locomotion Settings")]

        [HasFloatSlider(0, 1)]
        [Tooltip("Used for blending in/out of procedural locomotion.")]
        public FsmFloat weight;

        [Tooltip("Tries to maintain this distance between the legs.")]
        public FsmFloat footDistance;

        [Tooltip("Makes a step only if step target position is at least this far from the current footstep or the foot does not reach the current footstep anymore or footstep angle is past the 'Angle Threshold'.")]
        public FsmFloat stepThreshold;

        [Tooltip("Makes a step only if step target position is at least 'Step Threshold' far from the current footstep or the foot does not reach the current footstep anymore or footstep angle is past this value.")]
        public FsmFloat angleThreshold;

        [Tooltip("Multiplies angle of the center of mass - center of pressure vector. Larger value makes the character step sooner if losing balance.")]
        public FsmFloat comAngleMlp;

        [Tooltip("Maximum magnitude of head/hand target velocity used in prediction.")]
        public FsmFloat maxVelocity;

        [Tooltip("The amount of head/hand target velocity prediction.")]
        public FsmFloat velocityFactor;

        [HasFloatSlider(0.9f, 1f)]
        [Tooltip("How much can a leg be extended before it is forced to step to another position? 1 means fully stretched.")]
        public FsmFloat maxLegStretch;

        [Tooltip("The speed of lerping the root of the character towards the horizontal mid-point of the footsteps.")]
        public FsmFloat rootSpeed;

        [Tooltip("The speed of steps.")]
        public FsmFloat stepSpeed;

        [HasFloatSlider(0f, 180f)]
        [Tooltip("Rotates the foot while the leg is not stepping to relax the twist rotation of the leg if ideal rotation is past this angle.")]
        public FsmFloat relaxLegTwistMinAngle;

        [Tooltip("The speed of rotating the foot while the leg is not stepping to relax the twist rotation of the leg.")]
        public FsmFloat relaxLegTwistSpeed;

        [Tooltip("Offset for the approximated center of mass.")]
        public FsmVector3 offset;

        protected override void ResetAction()
        {
            weight = new FsmFloat { UseVariable = true };
            footDistance = new FsmFloat { UseVariable = true };
            stepThreshold = new FsmFloat { UseVariable = true };
            angleThreshold = new FsmFloat { UseVariable = true };
            comAngleMlp = new FsmFloat { UseVariable = true };
            maxVelocity = new FsmFloat { UseVariable = true };
            velocityFactor = new FsmFloat { UseVariable = true };
            maxLegStretch = new FsmFloat { UseVariable = true };
            rootSpeed = new FsmFloat { UseVariable = true };
            stepSpeed = new FsmFloat { UseVariable = true };
            relaxLegTwistMinAngle = new FsmFloat { UseVariable = true };
            relaxLegTwistSpeed = new FsmFloat { UseVariable = true };
            offset = new FsmVector3 { UseVariable = true };
            
            // Default values
            weight = 1f;
            footDistance = 0.3f;
            stepThreshold = 0.4f;
            angleThreshold = 60f;
            comAngleMlp = 1f;
            maxVelocity = 0.4f;
            velocityFactor = 0.4f;
            maxLegStretch = 1f;
            rootSpeed = 20f;
            stepSpeed = 3f;
            relaxLegTwistMinAngle = 20f;
            relaxLegTwistSpeed = 400f;
            offset = Vector3.zero;
        }

        protected override void UpdateAction()
        {
            var solver = (component as RootMotion.FinalIK.VRIK).solver;

            solver.locomotion.weight = weight.Value;
            solver.locomotion.footDistance = footDistance.Value;
            solver.locomotion.stepThreshold = stepThreshold.Value;
            solver.locomotion.angleThreshold = angleThreshold.Value;
            solver.locomotion.comAngleMlp = comAngleMlp.Value;
            solver.locomotion.maxVelocity = maxVelocity.Value;
            solver.locomotion.velocityFactor = velocityFactor.Value;
            solver.locomotion.maxLegStretch = maxLegStretch.Value;
            solver.locomotion.rootSpeed = rootSpeed.Value;
            solver.locomotion.stepSpeed = stepSpeed.Value;
            solver.locomotion.relaxLegTwistMinAngle = relaxLegTwistMinAngle.Value;
            solver.locomotion.relaxLegTwistSpeed = relaxLegTwistSpeed.Value;
            solver.locomotion.offset = offset.Value;
        }

        protected override System.Type GetComponentType()
        {
            return typeof(RootMotion.FinalIK.VRIK);
        }
    }
}
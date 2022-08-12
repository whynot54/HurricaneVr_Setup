using UnityEngine;
using RootMotion.FinalIK;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Final IK")]
    [Tooltip("Manages VRIK spine settings.")]
    public class VRIKSpine : IKAction
    {
        [ActionSection("Spine Settings")]

        [Tooltip("The head target Transform")]
        public FsmGameObject headTarget;

        [Tooltip("The head target Transform")]
        public FsmGameObject pelvisTarget;

        [HasFloatSlider(0, 1)]
        [Tooltip("Head position weight.")]
        public FsmFloat positionWeight;

        [HasFloatSlider(0, 1)]
        [Tooltip("Head rotation weight.")]
        public FsmFloat rotationWeight;

        [HasFloatSlider(0, 1)]
        [Tooltip("Pelvis position weight.")]
        public FsmFloat pelvisPositionWeight;

        [HasFloatSlider(0, 1)]
        [Tooltip("Pelvis rotation weight.")]
        public FsmFloat pelvisRotationWeight;

        [Tooltip("The chest goal Transform")]
        public FsmGameObject chestGoal;

        [HasFloatSlider(0, 1)]
        [Tooltip("Chest goal weight.")]
        public FsmFloat chestGoalWeight;

        [Tooltip("Minimum height of the head from the root of the character.")]
        public FsmFloat minHeadHeight;

        [HasFloatSlider(0, 1)]
        [Tooltip("Determines how much the body will follow the position of the head.")]
        public FsmFloat bodyPosStiffness;

        [HasFloatSlider(0, 1)]
        [Tooltip("Determines how much the body will follow the rotation of the head.")]
        public FsmFloat bodyRotStiffness;

        [HasFloatSlider(0, 1)]
        [Tooltip("Determines how much the chest will rotate to the rotation of the head.")]
        public FsmFloat neckStiffness;

        [HasFloatSlider(0, 1)]
        [Tooltip("The amount of rotation applied to the chest based on hand positions.")]
        public FsmFloat rotateChestByHands;

        [HasFloatSlider(0, 1)]
        [Tooltip("Clamps chest rotation.")]
        public FsmFloat chestClampWeight;

        [HasFloatSlider(0, 1)]
        [Tooltip("Clamps head rotation.")]
        public FsmFloat headClampWeight;

        [Tooltip("Moves the body horizontally along -character.forward axis by that value when the player is crouching.")]
        public FsmFloat moveBodyBackWhenCrouching;

        [HasFloatSlider(0, 1)]
        [Tooltip("How much will the pelvis maintain it's animated position?")]
        public FsmFloat maintainPelvisPosition;

        [HasFloatSlider(0, 180)]
        [Tooltip("Will automatically rotate the root of the character if the head target has turned past this angle.")]
        public FsmFloat maxRootangle;

        [HasFloatSlider(-180, 180)]
        [Tooltip("Angular offset for root heading. Adjust this value to turn the root relative to the HMD around the vertical axis.")]
        public FsmFloat rootHeadingOffset;

        protected override void ResetAction()
        {
            headTarget = new FsmGameObject { UseVariable = true };
            pelvisTarget = new FsmGameObject { UseVariable = true };
            positionWeight = new FsmFloat { UseVariable = true };
            rotationWeight = new FsmFloat { UseVariable = true };
            pelvisPositionWeight = new FsmFloat { UseVariable = true };
            pelvisRotationWeight = new FsmFloat { UseVariable = true };
            chestGoal = new FsmGameObject { UseVariable = true };
            chestGoalWeight = new FsmFloat { UseVariable = true };
            minHeadHeight = new FsmFloat { UseVariable = true };
            bodyPosStiffness = new FsmFloat { UseVariable = true };
            bodyRotStiffness = new FsmFloat { UseVariable = true };
            neckStiffness = new FsmFloat { UseVariable = true };
            rotateChestByHands = new FsmFloat { UseVariable = true };
            chestClampWeight = new FsmFloat { UseVariable = true };
            headClampWeight = new FsmFloat { UseVariable = true };
            moveBodyBackWhenCrouching = new FsmFloat { UseVariable = true };
            maintainPelvisPosition = new FsmFloat { UseVariable = true };
            maxRootangle = new FsmFloat { UseVariable = true };
            rootHeadingOffset = new FsmFloat { UseVariable = true };

            // Default values
            positionWeight = 1f;
            rotationWeight = 1f;
            minHeadHeight = 0.8f;
            bodyPosStiffness = 0.55f;
            bodyRotStiffness = 0.1f;
            neckStiffness = 0.2f;
            rotateChestByHands = 1f;
            chestClampWeight = 0.5f;
            headClampWeight = 0.6f;
            moveBodyBackWhenCrouching = 0.5f;
            maintainPelvisPosition = 0.2f;
            maxRootangle = 25f;
        }

        protected override void UpdateAction()
        {
            var solver = (component as RootMotion.FinalIK.VRIK).solver;

            solver.spine.headTarget = GetTransform(headTarget);
            solver.spine.pelvisTarget = GetTransform(pelvisTarget);
            solver.spine.positionWeight = positionWeight.Value;
            solver.spine.rotationWeight = rotationWeight.Value;
            solver.spine.pelvisPositionWeight = pelvisPositionWeight.Value;
            solver.spine.pelvisRotationWeight = pelvisRotationWeight.Value;
            solver.spine.chestGoal = GetTransform(chestGoal);
            solver.spine.chestGoalWeight = chestGoalWeight.Value;
            solver.spine.minHeadHeight = minHeadHeight.Value;
            solver.spine.bodyPosStiffness = bodyPosStiffness.Value;
            solver.spine.bodyRotStiffness = bodyRotStiffness.Value;
            solver.spine.neckStiffness = neckStiffness.Value;
            solver.spine.rotateChestByHands = rotateChestByHands.Value;
            solver.spine.chestClampWeight = chestClampWeight.Value;
            solver.spine.headClampWeight = headClampWeight.Value;
            solver.spine.moveBodyBackWhenCrouching = moveBodyBackWhenCrouching.Value;
            solver.spine.maintainPelvisPosition = maintainPelvisPosition.Value;
            solver.spine.maxRootAngle = maxRootangle.Value;
            solver.spine.rootHeadingOffset = rootHeadingOffset.Value;
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
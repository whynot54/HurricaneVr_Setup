using UnityEngine;
using RootMotion.FinalIK;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Final IK")]
    [Tooltip("Manages the general settings of a VRIK component.")]
    public class VRIKSettings : IKAction
    {

        [HasFloatSlider(0, 1)]
        [Tooltip("Solver weight for smooth blending.")]
        public FsmFloat weight;

        [Tooltip("LOD 0: Full quality solving. LOD 1: Shoulder solving, stretching plant feet disabled, spine solving quality reduced. LOD 2: Culled, but updating root position and rotation if locomotion is enabled.")]
        public FsmInt LOD;

        [Tooltip("If true, will keep the toes planted even if head target is out of reach.")]
        public FsmBool plantFeet;
       
        protected override void ResetAction()
        {
            weight = new FsmFloat { UseVariable = true };
            LOD = new FsmInt { UseVariable = false };
            plantFeet = new FsmBool { UseVariable = true };

            // Default values
            weight = 1f;
            plantFeet = true;
        }

        protected override void UpdateAction()
        {
            var solver = (component as RootMotion.FinalIK.VRIK).solver;

            // Clamp
            weight.Value = Mathf.Clamp(weight.Value, 0f, 1f);
            LOD.Value = Mathf.Clamp(LOD.Value, 0, 2);

            // Apply
            solver.IKPositionWeight = weight.Value;
            solver.LOD = LOD.Value;
            solver.plantFeet = plantFeet.Value;
        }

        protected override System.Type GetComponentType()
        {
            return typeof(RootMotion.FinalIK.VRIK);
        }
    }
}


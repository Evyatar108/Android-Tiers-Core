﻿using Verse;
using Verse.AI;
using Verse.AI.Group;
using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MOARANDROIDS
{
    internal class ThoughtWorker_TreesDesired_Patch_Patch

    {
        /*
         * Basic androids dont care about nudity stuff
         */
        [HarmonyPatch(typeof(ThoughtWorker_TreesDesired), "ShouldHaveThought")]
        public class CurrentStateInternal_Patch
        {
            [HarmonyPostfix]
            public static void Listener(Pawn p, ref ThoughtState __result)
            {
                if (Utils.ExceptionAndroidListBasic.Contains(p.def.defName))
                {
                    __result = ThoughtState.Inactive;
                }
            }
        }
    }
}
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
    internal class HediffUtility_Patch

    {
        [HarmonyPatch(typeof(HediffUtility), "CountAddedAndImplantedParts")]
        public class CountAddedParts_Patch
        {
            [HarmonyPostfix]
            public static void Listener(HediffSet hs, ref int __result)
            {
                CompSurrogateOwner cso = Utils.getCachedCSO(hs.pawn);
                //Si transhumaniste et a un corp d'androide on simule +10 addedParts
                if (hs.pawn.story != null && hs.pawn.story.traits.HasTrait(TraitDefOf.Transhumanist)
                    && ((hs.pawn.IsAndroidTier()) || (cso != null && cso.skyCloudHost != null)))
                {
                    __result += 20;
                }
            }
        }
    }
}
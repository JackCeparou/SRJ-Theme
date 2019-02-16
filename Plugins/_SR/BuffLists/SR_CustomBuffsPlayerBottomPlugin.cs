
using Turbo.Plugins.Default;
using System.Linq;
using Turbo.Plugins.Jack.Extensions;

namespace Turbo.Plugins._SR.BuffLists
{
	
    public class SR_CustomBuffsPlayerBottomPlugin : BasePlugin, ICustomizer
    {

        public SR_CustomBuffsPlayerBottomPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void Customize()
        {
			

			// ADD buff icons to player's BOTTOM buff list
			// Class Specific Buffs, short duration
			
			
            Hud.RunOnPlugin<PlayerBottomBuffListPlugin>(plugin =>
            {
				
				/* INFO:
				public BuffRule(uint powerSno)
				{
					PowerSno = powerSno;
					MinimumIconCount = 1;
					ShowStacks = false;
					ShowTimeLeft = true;
					UseLegendaryItemTexture = null;
					UsePowersTexture = false;
					UsePowersName = false;
					UsePowersDesc = false;
					AllowInGameMergeRules = true;
					DisableName = false;
					IconSizeMultiplier = 1.0f;
				} */
				
				
				/* BuffRules property:
				IconIndex = null,0,1,2,3,4,5 / MinimumIconCount = 1 / ShowStacks = true; */
				
                plugin.BuffPainter.ShowTimeLeftNumbers = true;
                plugin.BuffPainter.Opacity = 0.80f;
				// plugin.BuffPainter.TimeLeftFont = Hud.Render.CreateFont("tahoma", 5, 255, 255, 255, 255, true, false, 160, 0, 0, 0, true);
				// plugin.BuffPainter.StackFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true);
				plugin.BuffPainter.ShowTooltips = true;
				plugin.BuffPainter.HasIconBorder = true;
				plugin.RuleCalculator.SizeMultiplier = 0.75f;
				
				var IS0 = 1.0f;
				var IS1 = 1.1f;
				var IS2 = 1.2f;
				var IS3 = 1.3f;
				var IS4 = 1.4f;
								
				
				// disable  PlayerBottomBuffListPlugin existing buffs (Default theme) // re-added to PlayerTopBuffList
				var rule = plugin.RuleCalculator.Rules.FirstOrDefault(r => r.PowerSno == 79528); // Taeguk
					plugin.RuleCalculator.Rules.Remove(rule);
				rule = plugin.RuleCalculator.Rules.FirstOrDefault(r => r.PowerSno == 359583); // Focus
					plugin.RuleCalculator.Rules.Remove(rule);
				rule = plugin.RuleCalculator.Rules.FirstOrDefault(r => r.PowerSno == 359583); // Restraint
					plugin.RuleCalculator.Rules.Remove(rule);
				
				
				
				/* --| BARB |-- */
				
					// Ignore Pain
                plugin.RuleCalculator.Rules.Add(new BuffRule(79528) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Sprint
                plugin.RuleCalculator.Rules.Add(new BuffRule(78551) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Wrath Of The Berserker
                plugin.RuleCalculator.Rules.Add(new BuffRule(79607) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Passive: Brawler
                plugin.RuleCalculator.Rules.Add(new BuffRule(205133) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = false, IconSizeMultiplier = IS0, });
				
					// Passive: Berserker Rage
                plugin.RuleCalculator.Rules.Add(new BuffRule(205187) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = false, IconSizeMultiplier = IS0, });
				
					// Passive: Rampage stacks (25)
                plugin.RuleCalculator.Rules.Add(new BuffRule(296572) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });
				
					// Passive: Relentless
                plugin.RuleCalculator.Rules.Add(new BuffRule(205398) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = false, IconSizeMultiplier = IS0, });
				
					// Set: Raekor 6pc stacks (5)
                plugin.RuleCalculator.Rules.Add(new BuffRule(429673) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = false, ShowStacks = true, IconSizeMultiplier = IS0, });
				
					// Set: Band of Might (-65% damage taken for 8s)
					// 447060 P4_ItemPassive_Unique_Ring_049
                plugin.RuleCalculator.Rules.Add(new BuffRule(447060) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = false, IconSizeMultiplier = IS3, });
				
				
				
				
				/* --| CRUS |-- */
				
					// Laws Of Valor
                plugin.RuleCalculator.Rules.Add(new BuffRule(342284) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });
				
					// Iron Skin
                plugin.RuleCalculator.Rules.Add(new BuffRule(291804) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Akarat's Champion
				plugin.RuleCalculator.Rules.Add(new BuffRule(269032) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Falling Sword
				plugin.RuleCalculator.Rules.Add(new BuffRule(239137) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = false, IconSizeMultiplier = IS0, });
					
					// Set: Seeker of the Light 4pc
                plugin.RuleCalculator.Rules.Add(new BuffRule(436426) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = false, IconSizeMultiplier = IS0, });
				
				
				
				
				/* --| MONK |-- */
				
					// Inner Sanctuary // Vigilance Polearm
                plugin.RuleCalculator.Rules.Add(new BuffRule(317076) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Sweeping Wind
				plugin.RuleCalculator.Rules.Add(new BuffRule(96090) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS2, });
				
					// Dashing Strike
                plugin.RuleCalculator.Rules.Add(new BuffRule(312736) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Breath of Heaven
                plugin.RuleCalculator.Rules.Add(new BuffRule(69130) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
					
					// Way Of The Hundred Fists: Blazing Fists rune stacks (3)
                plugin.RuleCalculator.Rules.Add(new BuffRule(97110) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });
				
					// Way Of The Hundred Fists: Assimilation rune
                plugin.RuleCalculator.Rules.Add(new BuffRule(97110) {
                    IconIndex = 4, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });
				
					// Passive: Determination
                plugin.RuleCalculator.Rules.Add(new BuffRule(402633) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, UsePowersTexture = true, UsePowersName = true, IconSizeMultiplier = IS0, });
				
					// Passive: Mythic Rhythm
                plugin.RuleCalculator.Rules.Add(new BuffRule(315271) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, UsePowersDesc = true, IconSizeMultiplier = IS0, });
				
					// Passive: Combination Strike
                plugin.RuleCalculator.Rules.Add(new BuffRule(218415) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });				
				
					// Set: Shenlong Spirit fist weapons debuff
                plugin.RuleCalculator.Rules.Add(new BuffRule(440569) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Item: Spirit Guards bracers
                plugin.RuleCalculator.Rules.Add(new BuffRule(430289) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Item: Binding Of The Lost belt
                plugin.RuleCalculator.Rules.Add(new BuffRule(96694) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });
				
					// Item: Lefebvre's Soliloquy // 449236 - P4_ItemPassive_Unique_Ring_078 // CycloneStrike 223473
                plugin.RuleCalculator.Rules.Add(new BuffRule(223473) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = false, IconSizeMultiplier = IS2, });
				
					// Item: FlyingDragon // 246562 - ItemPassive_Unique_CombatStaff_2H_009
				// var FlyingDragon = Hud.Sno.SnoPowers.FlyingDragon;
                // plugin.RuleCalculator.Rules.Add(new BuffRule(246562) {
                    // IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = false, UseLegendaryItemTexture = FlyingDragon.GetItem(), IconSizeMultiplier = IS2, });
				var flyingDragonPower = Hud.Sno.SnoPowers.FlyingDragon;
                var flyingDragonRule = new BuffRule(flyingDragonPower.Sno) {
					IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = false, UseLegendaryItemTexture = flyingDragonPower.GetItem(), IconSizeMultiplier = IS2, };
                plugin.RuleCalculator.Rules.Add(flyingDragonRule);

					// Item: Istvan's Paired Blades
				// IstvanPairedBlades2(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(359582); }
				// var IstvanPairedBladesPower = Hud.Sno.SnoPowers.IstvanPairedBlades2(); //extension method
                // var IstvanPairedBladesRule = new BuffRule(IstvanPairedBladesPower.Sno) {
					// IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, UseLegendaryItemTexture = IstvanPairedBladesPower.GetItem(), IconSizeMultiplier = IS0, };
                // plugin.RuleCalculator.Rules.Add(IstvanPairedBladesRule);

				
				
				/* --| DH |-- */
				
					// Smoke Screen
                plugin.RuleCalculator.Rules.Add(new BuffRule(130695) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Wolf
                plugin.RuleCalculator.Rules.Add(new BuffRule(365311) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, });
					
					// Sentry
                plugin.RuleCalculator.Rules.Add(new BuffRule(129217) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS2, });
				
					// Passive: Steady Aim
                plugin.RuleCalculator.Rules.Add(new BuffRule(164363) {
                    IconIndex = 1, MinimumIconCount = 1, IconSizeMultiplier = IS0, });
				
					// Passive: Tactical Advantage
                plugin.RuleCalculator.Rules.Add(new BuffRule(218385) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Passive: Hot Pursuit
                plugin.RuleCalculator.Rules.Add(new BuffRule(155725) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Passive: Sharpshooter stacks (x)
                plugin.RuleCalculator.Rules.Add(new BuffRule(155715) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });
				
					// Set: Unhallowed Essence 4pc
                plugin.RuleCalculator.Rules.Add(new BuffRule(423244) {
                    IconIndex = 1, MinimumIconCount = 1, IconSizeMultiplier = IS0, });
				
					// Item: Lord Greenstone's Fan dagger stacks (30)
                plugin.RuleCalculator.Rules.Add(new BuffRule(445274) {
                    IconIndex = null, MinimumIconCount = 15, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
					// Item: Wraps of Clarity bracers
                plugin.RuleCalculator.Rules.Add(new BuffRule(441517) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Item: Chain of Shadows belt
                plugin.RuleCalculator.Rules.Add(new BuffRule(445266) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Item: Elusive ring
                plugin.RuleCalculator.Rules.Add(new BuffRule(446187) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
				
				
				/* --| WD |-- */
								
					// Big Bad Voodoo
                plugin.RuleCalculator.Rules.Add(new BuffRule(117402) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, });
				
					// Soul Harvest stacks (5)
                plugin.RuleCalculator.Rules.Add(new BuffRule(67616) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
					// Passive: Gruesome Feast stacks (5)
                plugin.RuleCalculator.Rules.Add(new BuffRule(208594) {
                    IconIndex = 2, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
				/* not working
					// Passive: Swampland Attunement stacks (25)
                plugin.RuleCalculator.Rules.Add(new BuffRule(340910) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				*/
				
					// Passive: Rush of Essence stacks (10)
                plugin.RuleCalculator.Rules.Add(new BuffRule(208565) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, });
				
					// Set: Helltooth 6pc // 4pc (437710) not working
                plugin.RuleCalculator.Rules.Add(new BuffRule(437711) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, });
				
				/* not working
					// Set: Zunimassa 6pc (429857) not working // 4pc (430680) not working
                plugin.RuleCalculator.Rules.Add(new BuffRule(429857) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, });
				*/
				
					// Set: Arachyr 4pc
                plugin.RuleCalculator.Rules.Add(new BuffRule(439308) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, });
				
				
				
				
				/* --| WIZ |-- */
								
					// Archon main stacks (x)
                plugin.RuleCalculator.Rules.Add(new BuffRule(134872) {
                    IconIndex = 2, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
					// Swami Archon overlap stacks (x)
                plugin.RuleCalculator.Rules.Add(new BuffRule(134872) {
                    IconIndex = 5, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
					// Spectral Blade: Flame Blades rune stacks (30)
                plugin.RuleCalculator.Rules.Add(new BuffRule(71548) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });
				
					// Arcane Orb: Arcane Orbit rune stacks (4)
                plugin.RuleCalculator.Rules.Add(new BuffRule(30668) {
                    IconIndex = 5, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });
				
					// Teleport
                plugin.RuleCalculator.Rules.Add(new BuffRule(168344) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Passive: Unwavering Will
                plugin.RuleCalculator.Rules.Add(new BuffRule(298038) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, UsePowersTexture = true, IconSizeMultiplier = IS1, });
				
					// Passive: Illusionist
                plugin.RuleCalculator.Rules.Add(new BuffRule(208547) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Passive: Galvanizing Ward // setup
                plugin.RuleCalculator.Rules.Add(new BuffRule(208541) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
					
					// Passive: Galvanizing Ward // active
                plugin.RuleCalculator.Rules.Add(new BuffRule(208541) {
                    IconIndex = 2, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
					
					// Passive: Arcane Dynamo stacks  // show @ 5 stacks
                plugin.RuleCalculator.Rules.Add(new BuffRule(208823) {
                    IconIndex = 1, MinimumIconCount = 5, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });
				
					// Set: Chantodo stacks (20)
                plugin.RuleCalculator.Rules.Add(new BuffRule(440235) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
					// Set: Firebird 6pc stacks (20)
                plugin.RuleCalculator.Rules.Add(new BuffRule(359581) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
					// Set: Tal Rasha's 6pc Damage (also applies to 4pc Resist)
                plugin.RuleCalculator.Rules.Add(new BuffRule(429855) {
                    IconIndex = 5, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
				/* not working
					// Set: Tal Rasha's 2pc Meteors // lightning
                plugin.RuleCalculator.Rules.Add(new BuffRule(359555) {
                    IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
					// Set: Tal Rasha's 2pc Meteors // fire
                plugin.RuleCalculator.Rules.Add(new BuffRule(359555) {
                    IconIndex = 2, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });				
				
					// Set: Tal Rasha's 2pc Meteors // arcane
                plugin.RuleCalculator.Rules.Add(new BuffRule(359555) {
                    IconIndex = 3, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
					// Set: Tal Rasha's 2pc Meteors // cold
                plugin.RuleCalculator.Rules.Add(new BuffRule(359555) {
                    IconIndex = 4, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				*/
				
					// Item: Triumvirate stacks (3)
                plugin.RuleCalculator.Rules.Add(new BuffRule(434849) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
					// Item: Twisted Sword stacks (5)
                plugin.RuleCalculator.Rules.Add(new BuffRule(77113) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS1, });
				
				
				
				
				/* --| NECRO |-- */
				
					// Bone Armor stacks (10)
                plugin.RuleCalculator.Rules.Add(new BuffRule(466857) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS2, });
				
					// Mage Stacks (10)
				plugin.RuleCalculator.Rules.Add(new BuffRule(462089) {
					IconIndex = 6, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS4, });

					// Set: Pestilence 4p (x)
				plugin.RuleCalculator.Rules.Add(new BuffRule(472273) {
					IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS4, });
				
				
				// Blood is Power - Necromancer passive skill
				
				
				/*
				~~~~~~~~~~~~~~~~~~~~~~~~~~
				||		CANNOT TRACK  	||
				~~~~~~~~~~~~~~~~~~~~~~~~~~
				
				Cannot track these buffs/effects as they have no icons/actors, only animations:
				
				Sunwuko Set buff (Monk)			425390
				Wall of Man (Shield)			247585
				The Burning Axe of Sankis (Axe)	246113
				GoldWrap (Belt)					318875
				Broken Promises (Ring)			402462
				Oculus (Ring)					402461	??
				Pain Enhancer (Gem)				403600
				HellTooth Set 4pc (WD)			437710
				Aether Walker (Wiz wand)		403782 item / 397788 buff
				
				PS: some are added as Buff Labels instead
				*/
				
				
				
				
            });
        }
    }
}
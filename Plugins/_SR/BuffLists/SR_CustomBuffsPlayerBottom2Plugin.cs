
using Turbo.Plugins.Default;
using System.Linq;
using Turbo.Plugins.Jack.Extensions;

namespace Turbo.Plugins._SR.BuffLists
{
	
    public class SR_CustomBuffsPlayerBottom2Plugin : BasePlugin, IInGameTopPainter
    {
		
        public BuffPainter BuffPainter { get; set; }
        public BuffRuleCalculator RuleCalculator { get; private set; }
        public float PositionOffset { get; set; }
		
		
        public SR_CustomBuffsPlayerBottom2Plugin()
        {
            Enabled = true;
            PositionOffset = 0.08f; //0.04
        }
		
		
        public override void Load(IController hud)
        {
            base.Load(hud);
			
			
			// ADD buff icons to player's bottom buff list (2nd row)
			// Item Buffs
			
			
            BuffPainter = new BuffPainter(Hud, true)
            {
                Opacity = 0.60f,
                ShowTimeLeftNumbers = true,
                ShowTooltips = true,
				HasIconBorder = true,
                TimeLeftFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true),
                StackFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true),
            };
			
            RuleCalculator = new BuffRuleCalculator(Hud);
            RuleCalculator.SizeMultiplier = 0.75f;
			
			
			/* BuffRules property:
			IconIndex = null,0,1,2,3,4,5 / MinimumIconCount = 1 / ShowStacks = true / ShowTimeLeft = true /IconSizeMultiplier = IS1 */
			
			
			var IS0 = 1.0f;
			var IS1 = 1.1f;
			// var IS2 = 1.2f;
			var IS3 = 1.3f;
			var IS4 = 1.4f;
						
			
			/* --| ITEMS |-- */
			
			
				/*
				Convention of Elements Ring cycle per class (4s each), corresponding IconIndex:
				1 Arcane, 2 Cold, 3 Fire, 4 Holy, 5 Lightning, 6 Physical, 7 Poison
				
				BARB (4):	Cold, Fire, Lightning, Physical
				CRUS (4):	Fire, Holy, Lightning, Physical
				MONK (5):	Cold, Fire, Holy, Lightning, Physical
				DH   (4):	Cold, Fire, Lightning, Physical
				WD   (4):	Cold, Fire, Physical, Poison
				WIZ  (4):	Arcane, Cold, Fire, Lightning
				NEC  (3):	Cold, Physical, Poison
				*/
			
				// COE: ALL
			// RuleCalculator.Rules.Add(new BuffRule(430674) {
				// IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, });
			
				// COE: Cold only
			RuleCalculator.Rules.Add(new BuffRule(430674) {
				IconIndex = 2, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, });
			
				// COE: Fire only
			RuleCalculator.Rules.Add(new BuffRule(430674) {
				IconIndex = 3, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS4, });
			
				// COE: Lightning only
			// RuleCalculator.Rules.Add(new BuffRule(430674) {
				// IconIndex = 5, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, });
			

			
				// In-geom sword
			RuleCalculator.Rules.Add(new BuffRule(402458) {
				IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, });
			
				// Harrington Waistguard belt
			RuleCalculator.Rules.Add(new BuffRule(318881) {
				IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, });
			
				// Pride's Fall helmet
			RuleCalculator.Rules.Add(new BuffRule(322977) {
				IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, });
			
				// Aquila Cuirass chest
			RuleCalculator.Rules.Add(new BuffRule(449064) {
				IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
			
				// Focus Restraint Set Bonus 2pc: Focus ring 359583/1, Restraint ring 359583/2 (also 434980 ?)
			RuleCalculator.Rules.Add(new BuffRule(359583) {
				IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, }); // Focus
				
			RuleCalculator.Rules.Add(new BuffRule(359583) {
				IconIndex = 2, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS1, }); // Restraint
			
				// Endless Walk Set Bonus 2pc: The Compass Rose ring & The Traveler's Pledge amulet
				// to show only @ max, change MinimumIconCount to 100 and 50 respectively
			RuleCalculator.Rules.Add(new BuffRule(447541) {
				IconIndex = 2, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, }); // Dmg, max 100
			
			RuleCalculator.Rules.Add(new BuffRule(447541) {
				IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = 0.9f, }); // Def, max 50
			
				// Istvan's Paired Blades (+6% AS, Damage, Armor for 5s; can stack x5)
				// 359582 ItemPassive_Unique_Ring_734_x1
			RuleCalculator.Rules.Add(new BuffRule(359582) {
				IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS3, }); // Def, max 50
			
			
				/*
				bool bOculus = Hud.Game.Me.Powers.BuffIsActive(402461, 2);
				*/
			
			
			
			/* --| GEMS |-- */
			
			
				// Bane Of The Powerful
			RuleCalculator.Rules.Add(new BuffRule(383014) {
				IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
			
				// Gogok Of Swiftness
			RuleCalculator.Rules.Add(new BuffRule(403464) {
				IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });
			
				// Taeguk
			RuleCalculator.Rules.Add(new BuffRule(403471) {
				IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, ShowStacks = true, IconSizeMultiplier = IS0, });


        }
		
		
        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            RuleCalculator.CalculatePaintInfo(Hud.Game.Me);
            if (RuleCalculator.PaintInfoList.Count == 0) return;

            var y = Hud.Window.Size.Height * 0.5f + Hud.Window.Size.Height * PositionOffset;
            BuffPainter.PaintHorizontalCenter(RuleCalculator.PaintInfoList, 0, y, Hud.Window.Size.Width, RuleCalculator.StandardIconSize, RuleCalculator.StandardIconSpacing);
        }

    }

}
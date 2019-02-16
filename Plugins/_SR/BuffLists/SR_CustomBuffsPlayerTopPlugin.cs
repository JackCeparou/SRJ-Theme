
using Turbo.Plugins.Default;

namespace Turbo.Plugins._SR.BuffLists
{

    public class SR_CustomBuffsPlayerTopPlugin : BasePlugin, ICustomizer
    {

        public SR_CustomBuffsPlayerTopPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void Customize()
        {
			
		
			// ADD buff icons to player's TOP buff list
			// class buffs, long duration
			
			
            Hud.RunOnPlugin<PlayerTopBuffListPlugin>(plugin =>
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
                plugin.BuffPainter.Opacity = 0.70f;
				// plugin.BuffPainter.TimeLeftFont = Hud.Render.CreateFont("tahoma", 5, 160, 255, 255, 255, true, false, 160, 0, 0, 0, true);
				// plugin.BuffPainter.StackFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true);
				plugin.BuffPainter.ShowTooltips = false;
				plugin.BuffPainter.HasIconBorder = true;
				plugin.RuleCalculator.SizeMultiplier = 0.75f;
				
				var IS0 = 1.0f;
				// var IS1 = 1.1f;
				// var IS2 = 1.2f;
				// var IS3 = 1.3f;
				// var IS4 = 1.4f;				
				
				
				
				/* --| BARB |-- */
								
					// Battle Rage
                plugin.RuleCalculator.Rules.Add(new BuffRule(79076) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// War Cry
                plugin.RuleCalculator.Rules.Add(new BuffRule(375483) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
				
				
				
				/* --| WIZ |-- */
								
					// Familiar
                plugin.RuleCalculator.Rules.Add(new BuffRule(99120) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Magic Weapon
                plugin.RuleCalculator.Rules.Add(new BuffRule(76108) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Energy Armor // No Rune, Force Armor
                plugin.RuleCalculator.Rules.Add(new BuffRule(86991) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Energy Armor // Prismatic
                plugin.RuleCalculator.Rules.Add(new BuffRule(86991) {
                    IconIndex = 2, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Energy Armor // Absorption
                plugin.RuleCalculator.Rules.Add(new BuffRule(86991) {
                    IconIndex = 3, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Energy Armor // Energy Tap
                plugin.RuleCalculator.Rules.Add(new BuffRule(86991) {
                    IconIndex = 4, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Energy Armor // Pin Point Barrier
                plugin.RuleCalculator.Rules.Add(new BuffRule(86991) {
                    IconIndex = 5, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Ice Armor
                plugin.RuleCalculator.Rules.Add(new BuffRule(73223) {
                    IconIndex = 0, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
					// Storm Armor
                plugin.RuleCalculator.Rules.Add(new BuffRule(74499) {
                    IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = IS0, });
				
				
				
				
            });
        }
    }
}
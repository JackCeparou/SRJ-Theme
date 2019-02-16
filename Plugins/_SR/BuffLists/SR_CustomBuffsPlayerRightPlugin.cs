
using Turbo.Plugins.Default;

namespace Turbo.Plugins._SR.BuffLists
{

    public class SR_CustomBuffsPlayerRightPlugin : BasePlugin, ICustomizer
    {

        public SR_CustomBuffsPlayerRightPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void Customize()
        {
			
			
			// ADD buff icons to player's RIGHT buff list
			// cheat death debuff
			
			
            Hud.RunOnPlugin<PlayerRightBuffListPlugin>(plugin =>
            {	
				
				/* BuffRules property:
				IconIndex = null,0,1,2,3,4,5 / MinimumIconCount = 1 / ShowStacks = true; */
				
                plugin.BuffPainter.ShowTimeLeftNumbers = true;
                plugin.BuffPainter.Opacity = 0.65f;
				// plugin.BuffPainter.TimeLeftFont = Hud.Render.CreateFont("tahoma", 5, 160, 255, 255, 255, true, false, 160, 0, 0, 0, true);
				// plugin.BuffPainter.StackFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true);
				plugin.BuffPainter.ShowTooltips = false;
				plugin.BuffPainter.HasIconBorder = true;
				plugin.RuleCalculator.SizeMultiplier = 0.80f;
				
				
				/* --| CHEAT DEATH |-- */
				plugin.RuleCalculator.Rules.Add(new BuffRule(156484) { IconIndex = 1, MinimumIconCount = 1 }); // Near Death Experience
				plugin.RuleCalculator.Rules.Add(new BuffRule(208474) { IconIndex = 1, MinimumIconCount = 1 }); // Unstable Anomaly
				plugin.RuleCalculator.Rules.Add(new BuffRule(359580) { IconIndex = 1, MinimumIconCount = 1 }); // Firebird's Finery
				plugin.RuleCalculator.Rules.Add(new BuffRule(324770) { IconIndex = 1, MinimumIconCount = 1 }); // Awareness
				plugin.RuleCalculator.Rules.Add(new BuffRule(218501) { IconIndex = 1, MinimumIconCount = 1 }); // Spirit Vessel
				plugin.RuleCalculator.Rules.Add(new BuffRule(309830) { IconIndex = 1, MinimumIconCount = 1 }); // Indestructible
				plugin.RuleCalculator.Rules.Add(new BuffRule(217819) { IconIndex = 1, MinimumIconCount = 1 }); // Nerves of Steel
				
				
            });
        }
    }
}
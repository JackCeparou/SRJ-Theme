
using Turbo.Plugins.Default;

namespace Turbo.Plugins._SR.BuffLists
{

    public class SR_CustomBuffsPlayerLeftPlugin : BasePlugin, ICustomizer
    {

        public SR_CustomBuffsPlayerLeftPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void Customize()
        {
			
			
			// ADD buff icons to player's LEFT buff list
			// shrine buffs
			
			
            Hud.RunOnPlugin<PlayerLeftBuffListPlugin>(plugin =>
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
				
				
				/* --| SHRINES |-- */
				plugin.RuleCalculator.Rules.Add(new BuffRule(260349) { MinimumIconCount = 1 }); // Empowered  | +100% res regen (only DH Hatred), +50% CDR
				plugin.RuleCalculator.Rules.Add(new BuffRule(278269) { MinimumIconCount = 1 }); // Enlightened  | +25% exp on kill
				plugin.RuleCalculator.Rules.Add(new BuffRule(030477) { MinimumIconCount = 1 }); // Enlightened  | +25% exp on kill
				plugin.RuleCalculator.Rules.Add(new BuffRule(260348) { MinimumIconCount = 1 }); // Fleeting  | +25% move speed, +25y pickup radius
				plugin.RuleCalculator.Rules.Add(new BuffRule(278270) { MinimumIconCount = 1 }); // Fortune  | +25% GF & MF
				plugin.RuleCalculator.Rules.Add(new BuffRule(030478) { MinimumIconCount = 1 }); // Fortune  | +25% GF & MF
				plugin.RuleCalculator.Rules.Add(new BuffRule(278271) { MinimumIconCount = 1 }); // Frenzied  | +25% IAS
				plugin.RuleCalculator.Rules.Add(new BuffRule(030479) { MinimumIconCount = 1 }); // Frenzied  | +25% IAS
				plugin.RuleCalculator.Rules.Add(new BuffRule(278268) { MinimumIconCount = 1 }); // Blessed  | -25% dmg taken
				plugin.RuleCalculator.Rules.Add(new BuffRule(030476) { MinimumIconCount = 1 }); // Blessed  | -25% dmg taken
				
				
				/* --| PYONS |-- */
				plugin.RuleCalculator.Rules.Add(new BuffRule(266258) { MinimumIconCount = 1 }); // Channeling  | 100% RCR, 75% CDR
				plugin.RuleCalculator.Rules.Add(new BuffRule(263029) { MinimumIconCount = 1 }); // Conduit  | huge lightning damage
				plugin.RuleCalculator.Rules.Add(new BuffRule(403404) { MinimumIconCount = 1 }); // Conduit (in Rift)
				plugin.RuleCalculator.Rules.Add(new BuffRule(262935) { MinimumIconCount = 1 }); // Power  | +400% damage
				plugin.RuleCalculator.Rules.Add(new BuffRule(266254) { MinimumIconCount = 1 }); // Shield  | damage immunity
				plugin.RuleCalculator.Rules.Add(new BuffRule(266271) { MinimumIconCount = 1 }); // Speed  | max move speed, run thru & kb mobs, smash items
				


            });
        }
    }
}
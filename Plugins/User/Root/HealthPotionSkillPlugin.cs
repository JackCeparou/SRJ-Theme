using SharpDX;
using System;
using Turbo.Plugins.Default;

// glq
namespace Turbo.Plugins.User.Root
{
    public class HealthPotionSkillPlugin : BasePlugin, IInGameTopPainter, ICustomizer
    {
        public TopLabelDecorator Decorator { get; set; }

        public HealthPotionSkillPlugin()
        {
            Enabled = true;
        }
        public override void Load(IController hud)
        {
            base.Load(hud);
            Decorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 14, 255, 255, 255, 255, true, false, 250, 0, 0, 0, true),
            };
        }
        public void Customize()
        {
            Hud.GetPlugin<OriginalHealthPotionSkillPlugin>().Enabled = false; //Disable the default plugin
        }
        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;
            double Cooldown;
            bool IsOnCooldown;
            var ui = Hud.Render.GetPlayerSkillUiElement(ActionKey.Heal);
            var rect = new RectangleF((float)Math.Round(ui.Rectangle.X) + 0.5f, (float)Math.Round(ui.Rectangle.Y) + 0.5f, (float)Math.Round(ui.Rectangle.Width), (float)Math.Round(ui.Rectangle.Height));
            if(Hud.Game.Me.Powers.HealthPotionSkill.IsOnCooldown)
            {
                Cooldown = (Hud.Game.Me.Powers.HealthPotionSkill.CooldownFinishTick - Hud.Game.CurrentGameTick) / 60d;
                IsOnCooldown = Cooldown <= 30 && Cooldown >= 0 ? true : false;
                if (IsOnCooldown)
            {
                Decorator.TextFunc = () => Cooldown < 1 ? Cooldown.ToString("f1") : Cooldown.ToString("f0");
                Decorator.Paint(rect.X, rect.Y, rect.Width, rect.Height, HorizontalAlign.Center);
            }
            }
            
            
            
            
        }

    }

}
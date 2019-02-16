
// added
using System;
using Turbo.Plugins.Default;

// namespace Turbo.Plugins.Default
namespace Turbo.Plugins._SR.Root
{

    public class SR_GameInfoPlugin : BasePlugin, ICustomizer, IInGameTopPainter
	{
		
        public TopLabelDecorator GameClockDecorator { get; set; }
        public TopLabelDecorator ServerIpAddressDecorator { get; set; }
		
		public SR_GameInfoPlugin()
		{
            Enabled = true;
		}
		
        public void Customize()
        {
			// disable DEFAULT
			Hud.TogglePlugin<GameInfoPlugin>(false);
		}
		
        public override void Load(IController hud)
        {
            base.Load(hud);

            GameClockDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 235, 170, false, false, true),
                TextFunc = () => new TimeSpan(Convert.ToInt64(Hud.Game.CurrentGameTick / 60.0f * 10000000)).ToString(@"hh\:mm\:ss"),
            };

            ServerIpAddressDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 5, 255, 170, 150, 120, false, false, true),
                TextFunc = () => Hud.Game.ServerIpAddress,
            };
		}

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;
            
            //var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.BoostWrapper.BoostsDifficultyStackPanel.clock").Rectangle;
            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.minimap_pve_main").Rectangle;

            // GameClockDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 1.15f, uiRect.Width, uiRect.Height * 0.7f, HorizontalAlign.Right);
            GameClockDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.0f, uiRect.Width, uiRect.Height * -0.08f, HorizontalAlign.Left);

            if (Hud.Game.IsInTown)
            {
                // ServerIpAddressDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 1.85f, uiRect.Width, uiRect.Height * 0.7f, HorizontalAlign.Right);
                ServerIpAddressDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.0f, uiRect.Width, uiRect.Height * -0.29f, HorizontalAlign.Right);
            }
        }

    }

}
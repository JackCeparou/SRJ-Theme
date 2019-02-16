
// added
using System.Globalization;
using Turbo.Plugins.Default;

// namespace Turbo.Plugins.Default
namespace Turbo.Plugins._SR.Root
{

    public class SR_NetworkLatencyPlugin : BasePlugin, ICustomizer, IInGameTopPainter
	{

        public TopLabelDecorator AverageDecoratorNormal { get; set; }
        public TopLabelDecorator CurrentDecoratorNormal { get; set; }
        public TopLabelDecorator AverageDecoratorHigh { get; set; }
        public TopLabelDecorator CurrentDecoratorHigh { get; set; }
        public int HighLimit { get; set; }

		public SR_NetworkLatencyPlugin()
		{
            Enabled = true;
            HighLimit = 50;
		}
		
        public void Customize()
        {
			// disable DEFAULT
			Hud.TogglePlugin<NetworkLatencyPlugin>(false);
		}
		
        public override void Load(IController hud)
        {
            base.Load(hud);

            AverageDecoratorNormal = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 200, 150, 200, 150, true, false, 120, 0, 0, 0, true),
                TextFunc = () => Hud.Game.AverageLatency.ToString("F0", CultureInfo.InvariantCulture),
                HintFunc = () => "average latency"
            };

            CurrentDecoratorNormal = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 200, 150, 200, 150, true, false, 120, 0, 0, 0, true),
                TextFunc = () => Hud.Game.CurrentLatency.ToString("F0", CultureInfo.InvariantCulture),
                HintFunc = () => "current latency"
            };

            AverageDecoratorHigh = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 175, 150, true, false, 120, 0, 0, 0, true),
                TextFunc = () => Hud.Game.AverageLatency.ToString("F0", CultureInfo.InvariantCulture),
                HintFunc = () => "average latency"
            };

            CurrentDecoratorHigh = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 175, 150, true, false, 120, 0, 0, 0, true),
                TextFunc = () => Hud.Game.CurrentLatency.ToString("F0", CultureInfo.InvariantCulture),
                HintFunc = () => "current latency"
            };
		}

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.latency_meter").Rectangle;

            var avg = Hud.Game.AverageLatency;
            var cur = Hud.Game.CurrentLatency;

            // (avg >= HighLimit ? AverageDecoratorHigh : AverageDecoratorNormal).Paint(uiRect.Left + uiRect.Width * 1.6f, uiRect.Top + uiRect.Height * 0.67f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Left);
            (avg >= HighLimit ? AverageDecoratorHigh : AverageDecoratorNormal).Paint(uiRect.Left + uiRect.Width * 1.6f, uiRect.Top + uiRect.Height * 0.54f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Left);
            // (cur >= HighLimit ? CurrentDecoratorHigh : CurrentDecoratorNormal).Paint(uiRect.Left + uiRect.Width * 1.6f, uiRect.Top + uiRect.Height * 0.87f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Left);
            (cur >= HighLimit ? CurrentDecoratorHigh : CurrentDecoratorNormal).Paint(uiRect.Left + uiRect.Width * 1.6f, uiRect.Top + uiRect.Height * 0.74f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Left);
        }

    }

}
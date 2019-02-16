using Turbo.Plugins.Default;

// glq SeaDragon
namespace Turbo.Plugins.User.Root
{
    public class GRProgressionToTime : BasePlugin, IInGameTopPainter
    {
        public IFont BonusTimeFont { get; set; }
        public IFont MalusTimeFont { get; set; }
 
        private IFont currentFont;
 
        public GRProgressionToTime()
        {
            Enabled = true;
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
            MalusTimeFont = Hud.Render.CreateFont("tahoma", 7, 255, 250, 100, 100, true, false, 160, 0, 0, 0, true);
            BonusTimeFont = Hud.Render.CreateFont("tahoma", 7, 255, 128, 255, 0, true, false, 160, 0, 0, 0, true);
        }
 
        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Game.SpecialArea != SpecialArea.GreaterRift) return;
            if (clipState != ClipState.BeforeClip) return;
 
            var ui = Hud.Render.GreaterRiftBarUiElement;
            if (!ui.Visible) return;
 
            var secondsLeft = (Hud.Game.CurrentTimedEventEndTick - (double)Hud.Game.CurrentGameTick) / 60.0d;
            var percent = Hud.Game.RiftPercentage;
 
            if (!(secondsLeft > 0)) return;
 
            string text;
            var _x = 9000000000 / ui.Rectangle.Width;
            var currentX = ui.Rectangle.Left + ui.Rectangle.Width / 100.0f * percent;
            var timeX = ui.Rectangle.Right - (float)(ui.Rectangle.Width / 900.0f * secondsLeft);
            var _time = (currentX - timeX) * _x;
            if (_time <= 0)
            {
                text = "- " + ValueToString((long)_time, ValueFormat.LongTime);
                currentFont = MalusTimeFont;
            }
            else
            {
                text = "+ " + ValueToString((long)_time, ValueFormat.LongTime);
                currentFont = BonusTimeFont;
            }
 
            var textLayout = currentFont.GetTextLayout(text);
            var x = (float)currentX - textLayout.Metrics.Width / 2;
            var y = ui.Rectangle.Top - ui.Rectangle.Height * 0.1f - textLayout.Metrics.Height;
            currentFont.DrawText(textLayout, x, y);
        }
    }
}
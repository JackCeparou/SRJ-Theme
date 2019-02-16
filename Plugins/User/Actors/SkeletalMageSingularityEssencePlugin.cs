using System.Globalization;
using Turbo.Plugins.Default;
using System.Linq;

//BM
namespace Turbo.Plugins.User.Actors
{
    public class SkeletalMageSingularityEssencePlugin : BasePlugin, IInGameTopPainter
    {

        public TopLabelWithTitleDecorator EssenceDecorator { get; set; }
        public IBrush FullBackgroundBrush { get; set; }
		public IBrush ReapersWrapsBackgroundBrush { get; set; }
        public IBrush NotFullBackgroundBrush { get; set; }
		public bool ShowInTown { get; set; }
		public float ReapersWrapsResourceRestore { get; set; }
		private float w  { get; set; }
		private float h  { get; set; }
		public float XPos { get; set; }
		public float YPos { get; set; }
        public SkeletalMageSingularityEssencePlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            FullBackgroundBrush = Hud.Render.CreateBrush(100, 0, 255, 0, 0);
			ReapersWrapsBackgroundBrush = Hud.Render.CreateBrush(100, 255, 165, 0, 0);
            NotFullBackgroundBrush = Hud.Render.CreateBrush(100, 255, 0, 0, 0);
			
			ShowInTown = true;
			ReapersWrapsResourceRestore = 30;
			w = Hud.Window.Size.Width * 0.03f;
            h = Hud.Window.Size.Height * 0.02f;
			XPos = Hud.Window.Size.Width * 0.5f - w/2;
			YPos = Hud.Window.Size.Height * 0.5f + Hud.Window.Size.Height * 0.00001f;
			
            EssenceDecorator = new TopLabelWithTitleDecorator(Hud)
            {
                BackgroundBrush = FullBackgroundBrush,
                BorderBrush = Hud.Render.CreateBrush(150, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 8, 150, 0, 0, 0, true, false, false),
            };
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
			if (!Hud.Game.Me.Powers.UsedSkills.Any(s => s.SnoPower.Sno == 462089 && s.Rune == 1)) return;
			if (Hud.Game.IsInTown && ShowInTown == false) return;

            if (clipState == ClipState.BeforeClip)
            {

                if(Hud.Game.Me.Stats.ResourceCurEssence == Hud.Game.Me.Stats.ResourceMaxEssence)
                {
                    EssenceDecorator.BackgroundBrush = FullBackgroundBrush;
                    EssenceDecorator.Paint(XPos, YPos, w, h, Hud.Game.Me.Stats.ResourcePctEssence.ToString("F0", CultureInfo.InvariantCulture) + "%");
                }
                else if(Hud.Game.Me.Stats.ResourceCurEssence < (1 - ((ReapersWrapsResourceRestore + 1) / 100)) * Hud.Game.Me.Stats.ResourceMaxEssence)
                {
                    EssenceDecorator.BackgroundBrush = NotFullBackgroundBrush;
                    EssenceDecorator.Paint(XPos, YPos, w, h, Hud.Game.Me.Stats.ResourcePctEssence.ToString("F0", CultureInfo.InvariantCulture) + "%");
                }
                else
				{
					EssenceDecorator.BackgroundBrush = ReapersWrapsBackgroundBrush;
                    EssenceDecorator.Paint(XPos, YPos, w, h, Hud.Game.Me.Stats.ResourcePctEssence.ToString("F0", CultureInfo.InvariantCulture) + "%");
				}

            }
        }

    }

}
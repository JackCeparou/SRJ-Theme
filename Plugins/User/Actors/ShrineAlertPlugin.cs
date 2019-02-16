using System.Linq;
using System.Collections.Generic;
using Turbo.Plugins.Default;

//Darkblader24
namespace Turbo.Plugins.User.Actors
{
    public class ShrineAlertPlugin : BasePlugin, IInGameWorldPainter
    {
        public bool UseCustomNames { get; set; }
        public Dictionary<ShrineType, string> ShrineCustomNames { get; set; }

        public ShrineAlertPlugin()
        {
            Enabled = true;
            UseCustomNames = false;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            ShrineCustomNames = new Dictionary<ShrineType, string>();
        }

        public void PaintWorld(WorldLayer layer)
        {
            var shrines = Hud.Game.Shrines.Where(x => x.DisplayOnOverlay);
            foreach (var actor in shrines)
            {
                if ((actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(5000))
                {
                    string shrineName;
                    if (!UseCustomNames || !ShrineCustomNames.TryGetValue(actor.Type, out shrineName) || ShrineCustomNames[actor.Type] == null)
                    {
                        shrineName = actor.SnoActor.NameLocalized;
                    }
                    Hud.Sound.Speak(shrineName);
                    actor.LastSpeak = Hud.Time.CreateAndStartWatch();
                }
            }
        }
    }
}

// added
using Turbo.Plugins.Default;

// namespace Turbo.Plugins.Default
namespace Turbo.Plugins._SR.Monsters
{

    public class SR_MonstersPlugin : BasePlugin, ICustomizer
    {

        public SR_MonstersPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }
		
        public void Customize()
        {
						
			// DISABLE arcane affix label
            /* Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Arcane); */
			
            // OVERRIDE an elite affix's text
            /* Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Desecrator, "DES"); */
			
			// DISABLE Dangerous Affix, clear all defined affixes
			/* Hud.RunOnPlugin<DangerousAffixMonsterPlugin>(plugin => { plugin.Affixes.Clear(); }); */
			
			// ---------------------------------------------
			
			// customize names of Dangerous Monsters
			
			/* Hud.RunOnPlugin<DangerousMonsterPlugin>(plugin =>
			{
                foreach (var name in new string[] { "Wood Wraith", "Highland Walker", "The Old Man", "Fallen Lunatic", "Deranged Fallen", "Fallen Maniac", "Frenzied Lunatic", "Herald of Pestilence", "Terror Demon", "Demented Fallen", "Savage Beast", "Tusked Bogan", "Punisher", "Anarch", "Corrupted Angel", "Winged Assassin", "Exarch" })
                {
                    plugin.RemoveName(name);
                }});
			*/
			
			// ---------------------------------------------
			
			// elite affix deco Plagued and Ghom skills
			
			Hud.RunOnPlugin<EliteMonsterSkillPlugin>(plugin =>
			{
				// (128, 160, 255, 160, 3, SharpDX.Direct2D1.DashStyle.Dash)
				plugin.PlaguedDecorator.GetDecorators<GroundCircleDecorator>().ForEach(d => d.Brush = Hud.Render.CreateBrush(30, 160, 255, 160, 2, SharpDX.Direct2D1.DashStyle.Dash));
				// (128, 160, 255, 160, 3, SharpDX.Direct2D1.DashStyle.Dash)
				plugin.GhomDecorator.GetDecorators<GroundCircleDecorator>().ForEach(d => d.Brush = Hud.Render.CreateBrush(30, 160, 255, 160, 2, SharpDX.Direct2D1.DashStyle.Dash));
			});
			
			// ---------------------------------------------
			
			// change FastMummy explosion radius to 4
			
			Hud.RunOnPlugin<ExplosiveMonsterPlugin>(plugin =>
            {
                plugin.FastMummyDecorator = new WorldDecoratorCollection(
                    new GroundCircleDecorator(Hud)
                    {
                        Brush = Hud.Render.CreateBrush(128, 255, 50, 50, 3, SharpDX.Direct2D1.DashStyle.Dash),
                        Radius = 4,
                    }
				);
            });
			
			// ---------------------------------------------
			
			// trash deco
			
			Hud.RunOnPlugin<StandardMonsterPlugin>(plugin =>
            {
				
				// enable StandardMonsterPlugin (DEFAULT)
				plugin.Enabled = true;
				
				plugin.TrashDecorator = new WorldDecoratorCollection(
					new MapShapeDecorator(Hud)
					{
						Brush = Hud.Render.CreateBrush(180, 240, 240, 240, 0),
						ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
						ShapePainter = new CircleShapePainter(Hud),
						Radius = 2,
					}
				);
            });
			
			// ---------------------------------------------
						
			// Monster Rift Progression Coloring Plugin
			
			var shadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1);
			
			Hud.RunOnPlugin<MonsterRiftProgressionColoringPlugin>(plugin =>
            {
				
				// enable MonsterRiftProgressionColoringPlugin (DEFAULT)
				plugin.Enabled = true;
				
				plugin.Decorator3 = new WorldDecoratorCollection(
					new MapShapeDecorator(Hud)
					{
						// Brush = Hud.Render.CreateBrush(180, 0, 125, 0, 0),
						Brush = Hud.Render.CreateBrush(180, 0, 160, 0, 0),
						ShadowBrush = shadowBrush,
						ShapePainter = new CircleShapePainter(Hud),
						Radius = 5,
					});
				
				plugin.Decorator4 = new WorldDecoratorCollection(
					new MapShapeDecorator(Hud)
					{
						// Brush = Hud.Render.CreateBrush(180, 0, 200, 0, 0),
						Brush = Hud.Render.CreateBrush(180, 0, 200, 0, 0),
						ShadowBrush = shadowBrush,
						ShapePainter = new CircleShapePainter(Hud),
						Radius = 6,
					},
					new MapShapeDecorator(Hud)
					{
						// Brush = Hud.Render.CreateBrush(180, 0, 55, 0, 2),
						Brush = Hud.Render.CreateBrush(250, 0, 15, 0, 2f),
						ShadowBrush = shadowBrush,
						ShapePainter = new CircleShapePainter(Hud),
						Radius = 6.0f,
					});
				
				plugin.Decorator5 = new WorldDecoratorCollection(
					new MapShapeDecorator(Hud)
					{
						// Brush = Hud.Render.CreateBrush(180, 0, 125, 0, 0),
						Brush = Hud.Render.CreateBrush(200, 0, 200, 0, 0),
						ShadowBrush = shadowBrush,
						ShapePainter = new CircleShapePainter(Hud),
						Radius = 7.5f,
					},
					new MapShapeDecorator(Hud)
					{
						// Brush = Hud.Render.CreateBrush(180, 0, 55, 0, 2),
						Brush = Hud.Render.CreateBrush(250, 0, 15, 0, 2f),
						ShadowBrush = shadowBrush,
						ShapePainter = new CircleShapePainter(Hud),
						Radius = 7.5f,
					});
            });
			
			// ---------------------------------------------
			
			// elite deco
			
			Hud.RunOnPlugin<StandardMonsterPlugin>(plugin =>
			{
				plugin.EliteChampionDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.Brush = Hud.Render.CreateBrush(200, 64, 128, 255, 0)); //180
				plugin.EliteChampionDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.Radius = 8f); //10
				
				plugin.EliteLeaderDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.Brush = Hud.Render.CreateBrush(200, 255, 148, 20, 0)); //180
				plugin.EliteLeaderDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.Radius = 8f); //10
				
				plugin.EliteMinionDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.Brush = Hud.Render.CreateBrush(200, 192, 92, 20, 0)); //180
				plugin.EliteMinionDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.Radius = 6f); //8
				
				plugin.EliteUniqueDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.Brush = Hud.Render.CreateBrush(200, 255, 140, 255, 0)); //180
				plugin.EliteUniqueDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.Radius = 8f); //10
			});
			
			// elite deco (alternate version)
			
			/* Hud.RunOnPlugin<StandardMonsterPlugin>(plugin =>
				{
					foreach (var subDeco in plugin.EliteChampionDecorator.GetDecorators<MapShapeDecorator>())
						{ subDeco.Radius = 50f; }
						
					foreach (var subDeco in plugin.EliteMinionDecorator.GetDecorators<MapShapeDecorator>())
						{ subDeco.Radius = 5f; }
						
					foreach (var subDeco in plugin.EliteLeaderDecorator.GetDecorators<MapShapeDecorator>())
						{ subDeco.Radius = 20f; }
						
					foreach (var subDeco in plugin.EliteUniqueDecorator.GetDecorators<MapShapeDecorator>())
						{ subDeco.Radius = 20f; }
				});
			*/
			
			// ---------------------------------------------
			
        }
    }
}
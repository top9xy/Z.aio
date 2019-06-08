using System.Linq;
using EnsoulSharp;


using Extensions = Z.aio.Common.Extensions;
using Color = System.Drawing.Color;
using Menu = EnsoulSharp.SDK.MenuUI.Menu;
using Spell = EnsoulSharp.SDK.Spell;
using Champion = Z.aio.Common.Champion;
using System.Windows.Forms;
using EnsoulSharp.SDK.MenuUI.Values;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.Prediction;
using EnsoulSharp.SDK.Utility;

namespace Z.aio.Champions
{
    class Malzahar : Champion
    {

        internal Malzahar()
        {
            this.SetSpells();
            this.SetMenu();
            this.SetEvents();
        }

        internal override void OnCastSpell(Spellbook sender, SpellbookCastSpellEventArgs e)
        {
            if (sender.Owner.IsMe)
            {
                if ((e.Slot == SpellSlot.Q || e.Slot == SpellSlot.W || e.Slot == SpellSlot.E ||
                     e.Slot == SpellSlot.Item1 || e.Slot == SpellSlot.Item2 || e.Slot == SpellSlot.Item3 ||
                     e.Slot == SpellSlot.Item4 || e.Slot == SpellSlot.Item5 || e.Slot == SpellSlot.Item6) &&
                    Player.HasBuff("malzaharrsound"))

                {
                    e.Process = false;

                }
            }
        }

        protected override void Combo()
        {
            if (Player.HasBuff("malzaharrsound"))
            {
                return;
            }

            bool useQ = RootMenu["combo"]["useq"];
            bool useW = RootMenu["combo"]["usew"];
            bool useE = RootMenu["combo"]["usee"];

            switch (RootMenu["combo"]["combomode"].GetValue<MenuList>().Index)
            {
                case 0:
                    if (useQ)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                var pred = Q.GetPrediction(target);
                                if (pred.Hitchance >= HitChance.High)
                                {
                                    Q.Cast(pred.CastPosition, true);
                                }
                            }
                        }
                    }
                    if (useW)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                W.Cast(target.Position);
                            }
                        }
                    }
                    if (useE)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(E.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(E.Range))
                            {
                                E.CastOnUnit(target);
                            }
                        }
                    }
                    if (RootMenu["combo"]["user"])
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(R.Range);

                        if (target.IsValidTarget() && !W.IsReady() && !Q.IsReady())
                        {

                            if (target != null && target.IsValidTarget(R.Range))
                            {
                                switch (RootMenu["combo"]["rmode"].GetValue<MenuList>().Index)
                                {
                                    case 0:
                                        if (target.Health < Player.GetSpellDamage(target, SpellSlot.Q) +
                                            Player.GetSpellDamage(target, SpellSlot.W) +
                                            Player.GetSpellDamage(target, SpellSlot.E) +
                                            Player.GetSpellDamage(target, SpellSlot.R) +
                                            Player.GetSpellDamage(target, SpellSlot.R,
                                                DamageStage.DamagePerSecond))
                                        {
                                            R.Cast(target);
                                        }
                                        break;
                                    case 1:
                                        if (target.HealthPercent  < RootMenu["combo"]["health"].GetValue<MenuSlider>().Value)
                                        {
                                            R.Cast(target);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    break;
                case 1:
                    if (useQ)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                var pred = Q.GetPrediction(target);
                                if (pred.Hitchance >= HitChance.High)
                                {
                                    Q.Cast(pred.CastPosition, true);
                                }
                            }
                        }
                    }
                    if (useE)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(E.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(E.Range))
                            {
                                E.CastOnUnit(target);
                            }
                        }
                    }
                    if (useW)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                W.Cast(target.Position);
                            }
                        }
                    }
                    if (RootMenu["combo"]["user"])
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(R.Range);

                        if (target.IsValidTarget() && !W.IsReady() && !Q.IsReady())
                        {

                            if (target != null && target.IsValidTarget(R.Range))
                            {
                                switch (RootMenu["combo"]["rmode"].GetValue<MenuList>().Index)
                                {
                                    case 0:
                                        if (target.Health < Player.GetSpellDamage(target, SpellSlot.Q) +
                                            Player.GetSpellDamage(target, SpellSlot.W) +
                                            Player.GetSpellDamage(target, SpellSlot.E) +
                                            Player.GetSpellDamage(target, SpellSlot.R) +
                                            Player.GetSpellDamage(target, SpellSlot.R,
                                                DamageStage.DamagePerSecond))
                                        {
                                            R.Cast(target);
                                        }
                                        break;
                                    case 1:
                                        if (target.HealthPercent < RootMenu["combo"]["health"].GetValue<MenuSlider>().Value)
                                        {
                                            R.Cast(target);
                                        }
                                        break;
                                }
                            }
                        }
                    }

                    break;
                case 2:
                    if (RootMenu["combo"]["user"])
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(R.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(R.Range))
                            {
                                switch (RootMenu["combo"]["rmode"].GetValue<MenuList>().Index)
                                {
                                    case 0:
                                        if (target.Health < Player.GetSpellDamage(target, SpellSlot.Q) +
                                            Player.GetSpellDamage(target, SpellSlot.W) +
                                            Player.GetSpellDamage(target, SpellSlot.E) +
                                            Player.GetSpellDamage(target, SpellSlot.R) +
                                            Player.GetSpellDamage(target, SpellSlot.R,
                                                DamageStage.DamagePerSecond))
                                        {
                                            if (R.Cast(target))
                                            {
                                                hewwo = 300 + Variables.TickCount;
                                            }
                                        }
                                        break;
                                    case 1:
                                        if (target.HealthPercent < RootMenu["combo"]["health"].GetValue<MenuSlider>().Value)
                                        {
                                            if (R.Cast(target))
                                            {
                                                hewwo = 300 + Variables.TickCount;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    if (hewwo < Variables.TickCount)
                    {
                        if (useW)
                        {
                            var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                            if (target.IsValidTarget())
                            {

                                if (target != null && target.IsValidTarget(Q.Range))
                                {
                                    W.Cast(target.Position);
                                }
                            }
                        }
                        if (useQ)
                        {
                            var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                            if (target.IsValidTarget())
                            {

                                if (target != null && target.IsValidTarget(Q.Range))
                                {
                                    var pred = Q.GetPrediction(target);
                                    if (pred.Hitchance >= HitChance.High)
                                    {
                                        Q.Cast(pred.CastPosition, true);
                                    }
                                }
                            }
                        }
                        if (useE)
                        {
                            var target = Extensions.GetBestEnemyHeroTargetInRange(E.Range);

                            if (target.IsValidTarget())
                            {

                                if (target != null && target.IsValidTarget(E.Range))
                                {
                                    E.CastOnUnit(target);
                                }
                            }
                        }

                    }
                    break;
                case 3:
                    if (useE)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(E.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(E.Range))
                            {
                                E.CastOnUnit(target);
                            }
                        }
                    }
                    if (useW)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                W.Cast(target.Position);
                            }
                        }
                    }
                    if (useQ)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                var pred = Q.GetPrediction(target);
                                if (pred.Hitchance >= HitChance.High)
                                {
                                    Q.Cast(pred.CastPosition, true);
                                }
                            }
                        }
                    }
                    if (RootMenu["combo"]["user"])
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(R.Range);

                        if(target.IsValidTarget() && !W.IsReady() && !Q.IsReady())
                        {


                            if (target != null && target.IsValidTarget(R.Range))
                            {
                                switch (RootMenu["combo"]["rmode"].GetValue<MenuList>().Index)
                                {
                                    case 0:
                                        if (target.Health < Player.GetSpellDamage(target, SpellSlot.Q) +
                                            Player.GetSpellDamage(target, SpellSlot.W) +
                                            Player.GetSpellDamage(target, SpellSlot.E) +
                                            Player.GetSpellDamage(target, SpellSlot.R) +
                                            Player.GetSpellDamage(target, SpellSlot.R,
                                                DamageStage.DamagePerSecond))
                                        {
                                            R.Cast(target);
                                        }
                                        break;
                                    case 1:
                                        if (target.HealthPercent < RootMenu["combo"]["health"].GetValue<MenuSlider>().Value)
                                        {
                                            R.Cast(target);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    break;
            }
        }


        protected override void SemiR()
        {
            if (RootMenu["flashr"].GetValue<MenuKeyBind>().Active)
            {
                if (!Player.HasBuff("malzaharrsound"))
                {
                    var target = Extensions.GetBestEnemyHeroTargetInRange(R.Range + 410);
                    var Flash = ObjectManager.Player.GetSpellSlot("SummonerFlash");
                    if (R.IsReady())
                    {
                        if (Flash != SpellSlot.Unknown && ObjectManager.Player.Spellbook.GetSpell(Flash).IsReady)
                        {
                            Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPosCenter);
                            if (target.IsValidTarget())
                            {
                                if (target.Distance(Player) > R.Range)
                                {
                                    if (R.Cast(target))
                                    {
                                        ObjectManager.Player.Spellbook.CastSpell(Flash,(target.Position));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (Player.HasBuff("malzaharrsound"))
            {
                Orbwalker.MovementState= false;
                Orbwalker.AttackState = false;
            }
            if (!Player.HasBuff("malzaharrsound"))
            {
                Orbwalker.MovementState = true;
                Orbwalker.AttackState = true;
            }
        }


        protected override void Farming()
        {

            if (RootMenu["farming"]["lane"]["mana"].GetValue<MenuSlider>().Value <= Player.ManaPercent)
            {
                foreach (var minion in Z.aio.Common.Extensions.GetEnemyLaneMinionsTargetsInRange(Q.Range))
                {
                    if (!minion.IsValidTarget() && minion != null)
                    {
                        return;
                    }
                    if (RootMenu["farming"]["lane"]["usee"])
                    {
                        foreach (var lowest in Extensions.GetEnemyLaneMinionsTargetsInRange(E.Range)
                            .OrderBy(x => x.Health))
                        {
                            if (lowest != null)
                            {

                                if (lowest.IsValidTarget(E.Range))
                                {
                                    E.CastOnUnit(lowest);
                                }
                            }
                        }
                    }
                    if (RootMenu["farming"]["lane"]["useq"])
                    {
                        if (minion.IsValidTarget(Q.Range) && minion != null)
                        {
                            if (GameObjects.EnemyMinions.Count(h => h.IsValidTarget(150, false, 
                                    minion.Position)) >=
                                RootMenu["farming"]["lane"]["hite"].GetValue<MenuSlider>().Value)
                            {
                                Q.Cast(minion);
                            }
                        }
                    }
                }
            }
            if (RootMenu["farming"]["jungle"]["mana"].GetValue<MenuSlider>().Value <= Player.ManaPercent)
            {
                foreach (var jungleTarget in GameObjects.Jungle.Where(m => m.IsValidTarget(Q.Range)).ToList())
                {
                    if (!jungleTarget.IsValidTarget() || jungleTarget.Name.Contains("Plant"))
                    {
                        return;
                    }
                    bool useQ = RootMenu["farming"]["jungle"]["useq"];
                    bool useE = RootMenu["farming"]["jungle"]["usee"];
                    bool useW = RootMenu["farming"]["jungle"]["usew"];
                    float manapercent = RootMenu["farming"]["jungle"]["mana"].GetValue<MenuSlider>().Value;
                    
                        if (useQ)
                        {
                            if (jungleTarget != null && jungleTarget.IsValidTarget(Q.Range))
                            {
                                Q.Cast(jungleTarget);
                            }
                        }
                    if (useW)
                    {
                        if (jungleTarget != null && jungleTarget.IsValidTarget(Q.Range))
                        {
                            W.Cast(jungleTarget.Position);
                        }
                    }
                    if (useE)
                    {
                        if (jungleTarget != null && jungleTarget.IsValidTarget(E.Range))
                        {
                            E.CastOnUnit(jungleTarget);
                        }
                    }




                }
            }
        }

        private int hewwo;

        protected override void Drawings()
        {

            if (RootMenu["drawings"]["drawq"])
            {
                Render.Circle.DrawCircle(Player.Position, Q.Range, Color.Crimson);
            }
            if (RootMenu["drawings"]["drawr"])
            {
                Render.Circle.DrawCircle(Player.Position, R.Range, Color.Wheat);
            }
            if (RootMenu["drawings"]["drawe"])
            {
                Render.Circle.DrawCircle(Player.Position, E.Range, Color.Wheat);
            }
            if (RootMenu["drawings"]["drawr"])
            {
                Render.Circle.DrawCircle(Player.Position, R.Range + 410, Color.Wheat);
            }
         

        }

        protected override void Killsteal()
        {

        }

        protected override void Harass()
        {
            bool useQ = RootMenu["harass"]["useq"];
            bool useW = RootMenu["harass"]["usew"];
            bool useE = RootMenu["harass"]["usee"];

            switch (RootMenu["harass"]["harassmode"].GetValue<MenuList>().Index)
            {
                case 0:
                    if (useQ)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                var pred = Q.GetPrediction(target);
                                if (pred.Hitchance >= HitChance.High)
                                {
                                    Q.Cast(pred.CastPosition, true);
                                }
                            }
                        }
                    }
                    if (useW)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                W.Cast(target.Position);
                            }
                        }
                    }
                    if (useE)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(E.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(E.Range))
                            {
                                E.CastOnUnit(target);
                            }
                        }
                    }
                    break;
                case 1:
                    if (useQ)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                var pred = Q.GetPrediction(target);
                                if (pred.Hitchance >= HitChance.High)
                                {
                                    Q.Cast(pred.CastPosition, true);
                                }
                            }
                        }
                    }
                    if (useE)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(E.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(E.Range))
                            {
                                E.CastOnUnit(target);
                            }
                        }
                    }
                    if (useW)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                W.Cast(target.Position);
                            }
                        }
                    }
     
                    break;
                case 2:
                    if (useW)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                W.Cast(target.Position);
                            }
                        }
                    }
                    if (useQ)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                var pred = Q.GetPrediction(target);
                                if (pred.Hitchance >= HitChance.High)
                                {
                                    Q.Cast(pred.CastPosition, true);
                                }
                            }
                        }
                    }
                    if (useE)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(E.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(E.Range))
                            {
                                E.CastOnUnit(target);
                            }
                        }
                    }


                    break;
                case 3:
                    if (useE)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(E.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(E.Range))
                            {
                                E.CastOnUnit(target);
                            }
                        }
                    }
                    if (useW)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                W.Cast(target.Position);
                            }
                        }
                    }
                    if (useQ)
                    {
                        var target = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);

                        if (target.IsValidTarget())
                        {

                            if (target != null && target.IsValidTarget(Q.Range))
                            {
                                var pred = Q.GetPrediction(target);
                                if (pred.Hitchance >= HitChance.High)
                                {
                                    Q.Cast(pred.CastPosition, true);
                                }
                            }
                        }
                    }

                    break;
            }
        }
    
        protected override void SetMenu()
        {
            RootMenu = new Menu("root", "Z字号马尔扎哈", true);


            ComboMenu = new Menu("combo", "连招");
            {
                ComboMenu.Add(new MenuList<string>("combomode", "连招模式", new[] { "Q > W > E > R", "Q > E > W > R", "R > W > Q > E", "E > W > Q > R"}));
                ComboMenu.Add(new MenuBool("useq", "使用 Q"));
                ComboMenu.Add(new MenuBool("usew", "使用 W"));
                ComboMenu.Add(new MenuBool("usee", "使用 E"));
                ComboMenu.Add(new MenuBool("user", "使用 R"));
                ComboMenu.Add(new MenuList<string>("rmode", "R 模式", new[] { "可杀", "低血量" }));
                ComboMenu.Add(new MenuSlider("health", "敌人血量%（低血量模式）", 50));
                
            }
            RootMenu.Add(ComboMenu);
            HarassMenu = new Menu("harass", "骚扰");
            {
                HarassMenu.Add(new MenuList<string>("harassmode", "骚扰模式", new[] { "Q > W > E", "Q > E > W", "W > Q > E", "E > W > Q" }));
                HarassMenu.Add(new MenuBool("useq", "使用 Q"));
                HarassMenu.Add(new MenuBool("usew", "使用 W"));
                HarassMenu.Add(new MenuBool("usee", "使用 E"));
 
            }
            RootMenu.Add(HarassMenu);

            FarmMenu = new Menu("farming", "清线/野");
            var LaneClear = new Menu("lane", "清线");
            {
                LaneClear.Add(new MenuSlider("mana", "蓝量管理", 50));
                LaneClear.Add(new MenuBool("useq", "使用Q"));
                LaneClear.Add(new MenuSlider("hite", "^- 可击中>=", 2, 1, 6));
                LaneClear.Add(new MenuBool("usee", "使用E"));
            }
            var JungleClear = new Menu("jungle", "清野");
            {
                JungleClear.Add(new MenuSlider("mana", "蓝量管理", 50));
                JungleClear.Add(new MenuBool("useq", "使用Q"));
                JungleClear.Add(new MenuBool("usew", "使用W"));
                JungleClear.Add(new MenuBool("usee", "使用E"));
            }
            RootMenu.Add(FarmMenu);
            FarmMenu.Add(LaneClear);
            FarmMenu.Add(JungleClear);
            
            DrawMenu = new Menu("drawings", "显示");
            {
                DrawMenu.Add(new MenuBool("drawq", "显示 Q 距离"));
                DrawMenu.Add(new MenuBool("drawe", "显示 E 距离"));
                DrawMenu.Add(new MenuBool("drawr", "显示 R 距离"));
                DrawMenu.Add(new MenuBool("flashr", "显示闪现R距离"));
            }

            RootMenu.Add(DrawMenu);
            RootMenu.Add(new MenuKeyBind("flashr", "闪现R!", Keys.G, KeyBindType.Press));
            RootMenu.Attach();
        }


        protected override void SetSpells()
        {
            Q = new Spell(SpellSlot.Q, 900);
            W = new Spell(SpellSlot.W, 150);
            E = new Spell(SpellSlot.E, 650);
            R = new Spell(SpellSlot.R, 700);
            Q.SetSkillshot(0.9f, 60, float.MaxValue, false, SkillshotType.Line, false, HitChance.None);
        }
    }
}

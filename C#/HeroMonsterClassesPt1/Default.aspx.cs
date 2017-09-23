using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeroMonsterClassesPt1
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Character Hero = new Character();
            Hero.Name = "Mermaid Man";
            Hero.Health = 120;
            Hero.DamageMaximum = 40;
            Hero.AttackBonus = false;

            Character Monster = new Character();
            Monster.Name = "Flounder";
            Monster.Health = 130;
            Monster.DamageMaximum = 35;
            Monster.AttackBonus = true;

            int damageByHero = Hero.Attack();
            Monster.Defend(damageByHero);
            int damageByMonster = Monster.Attack();
            Hero.Defend(damageByHero);

            heroStatsLabel.Text = displayStats(Hero);
            monsterStatsLabel.Text = displayStats(Monster);
        }

        private string displayStats(Character character)
        {
            return string.Format("{0} Health: {1} Damage Max: {2} Attack Bonus: {3}", character.Name, character.Health.ToString(), character.DamageMaximum, character.AttackBonus);
        }

        protected void startRoundButton_Click(object sender, EventArgs e)
        {
            /*int damageByHero = Hero.Attack();
            Monster.Defend(damageByHero);
            int damageByMonster = Monster.Attack();
            Hero.Defend(damageByHero);

            heroStatsLabel.Text = displayStats(Hero);
            monsterStatsLabel.Text = displayStats(Monster);
            */

        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack()
        {
            Random rand = new Random();
            int damageDealt = rand.Next(0, this.DamageMaximum);
            return damageDealt;
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeroMonsterClassesPt2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Initiate dice
            Dice Die = new Dice();
            // Clear battleRoundLabel
            battleRoundLabel.Text = "";

            // Initiate Hero Character
            Character Hero = new Character();
            Hero.Name = "Mermaid Man";
            Hero.Health = 120;
            Hero.DamageMaximum = 40;
            Hero.AttackBonus = true;

            // Initiate Monster Character
            Character Monster = new Character();
            Monster.Name = "Flounder";
            Monster.Health = 130;
            Monster.DamageMaximum = 35;
            Monster.AttackBonus = false;

            while (Hero.Health > 0 && Monster.Health > 0)
            {
                
                /*  Alternative Bonus Attack form
                if (Hero.AttackBonus)
                    Monster.Defend(Hero.Attack(Die));
                if (Monster.AttackBonus)
                    Hero.Defend(Monster.Attack(Die));
                */

                // Get damage done by Hero, deduct from Monster health
                int damageByHero = Hero.Attack(Die);
                if (Hero.AttackBonus) damageByHero += 5;                
                Monster.Defend(damageByHero);
                // Get damage done be Monster, deduct from Hero health
                int damageByMonster = Monster.Attack(Die);
                if (Monster.AttackBonus) damageByMonster += 5;
                Hero.Defend(damageByMonster);
                
                // Display stats and results text
                battleRoundLabel.Text += displayStats(Hero);
                battleRoundLabel.Text += displayStats(Monster);
                resultsLabel.Text = displayResults(Hero, Monster);
            }


        }

        private string displayStats(Character character)
        {
            return string.Format("{0} Health: {1} Damage Max: {2} Attack Bonus: {3} <br /><br />", character.Name, character.Health.ToString(), character.DamageMaximum, character.AttackBonus);
        }

        private string displayResults(Character opponent1, Character opponent2)
        {
            // Check if one or both opponents defeated
            if (opponent1.Health <= 0 && opponent2.Health > 0)
            {
                return string.Format("{0} defeats {1}", opponent2.Name, opponent1.Name);
            } else if (opponent2.Health <= 0 && opponent1.Health > 0)
            {
                return string.Format("{0} defeats {1}", opponent1.Name, opponent2.Name);
            } else
            {
                return string.Format("Both {0} and {1} have died", opponent1.Name, opponent2.Name);
            }
        }

        protected void startRoundButton_Click(object sender, EventArgs e)
        {
            
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice die)
        {
            die.Sides = this.DamageMaximum;
            return die.Roll();
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }

    class Dice
    {
        public int Sides { get; set; }

        Random rand = new Random();

        public int Roll()
        {
            return rand.Next(this.Sides);
        }
    }
}
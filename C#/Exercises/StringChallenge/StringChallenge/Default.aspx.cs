using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StringChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Reverse name
            string name = "Zach Fregin";
            StringBuilder sb = new StringBuilder();
            for (int i = name.Length - 1; i > -1; i--)
            {
                sb.Append(name[i]);
            }
            Label1.Text = sb.ToString();


            // 2. Reverse this sequence:
            string names = "Luke,Leia,Han,Chewbacca";
            // To look like Chewbacca,Han,Leia,Luke

            string[] splitArray = names.Split(',');
            string reversed = "";
            for (int i = splitArray.Length - 1; i > -1; i--)
            {
                reversed += splitArray[i] + ",";
            }
            Label2.Text = reversed.Remove(reversed.Length -1, 1);


            // 3. Use the sequence to create ASCII art:
            // *****luke*****
            // *****leia*****
            // *****han******
            // **Chewbacca***

            string result = "";
            for (int i = 0; i < splitArray.Length; i++)
            {
                int padleft = (14 - splitArray[i].Length) / 2;
                string temp = splitArray[i].PadLeft(splitArray[i].Length + padleft, '*');
                result += temp.PadRight(14, '*');
                result += "<br />";
            }
            Label3.Text = result;

            // 4. Solve this puzzle:
            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";
            // Now is the time for all good men to come to the aid of their country.

            puzzle = puzzle.ToLower();
            puzzle = puzzle.Replace('z', 't');
            puzzle = puzzle.Remove(0, 1);
            puzzle = puzzle.Insert(0, "N");
            string toDelete = "remove-me";
            int index = puzzle.IndexOf(toDelete);
            puzzle = puzzle.Remove(index, toDelete.Length);
            
            Label4.Text = puzzle;
        }
    }
}
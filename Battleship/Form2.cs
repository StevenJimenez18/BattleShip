using BattleShipLibrary;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship

{
    public partial class Form2 : Form
    {
        
        
        List<Button> playerButtonList;

        public Form2()
        {
            InitializeComponent();
            ButtonLoad();
        }

        private void txtWS1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateShips_Click(object sender, EventArgs e)
        {
            List<string> WS = new List<string>() { txtWS1.Text, txtWS2.Text, txtWS3.Text, txtWS4.Text, txtWS5.Text };
            List<string> DS = new List<string>() { txtDes1.Text, txtDes2.Text, txtDes3.Text, txtDes4.Text };
            List<string> CS = new List<string>() { txtCrs1.Text, txtCrs2.Text, txtCrs3.Text };
            List<string> TK = new List<string>() { txtTank1.Text, txtTank2.Text };
            List<string> UB = new List<string>() { txtUB1.Text };

            //Corrects the Names of the locations and Invokes Capitalization
            WS = UpdatePlayerList(WS);
            DS = UpdatePlayerList(DS);
            CS = UpdatePlayerList(CS);
            TK = UpdatePlayerList(TK);
            UB = UpdatePlayerList(UB);


            //Creates and sets Warship object for player
            PlayerShip warShip = new PlayerShip();
            warShip.Name = "Warship";
            warShip.Location = WS;
            warShip.HitPoints = 5;
            PlayerShip.GetWarShip(warShip);

            //Creates and sets Destroyer object for player
            PlayerShip destroyer = new PlayerShip();
            destroyer.Name = "Warship";
            destroyer.Location = DS;
            destroyer.HitPoints = 4;
            PlayerShip.GetDestroyer(destroyer);

            //Creates and sets Cruiser object for player
            PlayerShip cruiser = new PlayerShip();
            destroyer.Name = "Warship";
            destroyer.Location = DS;
            destroyer.HitPoints = 4;
            PlayerShip.GetCruiser(cruiser);

            //Creates and sets Tanker object for player
            PlayerShip tanker = new PlayerShip();
            destroyer.Name = "Warship";
            destroyer.Location = DS;
            destroyer.HitPoints = 4;
            PlayerShip.GetTanker(tanker);

            //Creates and sets UBoat object for player
            PlayerShip uBoat = new PlayerShip();
            destroyer.Name = "Warship";
            destroyer.Location = DS;
            destroyer.HitPoints = 4;
            PlayerShip.GetUBoat(uBoat);



            WS = new List<string>() { txtWS1.Text, txtWS2.Text, txtWS3.Text, txtWS4.Text, txtWS5.Text };
            DS = new List<string>() { txtDes1.Text, txtDes2.Text, txtDes3.Text, txtDes4.Text };
            CS = new List<string>() { txtCrs1.Text, txtCrs2.Text, txtCrs3.Text };
            TK = new List<string>() { txtTank1.Text, txtTank2.Text };
            UB = new List<string>() { txtUB1.Text };

            WS = UpdateEnemyList(WS);
            DS = UpdateEnemyList(DS);
            CS = UpdateEnemyList(CS);
            TK = UpdateEnemyList(TK);
            UB = UpdateEnemyList(UB);

            EnemyShips enemyWarShip = new EnemyShips();
            enemyWarShip.Name = "Enemy Warship";
            enemyWarShip.HitPoints = 5;
            EnemyShips.GetEnemyLocations(enemyWarShip, enemyWarShip.HitPoints);
            EnemyShips.GetWarShip(enemyWarShip);

            EnemyShips enemyDestroyer = new EnemyShips();
            enemyDestroyer.Name = "Enemy Destroyer";
            enemyDestroyer.HitPoints = 4;
            EnemyShips.GetEnemyLocations(enemyDestroyer, enemyDestroyer.HitPoints);
            EnemyShips.GetDestroyer(enemyDestroyer);

            EnemyShips enemyCruiser = new EnemyShips();
            enemyCruiser.Name = "Enemy Cruiser";
            enemyCruiser.HitPoints = 3;
            EnemyShips.GetEnemyLocations(enemyCruiser, enemyCruiser.HitPoints);
            EnemyShips.GetCrusier(enemyCruiser);

            EnemyShips enemyTanker = new EnemyShips();
            enemyTanker.Name = "Enemy Tanker";
            enemyTanker.HitPoints = 2;
            EnemyShips.GetEnemyLocations(enemyTanker, enemyTanker.HitPoints);
            EnemyShips.GetTanker(enemyTanker);

            Form2.ActiveForm.Hide();
            Form1 form1 = new Form1();
            form1.Show();
            
        }

        public List<string> UpdateEnemyList(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            List<string> newList = new List<string>();

            foreach(String s in list)
            {
                sb.Append("E");
                sb.Append(s.ToUpper());
                newList.Add(sb.ToString());
                sb.Clear();
            }

            return newList;
        }

        public List<string> UpdatePlayerList(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            List<string> newList = new List<string>();

            foreach (String s in list)
            {
                sb.Append("P");
                sb.Append(s.ToUpper());
                newList.Add(sb.ToString());
                sb.Clear();
            }

            return newList;
        }



        public void ButtonLoad()
        {
            List<string> AlphaList = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            playerButtonList = new List<Button>();

            var counter = 1;
            var letterPlaceholder = 0;

            foreach (Control c in gbTempPlayerSpace.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Text = "";
                    //c.Text = "P" + AlphaList[letterPlaceholder] + counter;
                    c.Name = "P" + AlphaList[letterPlaceholder] + counter;
                }

                if (counter <= 8)
                {
                    counter++;
                }

                if (counter > 8)
                {
                    counter = 1;
                    letterPlaceholder++;
                }
            }
        }
    }
}

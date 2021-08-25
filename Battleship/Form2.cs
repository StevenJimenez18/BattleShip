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


            //---Player Models Below---//

            //Creates and sets Warship object for player
            PlayerShip warShip = new PlayerShip();
            warShip.Name = "Warship";
            warShip.Location = WS;
            warShip.HitPoints = 5;
            PlayerShip.GetWarShip(warShip);

            //Creates and sets Destroyer object for player
            PlayerShip destroyer = new PlayerShip();
            destroyer.Name = "Destroyer";
            destroyer.Location = DS;
            destroyer.HitPoints = 4;
            PlayerShip.GetDestroyer(destroyer);

            //Creates and sets Cruiser object for player
            PlayerShip cruiser = new PlayerShip();
            cruiser.Name = "Cruiser";
            cruiser.Location = CS;
            cruiser.HitPoints = 3;
            PlayerShip.GetCruiser(cruiser);

            //Creates and sets Tanker object for player
            PlayerShip tanker = new PlayerShip();
            tanker.Name = "Tanker";
            tanker.Location = TK;
            tanker.HitPoints = 2;
            PlayerShip.GetTanker(tanker);

            //Creates and sets UBoat object for player
            PlayerShip uBoat = new PlayerShip();
            uBoat.Name = "UBoat";
            uBoat.Location = UB;
            uBoat.HitPoints = 1;
            PlayerShip.GetUBoat(uBoat);


            //---Enemy Models Below---//

            //---Creates and sets Warship object for enemy
            EnemyShips enemyWarShip = new EnemyShips();
            enemyWarShip.Name = "Enemy Warship";
            enemyWarShip.HitPoints = 5;
            EnemyShips.GetEnemyLocations(enemyWarShip, enemyWarShip.HitPoints);
            EnemyShips.GetWarShip(enemyWarShip);

            //Creates and sets Destroyer object for enemy
            EnemyShips enemyDestroyer = new EnemyShips();
            enemyDestroyer.Name = "Enemy Destroyer";
            enemyDestroyer.HitPoints = 4;
            EnemyShips.GetEnemyLocations(enemyDestroyer, enemyDestroyer.HitPoints);
            EnemyShips.GetDestroyer(enemyDestroyer);

            //Creates and sets Cruiser object for player
            EnemyShips enemyCruiser = new EnemyShips();
            enemyCruiser.Name = "Enemy Cruiser";
            enemyCruiser.HitPoints = 3;
            EnemyShips.GetEnemyLocations(enemyCruiser, enemyCruiser.HitPoints);
            EnemyShips.GetCrusier(enemyCruiser);

            //Creates and sets Tanker object for enemy
            EnemyShips enemyTanker = new EnemyShips();
            enemyTanker.Name = "Enemy Tanker";
            enemyTanker.HitPoints = 2;
            EnemyShips.GetEnemyLocations(enemyTanker, enemyTanker.HitPoints);
            EnemyShips.GetTanker(enemyTanker);

            //Creates and sets UBoat object for player
            EnemyShips enemyUBoat = new EnemyShips();
            enemyUBoat.Name = "Enemy UBoat";
            enemyUBoat.HitPoints = 1;
            EnemyShips.GetEnemyLocations(enemyUBoat, enemyUBoat.HitPoints);
            EnemyShips.GetUBoat(enemyUBoat);

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

        private void label27_Click(object sender, EventArgs e)
        {

        }
    }
}

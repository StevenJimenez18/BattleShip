using BattleShipLibrary;
using System;
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
    public partial class Form3 : Form
    {
        

        public Form3()
        {
            InitializeComponent();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnChooseOwn_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void btnAutoCreate_Click(object sender, EventArgs e)
        {
            //---Player Models Below---//

            //Creates and sets Warship object for player
            PlayerShip warShip = new PlayerShip();
            warShip.Name = "Warship";
            warShip.HitPoints = 5;
            PlayerShip.GetWarShip(warShip);
            PlayerShip.GetPlayerLocations(warShip, warShip.HitPoints);

            //Creates and sets Destroyer object for player
            PlayerShip destroyer = new PlayerShip();
            destroyer.Name = "Destroyer";
            destroyer.HitPoints = 4;
            PlayerShip.GetDestroyer(destroyer);
            PlayerShip.GetPlayerLocations(destroyer, destroyer.HitPoints);

            //Creates and sets Cruiser object for player
            PlayerShip cruiser = new PlayerShip();
            cruiser.Name = "Cruiser";
            cruiser.HitPoints = 3;
            PlayerShip.GetCruiser(cruiser);
            PlayerShip.GetPlayerLocations(cruiser, cruiser.HitPoints);

            //Creates and sets Tanker object for player
            PlayerShip tanker = new PlayerShip();
            tanker.Name = "Tanker";
            tanker.HitPoints = 2;
            PlayerShip.GetTanker(tanker);
            PlayerShip.GetPlayerLocations(tanker, tanker.HitPoints);

            //Creates and sets UBoat object for player
            PlayerShip uBoat = new PlayerShip();
            uBoat.Name = "UBoat";
            uBoat.HitPoints = 1;
            PlayerShip.GetUBoat(uBoat);
            PlayerShip.GetPlayerLocations(uBoat, uBoat.HitPoints);

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

            Form3.ActiveForm.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}

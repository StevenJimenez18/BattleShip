using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using BattleShipLibrary;


namespace Battleship
{
    public partial class Form1 : Form
    {
        //Global variables

        //Holds button list for reference
        List<Button> enemyButtonList;
        List<Button> playerButtonList;

        //Creates variables of player ship objects
        PlayerShip playerWarship = PlayerShip.warShip;
        PlayerShip playerDestroyer = PlayerShip.destroyer;
        PlayerShip playerCruiser = PlayerShip.cruiser;
        PlayerShip playerTanker = PlayerShip.tanker;

        //Creates variables of enemy ship objects
        EnemyShips enemyWarship = EnemyShips.warShip;
        EnemyShips enemyDestroyer = EnemyShips.destroyer;
        EnemyShips enemyCruiser = EnemyShips.cruiser;
        EnemyShips enemyTanker = EnemyShips.tanker;

        //Variables to prevent repeat messages
        bool enemyWarShipMessageDisplayed = false;
        bool enemyDestroyerMessageDisplayed = false;
        bool enemyCruiserMessageDisplayed = false;
        bool enemyTankerMessagedDisplayed = false;
        bool enemyUBoatMessageDisplayed = false;


        //Tracks game over
        bool gameOver = false;


        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
     
        private void Form1_Load(object sender, EventArgs e)
        {
            lbEnemyStatus.Visible = false;
            btnPlayAgain.Visible = false;
            GameBoardLoad();
            PlayerLoad();
            EnemyLoad();
            

        }

        //Updates the button names with a custom Algo
        private void GameBoardLoad()
        {

            List<string> AlphaList = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            playerButtonList = new List<Button>();
            enemyButtonList = new List<Button>();

            int counter = 1;
            int letterPlaceholder = 0;

            foreach (Control c in gbEnemySpace.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Text = "";
                    //c.Text = "E" + AlphaList[letterPlaceholder] + counter;
                    c.Name = "E" + AlphaList[letterPlaceholder] + counter;
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

            counter = 1;
            letterPlaceholder = 0;

            foreach (Control c in gbPlayerSpace.Controls)
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

            foreach (Control b in gbEnemySpace.Controls)
            {
                if (b.GetType() == typeof(Button))
                {
                    enemyButtonList.Add((Button)b);
                }


            }

            foreach (Control b in gbPlayerSpace.Controls)
            {
                if (b.GetType() == typeof(Button))
                {
                    playerButtonList.Add((Button)b);
                }


            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        //Loads the player ship locations to the game board
        public void PlayerLoad()
        {

            
            /*foreach (var s in PlayerShip.warShip.Location)
            {
                Button tempButton = playerButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }*/
            /*
            foreach (var s in PlayerShips.newPlayer.Destroyer)
            {
                Button tempButton = playerButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }
            foreach (var s in PlayerShips.newPlayer.Cruiser)
            {
                Button tempButton = playerButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }
            foreach (var s in PlayerShips.newPlayer.Tanker)
            {
                Button tempButton = playerButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }
            foreach (var s in PlayerShips.newPlayer.UBoat)
            {
                Button tempButton = playerButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }*/


        }

        //Loads the enemy ship locations to game board
        public void EnemyLoad()
        {


            foreach (var s in EnemyShips.warShip.Location)
            {
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }
            foreach (var s in EnemyShips.destroyer.Location)
            {
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }
            foreach (var s in EnemyShips.cruiser.Location)
            {
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }
            foreach (var s in EnemyShips.tanker.Location)
            {
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }
            /* foreach (var s in EnemyShips.newEnemy.UBoat)
             {
                 Button tempButton = enemyButtonList.First(b => b.Name.ToString() == s);
                 tempButton.BackColor = Color.Green;
             }*/


        }


        //Game Mechanics
        private void btnFire_Click(object sender, EventArgs e)
        {

            var playerAttack = txtAttackBox.Text = "E" + txtAttackBox.Text.ToUpper();
            txtAttackBox.Clear();
            TurnSwitch(playerAttack);
            /*CheckEnemyHit(txtAttackBox.Text);
            CheckEnemyDead();
            EnemyAttack();*/
               
        }

        private void TurnSwitch(string playerAttack)
        {
            PlayerTurn(playerAttack);
            EnemyTurn();
            CheckGameOver();
            PlayAgain();
        }

        private void PlayerTurn(string attack)
        {
            CheckEnemyHit(attack);
            CheckEnemyDead();
          
        }

        private void EnemyTurn()
        {
            var enemyAttack = EnemyAttack();
            CheckPlayerHit(enemyAttack);
            CheckPlayerDead();
             
        }



        //---Handles the players attack on the enemy. If hit will turn red. if miss will turn purple---//
        private void CheckEnemyHit(string text)
        {
            //---Checks Warship health and sets isdead property if hitpoints fall to zero---//

            if (EnemyShips.warShip.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = enemyButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                EnemyShips.warShip.HitPoints--;

                //changes isdead property when ship health falls to zero
                if (EnemyShips.warShip.HitPoints == 0)
                {
                    EnemyShips.warShip.IsDead = true;
                }
            }

            //---Checks Destroyer health and sets isdead property if hitpoints fall to zero---//
            if (EnemyShips.destroyer.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = enemyButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                EnemyShips.destroyer.HitPoints--;

                //---changes isdead property when ship health falls to zero---//
                if (EnemyShips.destroyer.HitPoints == 0)
                {
                    EnemyShips.destroyer.IsDead = true;  
                }
            }

            //---Checks Cruiser health and sets isdead property if hitpoints fall to zero---//
            if (EnemyShips.cruiser.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = enemyButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;

                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                EnemyShips.cruiser.HitPoints--;

                //---Changes isdead property when ship health falls to zero---//
                if (EnemyShips.cruiser.HitPoints == 0)
                {
                    EnemyShips.cruiser.IsDead = true;
                }
            }

            //---Checks Tanker health and sets isdead property if hitpoints fall to zero---//
            if (EnemyShips.tanker.Location.Contains(text))
            {

                //---Changes hit location to red---//
                Button tempButton = enemyButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                EnemyShips.tanker.HitPoints--;

                //---changes isdead property when ship health falls to zero---//
                if (EnemyShips.tanker.HitPoints == 0)
                {
                    EnemyShips.tanker.IsDead = true;
                }
            }

            //---Handles missed attacks---//
            else if (!EnemyShips.warShip.Location.Contains(text) && !EnemyShips.destroyer.Location.Contains(text) && !EnemyShips.cruiser.Location.Contains(text))
            {
                //---Changes miss location to purple---//
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Indigo;
                //playerButtonList.Remove(tempButton);
            }
        }

        //Checks enemy ship heatlh. If a ship is destroyed the player will be notified
        private void CheckEnemyDead()
        {

            
            if (EnemyShips.warShip.IsDead == true)
            {
                if (enemyWarShipMessageDisplayed == false)
                {
                    enemyWarShipMessageDisplayed = true;
                    DestroyedMessage("e", EnemyShips.warShip.Name);
                }
            }

            if (EnemyShips.destroyer.IsDead == true)
            {
                if (enemyDestroyerMessageDisplayed == false)
                {
                    enemyDestroyerMessageDisplayed = true;
                    DestroyedMessage("e", EnemyShips.destroyer.Name);
                }
            }

            if (EnemyShips.cruiser.IsDead == true)
            {
                
                if (enemyCruiserMessageDisplayed == false)
                {
                    enemyCruiserMessageDisplayed = true;
                    DestroyedMessage("e", EnemyShips.cruiser.Name);
                }
            }

            if (EnemyShips.tanker.IsDead == true)
            {
                
                if (enemyTankerMessagedDisplayed == false)
                {
                    enemyTankerMessagedDisplayed = true;
                    DestroyedMessage("e", EnemyShips.tanker.Name);
                }
            }
        }

        //Handles enemy attack - currently set to random selection. 
        private string EnemyAttack()
        {
            lbEnemyStatus.Visible = true;
            lbEnemyStatus.Text = "Enemy is now choosing it's target.";
           
            Random rand = new Random();
            List<String> letters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            var letterSelection = rand.Next(0, 7);
            var letterChoice = letters[letterSelection];
            var numberSelection = rand.Next(1, 8);
            StringBuilder attackChoice = new StringBuilder();
            attackChoice.Append("P");
            attackChoice.Append(letters[letterSelection]);
            attackChoice.Append(numberSelection);
            //MessageBox.Show(attackChoice.ToString());
            //PlayerFlow(attackChoice.ToString());
            return attackChoice.ToString();
            /*CheckPlayerHit();
            CheckPlayerDead();*/

        }

        //Verfies enemy attack on player. If hit will turn red. If miss will turn purple.
        private void CheckPlayerHit(String text)
        {
            if (PlayerShip.warShip.Location.Contains(text))
            {
                PlayerShip.warShip.HitPoints--;
                Button tempButton = playerButtonList.First(b => b.Name == text);
                tempButton.BackColor = Color.Firebrick;
                //playerButtonList.Remove(tempButton);
            }
            else
            {
                Button tempButton = playerButtonList.First(b => b.Name == text);
                tempButton.BackColor = Color.Indigo;
                //playerButtonList.Remove(tempButton);
            }
        }

        //Checks player ship health. If ship is destroyed the property will be updated here.
        private void CheckPlayerDead()
        {
            if(PlayerShip.warShip.HitPoints == 0)
            {
                
                    PlayerShip.warShip.IsDead = true;
                    DestroyedMessage("p",PlayerShip.warShip.Name);
                    MessageBox.Show($"Your {PlayerShip.warShip.Name} has been destroyed!");
                
            }
            if (PlayerShip.destroyer.HitPoints == 0)
            {
                PlayerShip.destroyer.IsDead = true;
                DestroyedMessage("p", PlayerShip.destroyer.Name);
                MessageBox.Show($"Your {PlayerShip.destroyer.Name} has been destroyed!");
            }
        }


        //After verifying player or enemy ship health this function will display a message once the turn a ship has been destroyed
        private void DestroyedMessage(string letter, string name)
        {
            if (letter == "e")
            {
                MessageBox.Show($"You have destroyed the {name}!");
             
            }
            if (letter == "p")
            {

                MessageBox.Show($"Your {name} was destroyed!");
            }
        }


        //Handles game over
        private void CheckGameOver()
        {
            if (playerWarship.IsDead == true && playerDestroyer.IsDead == true && playerCruiser.IsDead == true && playerTanker.IsDead == true)
            {
                MessageBox.Show("The enemy has decimated your fleet. You lose.");
                gameOver = true;
            }

            if (enemyWarship.IsDead == true && enemyDestroyer.IsDead == true && enemyCruiser.IsDead == true && enemyTanker.IsDead == true)
            {
                MessageBox.Show("All the enemies ships have been destroyed. YOU WIN!!!");
                gameOver = true;
            }

        }

        private void PlayAgain()
        {
            if(gameOver == true)
            {
                btnPlayAgain.Visible = true;
                gbAttackControls.Visible = false;
            }
        }

        private void GameReset(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}

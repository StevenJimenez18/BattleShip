
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLibrary
{
    public class PlayerShip : IShip
    {
        public string Name { get; set; }
        public List<string> Location { get ; set; }
        public bool IsDead { get; set; }
        public int HitPoints { get; set ; }

        public static PlayerShip warShip { get; set; }
        public static PlayerShip destroyer { get; set; }
        public static PlayerShip cruiser { get; set; }
        public static PlayerShip tanker { get; set; }
        public static PlayerShip uBoat { get; set; }

        public PlayerShip()
        {
            
        }

        public static void GetWarShip(PlayerShip playerShip)
        {
            warShip = playerShip;
        }
        public static void GetDestroyer(PlayerShip playerShip)
        {
            destroyer = playerShip;
        }
        public static void GetCruiser(PlayerShip playerShip)
        {
            cruiser = playerShip;
        }
        public static void GetTanker(PlayerShip playerShip)
        {
            tanker = playerShip;
        }
        public static void GetUBoat(PlayerShip playerShip)
        {
            uBoat = playerShip;
        }

       
        
    }
}

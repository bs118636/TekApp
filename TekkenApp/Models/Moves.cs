using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenApp.Models
{
    public class Moves
    {
        [Key]
        public int MoveId { get; set; }
        public int CharacterId { get; set; }
        public string Command { get; set; }
        public string HitLevel { get; set; }
        public string Damage { get; set; }
        public string StartUpFrame { get; set; }
        public string BlockFrame { get; set; }
        public string HitFrame { get; set; }
        public string CounterHitFrame { get; set; }
        public string Notes { get; set; }
    }
}

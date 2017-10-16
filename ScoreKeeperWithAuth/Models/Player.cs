using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperWithAuth.Models
{
    public class Player
    {
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        [NotMapped]
        public virtual int TotalScore
        {
            get { return Scores.Sum(e => e.Value); }
        }

        // -----

        public virtual List<Score> Scores { get; set; } = new List<Score>();

        // -----

        [NotMapped]
        public virtual double AverageScore
        {
            get { return (double)Scores.Sum(e => e.Value) / Scores.Count(); }
        }

    }
}

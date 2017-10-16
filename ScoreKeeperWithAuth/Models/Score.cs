using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperWithAuth.Models
{
    public class Score
    {
        public virtual int ID { get; set; }

        public virtual int Value { get; set; }

        public virtual Player Player { get; set; }
    }
}

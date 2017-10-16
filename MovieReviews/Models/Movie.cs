using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReviews.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public double Rating
        {
            get
            {
                if (Reviews.Any())
                    return Reviews.Average(e => e.Rating);
                else
                    return 0;
            }
        }

        public List<Review> Reviews { get; set; } = new List<Review>();

        public static void Create(Movie game)
        {
            GlobalVaraibles.Games.Add(game);
        }

        public static List<Movie> ReadAll()
        {
            return GlobalVaraibles.Games;
        }

        public static Movie Read(string name)
        {
            // Update this? Lamda expression?
            foreach(var game in GlobalVaraibles.Games)
            {
                if (game.Name == name)
                    return game;
            }
            return null;
        }

        public void AddReviewToMovie(Review review)
        {
            Reviews.Add(review);
        }
    }
}

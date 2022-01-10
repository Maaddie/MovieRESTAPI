using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRESTAPI
{
    
    public class MovieDAL
    {
        public List<Movie> GetAllMovies()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movie";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();
                connect.Close();

                return movies;
            }
        }

        public List<Movie> GetMovieByCategory(string category)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = $"select * from movie where category = '{category}'";

                    connect.Open();
                    List<Movie> movie = connect.Query<Movie>(sql).ToList();
                    connect.Close();
               
                    return movie;
            }

        }
        public Movie GetRandomMovie()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = $"select * from movie";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();

                Random randa = new Random();
                int randNum = randa.Next(0, movies.Count);
                
                connect.Close();

                return movies[randNum];
            }
        }

        public Movie GetRandomMovieByCategory(string category)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = $"select * from movie where category = '{category}'";

                connect.Open();
                List<Movie> movie = connect.Query<Movie>(sql).ToList();
                connect.Close();

                Random randa = new Random();
                int randNum = randa.Next(0, movie.Count);

                connect.Close();
                try
                {
                    return movie[randNum];
                }
                catch 
                {
                    return new Movie() { Category = "Invalid Category" };
                }
                

            }

        }

    }
}

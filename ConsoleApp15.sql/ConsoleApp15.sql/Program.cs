using System.Data;

namespace ConsoleApp15.sql
{
    internal class Program
    {
        static void Main(string[] args)
        {

            --1.Actor Table
            CREATE TABLE actor(
                act_id INT PRIMARY KEY,
                act_fname CHAR(20),
    act_lname CHAR(20),
    act_gender CHAR(1)
);

            --2.Director Table
            CREATE TABLE director(
                dir_id INT PRIMARY KEY,
                dir_fname CHAR(20),
    dir_lname CHAR(20)
);

            --3.Genres Table
            CREATE TABLE genres(
                gen_id INT PRIMARY KEY,
                gen_title CHAR(20)
);

            --4.Reviewer Table
            CREATE TABLE reviewer(
                rev_id INT PRIMARY KEY,
                rev_name CHAR(30)
);

            --5.Movie Table
            CREATE TABLE movie(
                mov_id INT PRIMARY KEY,
                mov_title CHAR(50),
    mov_year INT,
    mov_time INT,
    mov_lang CHAR(50),
    mov_dt_rel DATE,
    mov_rel_country CHAR(5)
);

            --6.Movie_Cast Table
            CREATE TABLE movie_cast(
                act_id INT,
                mov_id INT,
                role CHAR(30),

    CONSTRAINT PK_movie_cast
    PRIMARY KEY(act_id, mov_id),

    CONSTRAINT FK_cast_actor
    FOREIGN KEY(act_id) REFERENCES actor(act_id),

    CONSTRAINT FK_cast_movie
    FOREIGN KEY(mov_id) REFERENCES movie(mov_id)
);

            --7.Movie_Direction Table
            CREATE TABLE movie_direction(
                dir_id INT,
                mov_id INT,

                CONSTRAINT PK_movie_direction
            
                PRIMARY KEY (dir_id, mov_id),

                CONSTRAINT FK_direction_director
            
                FOREIGN KEY (dir_id) REFERENCES director(dir_id),

                CONSTRAINT FK_direction_movie
            
                FOREIGN KEY (mov_id) REFERENCES movie(mov_id)
            );

            --8.Movie_Genres Table
            CREATE TABLE movie_genres(
                mov_id INT,
                gen_id INT,

                CONSTRAINT PK_movie_genres
            
                PRIMARY KEY (mov_id, gen_id),

                CONSTRAINT FK_genres_movie
            
                FOREIGN KEY (mov_id) REFERENCES movie(mov_id),

                CONSTRAINT FK_genres_genres
            
                FOREIGN KEY (gen_id) REFERENCES genres(gen_id)
            );

            --9.Rating Table
            CREATE TABLE rating(
                mov_id INT,
                rev_id INT,
                rev_stars INT,
                num_o_ratings INT,

                CONSTRAINT PK_rating
            
                PRIMARY KEY (mov_id, rev_id),

                CONSTRAINT FK_rating_movie
            
                FOREIGN KEY (mov_id) REFERENCES movie(mov_id),

                CONSTRAINT FK_rating_reviewer
            
                FOREIGN KEY (rev_id) REFERENCES reviewer(rev_id)
            );

        }
    }
}

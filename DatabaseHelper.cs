using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Diagnostics;

namespace FitnessApp
{
    internal class DatabaseHelper
    {
        private static string connectionString = "DataSource=fitness_center.db";

        public static void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string users = @"create table users(id integer primary key autoincrement, username varchar(50) unique not null, password_md5_hash varchar(32) not null);";
                string members = @"create table members(id integer primary key autoincrement, first_name varchar(50) not null, last_name varchar(50) not null, registered_by_user integer not null, foreign key (registered_by_user) references users(id));";
                string lessonTypes = @"create table lesson_types(id integer primary key autoincrement, type varchar(50) unique not null);";
                string lessons = @"create table lessons(id integer primary key autoincrement, name varchar(50) not null, id_lesson_type integer not null, date datetime not null, foreign key (id_lesson_type) references lesson_types(id));";
                string reservations = @"create table reservations(id integer primary key autoincrement, id_member integer not null, id_lesson integer not null, date datetime not null, foreign key (id_member) references members(id), foreign key (id_lesson) references lessons(id));";

                using (var command = new SqliteCommand())
                {
                    command.Connection = connection;

                    command.CommandText = users;
                    command.ExecuteNonQuery();
                    command.CommandText = members;
                    command.ExecuteNonQuery();
                    command.CommandText = lessonTypes;
                    command.ExecuteNonQuery();
                    command.CommandText = lessons;
                    command.ExecuteNonQuery();
                    command.CommandText = reservations;
                    command.ExecuteNonQuery();

                    command.CommandText = "insert into users(username, password_md5_hash) values (\"admin\", $hash);";
                    System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                    string password = "admin";
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    command.Parameters.AddWithValue("$hash", Convert.ToHexString(hashBytes));
                    Trace.WriteLine(Convert.ToHexString(hashBytes));
                    command.ExecuteNonQuery();

                    command.CommandText = "select * from users;";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Trace.WriteLine($"{reader.GetInt32(0)}");
                        Trace.WriteLine($"{reader.GetString(1)}");
                        Trace.WriteLine($"{reader.GetString(2)}");
                    }
                }
            }
        }
    }
}

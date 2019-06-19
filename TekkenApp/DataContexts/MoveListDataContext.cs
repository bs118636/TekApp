using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenApp.General;
using TekkenApp.Models;

namespace TekkenApp.DataContexts
{
    public class MoveListDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MoveListDataContext()
        {
            CharacterList = GetCharacters();
        }

        public List<Character> CharacterList { get; set; }

        private Character _selectedCharacter { get; set; } = null;
        public Character SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
                MoveList = GetMoves();
                SelectedMove = MoveList.Count > 0 ? MoveList[0] : null;
                OnPropertyChanged("MoveList");
                OnPropertyChanged("SelectedMove");
            }
        }

        public List<Moves> MoveList { get; set; }
        public Moves SelectedMove { get; set; }

        //Methods
        private List<Character> GetCharacters()
        {
            var l = new List<Character>();
            string query = "SELECT * FROM Characters";

            using (var db = new TekkenEntity(SqliteConnectionString.ConnectionString))
            {
                l = db.Database.SqlQuery<Character>(query).ToList();
            }

            return l;
        }

        private List<Moves> GetMoves()
        {
            if (SelectedCharacter == null) { return null; }

            var l = new List<Moves>();
            string query = $"SELECT * FROM Moves WHERE CharacterId = {SelectedCharacter.Id}";

            using (var db = new TekkenEntity(SqliteConnectionString.ConnectionString))
            {
                l = db.Database.SqlQuery<Moves>(query).ToList();
            }

            return l;
        }

        //private List<Character> GetCharacterList()
        //{
        //    var list = new List<Character>();

        //    using (var conn = new SQLiteConnection(SqliteConnectionString.ConnectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = "SELECT * FROM Characters";

        //            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
        //            {
        //                using (var rdr = cmd.ExecuteReader())
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        var row = new Character()
        //                        {
        //                            Id = rdr.GetInt32(0),
        //                            CharacterName = rdr.GetString(1)
        //                        };
        //                        list.Add(row);
        //                    }
        //                }
        //            }
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }

        //    return list;
        //}

        //private List<Moves> GetMoveList()
        //{
        //    if (SelectedCharacter == null) { return null; }

        //    var list = new List<Moves>();

        //    using (var conn = new SQLiteConnection(SqliteConnectionString.ConnectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = $"SELECT * FROM Moves WHERE CharacterId = {SelectedCharacter.Id}";

        //            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
        //            {
        //                using (var rdr = cmd.ExecuteReader())
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        //Damage is one of the columns messing up because of nulls
        //                        var row = new Moves()
        //                        {
        //                            MoveId = rdr.GetInt32(0),
        //                            CharacterId = rdr.GetInt32(1),
        //                            Command = rdr.GetString(2),
        //                            HitLevel = rdr.GetString(3),
        //                            Damage = rdr.GetString(4)
        //                            //StartUpFrame = rdr.GetString(5),
        //                            //BlockFrame = rdr.GetString(6),
        //                            //HitFrame = rdr.GetString(7),
        //                            //CounterHitFrame = rdr.GetString(8),
        //                            //Notes = rdr.GetString(9)
        //                        };
        //                        list.Add(row);
        //                    }
        //                }
        //            }
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //    return list;
        //}
    }
}

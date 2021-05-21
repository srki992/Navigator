using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigator.Models
{
    /// <summary>
    /// Employee service class which uses an ADO.NET and an SQL Server database with stored procedures to perform CRUD operation
    /// </summary>
    public class KandidatiService : IKandidatiService
    {
        SqlConnection ObjSqlConnection;
        SqlCommand ObjSqlCommand;
        public KandidatiService()
        {
            ObjSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["NavigatorConnection"].ConnectionString);
            ObjSqlCommand = new SqlCommand();
            ObjSqlCommand.Connection = ObjSqlConnection;
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;
        }

        public List<Kandidat> GetAll()
        {
            List<Kandidat> ObjKandidatiList = new List<Kandidat>();
            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "sp_select_tbl_kandidati";

                ObjSqlConnection.Open();
                var ObjSqlDataReader = ObjSqlCommand.ExecuteReader();
                if (ObjSqlDataReader.HasRows)
                {
                    Kandidat ObjKandidat = null;
                    while (ObjSqlDataReader.Read())
                    {
                        ObjKandidat = new Kandidat();
                        ObjKandidat.id = ObjSqlDataReader.GetInt32(0);
                        ObjKandidat.ime = ObjSqlDataReader.GetString(1);
                        ObjKandidat.prezime = ObjSqlDataReader.GetString(2);
                        ObjKandidat.jmbg = ObjSqlDataReader.GetString(3);
                        ObjKandidat.god_rodjenja = ObjSqlDataReader.GetDateTime(4).ToString("dd.MM.yyyy"); 
                        ObjKandidat.email = ObjSqlDataReader.GetString(5);
                        ObjKandidat.telefon = ObjSqlDataReader.GetString(6);
                        ObjKandidat.napomena = ObjSqlDataReader.GetString(7);
                        ObjKandidat.zaposlen_nakon_konkursa = ObjSqlDataReader.GetString(8);
                        ObjKandidat.datum_izmene = ObjSqlDataReader.GetDateTime(9).ToString("dd.MM.yyyy");

                        ObjKandidatiList.Add(ObjKandidat);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }
            return ObjKandidatiList;
        }

        public bool Add(Kandidat objNoviKandidat)
        {
            bool IsAdded = false;
            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "sp_Insert_tbl_kandidati";
                ObjSqlCommand.Parameters.AddWithValue("@ime", objNoviKandidat.ime);
                ObjSqlCommand.Parameters.AddWithValue("@prezime", objNoviKandidat.prezime);
                ObjSqlCommand.Parameters.AddWithValue("@jmbg", objNoviKandidat.jmbg);
                ObjSqlCommand.Parameters.AddWithValue("@god_rodjenja", Convert.ToDateTime(objNoviKandidat.god_rodjenja));
                ObjSqlCommand.Parameters.AddWithValue("@email", objNoviKandidat.email);
                ObjSqlCommand.Parameters.AddWithValue("@telefon", objNoviKandidat.telefon);
                ObjSqlCommand.Parameters.AddWithValue("@napomena", objNoviKandidat.napomena);
                ObjSqlCommand.Parameters.AddWithValue("@zaposlen_nakon_konkursa", objNoviKandidat.zaposlen_nakon_konkursa);
                ObjSqlCommand.Parameters.AddWithValue("@datum_izmene", DateTime.Now);

                ObjSqlConnection.Open();
                int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return IsAdded;
        }

        public bool Update(Kandidat objKandidatToUpdate)
        {
            bool IsUpdated = false;

            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "sp_Update_tbl_kandidati";
                ObjSqlCommand.Parameters.AddWithValue("@ime", objKandidatToUpdate.ime);
                ObjSqlCommand.Parameters.AddWithValue("@prezime", objKandidatToUpdate.prezime);
                ObjSqlCommand.Parameters.AddWithValue("@jmbg", objKandidatToUpdate.jmbg);
                ObjSqlCommand.Parameters.AddWithValue("@god_rodjenja", Convert.ToDateTime(objKandidatToUpdate.god_rodjenja));
                ObjSqlCommand.Parameters.AddWithValue("@email", objKandidatToUpdate.email);
                ObjSqlCommand.Parameters.AddWithValue("@telefon", objKandidatToUpdate.telefon);
                ObjSqlCommand.Parameters.AddWithValue("@napomena", objKandidatToUpdate.napomena);
                ObjSqlCommand.Parameters.AddWithValue("@zaposlen_nakon_konkursa", objKandidatToUpdate.zaposlen_nakon_konkursa);
                ObjSqlCommand.Parameters.AddWithValue("@datum_izmene", DateTime.Now);

                ObjSqlConnection.Open();
                int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return IsUpdated;
        }

        public bool Delete(string jmbg)
        {
            bool IsDeleted = false;
            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "sp_Delete_tbl_kandidati";
                ObjSqlCommand.Parameters.AddWithValue("@jmbg", jmbg);
                
                ObjSqlConnection.Open();
                int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }
            return IsDeleted;
        }
        public List<Kandidat> Search(string vrednostKojaSePretrazuje)
        {
            List<Kandidat> ObjKandidatiList = new List<Kandidat>();
            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "sp_search_tbl_kandidati";
                ObjSqlCommand.Parameters.AddWithValue("@vrednostKojaSePretrazuje", vrednostKojaSePretrazuje);

                ObjSqlConnection.Open();
                var ObjSqlDataReader = ObjSqlCommand.ExecuteReader();
                if (ObjSqlDataReader.HasRows)
                {
                    Kandidat ObjKandidat = null;
                    while (ObjSqlDataReader.Read())
                    {
                        ObjKandidat = new Kandidat();
                        ObjKandidat.id = ObjSqlDataReader.GetInt32(0);
                        ObjKandidat.ime = ObjSqlDataReader.GetString(1);
                        ObjKandidat.prezime = ObjSqlDataReader.GetString(2);
                        ObjKandidat.jmbg = ObjSqlDataReader.GetString(3);
                        ObjKandidat.god_rodjenja = ObjSqlDataReader.GetDateTime(4).ToString("dd.MM.yyyy");
                        ObjKandidat.email = ObjSqlDataReader.GetString(5);
                        ObjKandidat.telefon = ObjSqlDataReader.GetString(6);
                        ObjKandidat.napomena = ObjSqlDataReader.GetString(7);
                        ObjKandidat.zaposlen_nakon_konkursa = ObjSqlDataReader.GetString(8);
                        ObjKandidat.datum_izmene = ObjSqlDataReader.GetDateTime(9).ToString("dd.MM.yyyy");

                        ObjKandidatiList.Add(ObjKandidat);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }
            return ObjKandidatiList;
        }
    }
}


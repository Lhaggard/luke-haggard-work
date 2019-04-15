using ADOFirstDvdLibrary.Interface;
using ADOFirstDvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADOFirstDvdLibrary.Repository
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void Create(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DvdInsert";


                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@RatingValue", dvd.RatingValue);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }


        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDvd";

                cmd.Parameters.AddWithValue("@DvdId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public Dvd Get(int id)
        {
            Dvd dvd = new Dvd();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetById";
                cmd.Parameters.AddWithValue("@DvdId", id);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.Title = dr["Title"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["ReleaseYear"] != DBNull.Value)
                        {
                            currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        }

                        if (dr["DirectorId"] != DBNull.Value)
                        {
                            currentRow.DirectorName = dr["DirectorName"].ToString();
                        }

                        if (dr["RatingId"] != DBNull.Value)
                        {
                            currentRow.RatingValue = dr["RatingValue"].ToString();
                        }
                        currentRow.DvdId = (int)dr["DvdId"];
                        dvd = currentRow;
                    }
                }
            }
            return dvd;
        }

        public List<Dvd> GetByDirectorName(string directorName)
        {
            List<Dvd> _dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdADO"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchByDirector";
                cmd.Parameters.AddWithValue("@DirectorName", directorName);

                conn.Open();
                cmd.ExecuteNonQuery();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.Title = dr["Title"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["ReleaseYear"] != DBNull.Value)
                        {
                            currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        }

                        if (dr["DirectorName"] != DBNull.Value)
                        {
                            currentRow.DirectorName = dr["DirectorName"].ToString();
                        }

                        if (dr["RatingValue"] != DBNull.Value)
                        {
                            currentRow.RatingValue = dr["RatingValue"].ToString();
                        }
                        currentRow.DvdId = (int)dr["DvdId"];
                        _dvds.Add(currentRow);

                    }
                }

            }
            return _dvds;
        }

        public List<Dvd> GetByRating(string ratingValue)
        {
            List<Dvd> _dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdADO"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchByRating";
                cmd.Parameters.AddWithValue("@RatingValue", ratingValue);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.Title = dr["Title"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["ReleaseYear"] != DBNull.Value)
                        {
                            currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        }

                        if (dr["DirectorName"] != DBNull.Value)
                        {
                            currentRow.DirectorName = dr["DirectorName"].ToString();
                        }

                        if (dr["RatingValue"] != DBNull.Value)
                        {
                            currentRow.RatingValue = dr["RatingValue"].ToString();
                        }
                        currentRow.DvdId = (int)dr["DvdId"];
                        _dvds.Add(currentRow);

                    }
                }


            }
            return _dvds;
        }

        public List<Dvd> GetByReleaseYear(int releaseYear)
        {
            List<Dvd> _dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdADO"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchByYear";
                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.Title = dr["Title"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["ReleaseYear"] != DBNull.Value)
                        {
                            currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        }

                        if (dr["DirectorName"] != DBNull.Value)
                        {
                            currentRow.DirectorName = dr["DirectorName"].ToString();
                        }

                        if (dr["RatingValue"] != DBNull.Value)
                        {
                            currentRow.RatingValue = dr["RatingValue"].ToString();
                        }
                        currentRow.DvdId = (int)dr["DvdId"];
                        _dvds.Add(currentRow);

                    }
                }


            }
            return _dvds;
        }

        public List<Dvd> GetByTitle(string title)
        {
            List<Dvd> _dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdADO"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchByTitle";
                cmd.Parameters.AddWithValue("@title", title);

                conn.Open();
                cmd.ExecuteNonQuery();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.Title = dr["Title"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["ReleaseYear"] != DBNull.Value)
                        {
                            currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        }

                        if (dr["DirectorName"] != DBNull.Value)
                        {
                            currentRow.DirectorName = dr["DirectorName"].ToString();
                        }

                        if (dr["RatingValue"] != DBNull.Value)
                        {
                            currentRow.RatingValue = dr["RatingValue"].ToString();
                        }
                        currentRow.DvdId = (int)dr["DvdId"];
                        _dvds.Add(currentRow);

                    }
                }

            }
            return _dvds;
        }

        public void Update(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdADO"].ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDvd";

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@RatingValue", dvd.RatingValue);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public List<Dvd> GetAll()
        {
            List<Dvd> _dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAll";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.DvdId = (int)dr["DvdId"];

                        currentRow.Title = dr["Title"].ToString();
                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["ReleaseYear"] != DBNull.Value)
                        {
                            currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        }

                        if (dr["DirectorId"] != DBNull.Value)
                        {
                            currentRow.DirectorName = dr["DirectorName"].ToString();
                        }

                        if (dr["RatingId"] != DBNull.Value)
                        {
                            currentRow.RatingValue = dr["RatingValue"].ToString();
                        }
                        _dvds.Add(currentRow);
                    }
                }
            }
            return _dvds;
        }
    }
}
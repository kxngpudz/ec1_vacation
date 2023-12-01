using Project_2._0.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_2._0
{
    public class Helpers
    {
        public List<Destinations> GetDestinationsFromDatabase()
        {
            List<Destinations> destinations = new List<Destinations>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT Id, Title, Description, Price, ImageURL FROM Destinations WHERE isDeleted = 0", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Destinations destination = new Destinations
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetInt32(reader.GetOrdinal("Price")),
                                ImageURL = reader.GetString(reader.GetOrdinal("ImageURL"))
                            };

                            destinations.Add(destination);
                        }
                    }
                }
            }

            return destinations;
        }

        public List<FlightsDetails> GetFlightsFromDatabase()
        {
            List<FlightsDetails> Flights = new List<FlightsDetails>();

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT Id, DestinationName, Time, LeavingFrom, (SELECT Title FROM Destinations WHERE Id = DestinationId) AS Destination FROM Flights", con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FlightsDetails flight = new FlightsDetails
                                {
                                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                    DestinationName = reader.IsDBNull(reader.GetOrdinal("DestinationName")) ? null : reader.GetString(reader.GetOrdinal("DestinationName")),
                                    Time = reader.IsDBNull(reader.GetOrdinal("Time")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Time")),
                                    Destination = reader.IsDBNull(reader.GetOrdinal("Destination")) ? null : reader.GetString(reader.GetOrdinal("Destination")),
                                    LeavingFrom = reader.IsDBNull(reader.GetOrdinal("LeavingFrom")) ? null : reader.GetString(reader.GetOrdinal("LeavingFrom"))
                                };

                                Flights.Add(flight);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving flights: {ex.Message}");
            }

            return Flights;
        }


    }
}
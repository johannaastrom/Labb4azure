﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace Labb4azure
{
    public class Program
    {
        private const string EndpointUrl = "https://labb4server.documents.azure.com:443/";
        private const string PrimaryKey = "VLUD2P8PI5IRSZFJhgTpUWnPa8N1iFksQbExla4bRHLb661nhdiTyRLXIVv9WzJ2e5jTQzdrFtyjy8CB1HYPkA==";
        private DocumentClient client;

        public const string connectionString = @""; //TODO

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your email adress: ");
            string email = Console.ReadLine();
            Console.WriteLine("Upload your profile picture: ");
            string picture = Console.ReadLine();

            SqlConnection conn = new SqlConnection(connectionString);
            string emailQuery = "INSERT INTO user (email) VALUES ('" + email + "')";
            SqlCommand command = new SqlCommand(emailQuery, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex) { }

            string reviewQueueQuery = "INSERT INTO reviewQueue (picture) VALUES ('" + picture + "')";
            SqlCommand command2 = new SqlCommand(reviewQueueQuery, conn);
            try
            {
                conn.Open();
                command2.ExecuteNonQuery();
            }
            catch (SqlException ex) { }

            //ska föras över till från reviewQueue till approvedPicture efter att den blivit godkänd????

            //string approvedPictureQuery = "INSERT INTO reviewQueue (picture) VALUES ('" + picture + "')"; 
            //SqlCommand command3 = new SqlCommand(approvedPictureQuery, conn);
            //try
            //{
            //    conn.Open();
            //    command3.ExecuteNonQuery();
            //}
            //catch (SqlException ex) { }
        }











        //    try
        //    {
        //        Program p = new Program();
        //        p.GetStartedDemo().Wait();
        //    }
        //    catch (DocumentClientException de)
        //    {
        //        Exception baseException = de.GetBaseException();
        //        Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        Exception baseException = e.GetBaseException();
        //        Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
        //    }
        //    finally
        //    {
        //        Console.WriteLine("End of demo, press any key to exit.");
        //        Console.ReadKey();
        //    }
        //}

        //private async Task GetStartedDemo()
        //{
        //    this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
        //    await this.client.CreateDatabaseIfNotExistsAsync(new Database { Id = "User" });
        //}

        //private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        //{
        //    Console.WriteLine(format, args);
        //    Console.WriteLine("Press any key to continue ...");
        //    Console.ReadKey();
        //}
    }
}
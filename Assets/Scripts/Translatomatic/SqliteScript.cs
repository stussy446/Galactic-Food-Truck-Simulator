using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using static UnityEngine.Rendering.DebugUI;





public static class SqliteScript 
{
    //path where Unity stores database file on build
    private static string dbURI = "URI=file:" + Application.streamingAssetsPath + "/LinesDB.db";

    //Returns the line of text from a specified table with a given lineID
    //Function specific to Translator. Do not use for anything else
    public static string GetLine(int tableID, int lineID)
    {
        
        string langString = GetLine("TableName", "LangIndex", "LangID", tableID);

        return GetLine(langString, "OrderTable", "LineID", lineID);

    }

    //Returns line of text from specified table at specified index
    /*For general use:
     * Column = name of column in the table
     * Table = name of the table to query
     * id = column used for matching criteria
     * index = int index of id for matching
     * 
     * */
    public static string GetLine(string column, string table, string id, int index)
    {
        IDbConnection dbConnection = new SqliteConnection(dbURI);
        dbConnection.Open();
        string query = $"SELECT {column} FROM {table} WHERE {id} = {index};";
        IDbCommand command = dbConnection.CreateCommand();
        string returnString;

        command.CommandText = query;
        IDataReader reader = command.ExecuteReader();
        reader.Read();
        returnString = reader.GetString(0);
        reader.Close();
        dbConnection.Close();
        return returnString;
    }

    //Returns size of "table" based on the number of non null elements in "column"
    //For general use
    public static int GetSize(string column, string table)
    {
        IDbConnection dbConnection = new SqliteConnection(dbURI);
        dbConnection.Open();
        string query = $"SELECT COUNT({column}) FROM {table};";
        IDbCommand command = dbConnection.CreateCommand();
        int returnCount;

        command.CommandText = query;
        IDataReader reader = command.ExecuteReader();
        reader.Read();
        returnCount = reader.GetInt32(0);
        reader.Close();
        dbConnection.Close();
        return returnCount;
    }

    
}
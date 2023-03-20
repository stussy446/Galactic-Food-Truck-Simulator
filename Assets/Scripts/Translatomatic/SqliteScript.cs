using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using static UnityEngine.Rendering.DebugUI;


//TODO:
// - Overload GetLine to take a string directly instead of an int for the table name
// - Merge GetLanguageSise and get LineSize into 1 function
// - Rework functions to take table names as input parameters instead of hardcoding


public static class SqliteScript 
{
    private static string dbURI = "URI=file:" + Application.dataPath + "/LinesDB.db";

    //Returns the line of text from a specified table with a given lineID
    public static string GetLine(int tableID, int lineID)
    {
        IDbConnection dbConnection = new SqliteConnection(dbURI);
        dbConnection.Open();
        string query = $"SELECT TableName FROM LangIndex WHERE LangID = {tableID};";
        IDbCommand command = dbConnection.CreateCommand();
        string returnString;

        command.CommandText = query;
        IDataReader reader = command.ExecuteReader();
        reader.Read();
        string language = reader.GetString(0);
        reader.Close();

        query = $"SELECT {language} FROM OrderTable WHERE LineID = {lineID};";
        command.CommandText = query;
        reader = command.ExecuteReader();
        reader.Read();
        returnString = reader.GetString(0);
        reader.Close();
        dbConnection.Close();
        return returnString;

    }

    //Returns the total number of unique language tables in the database
    public static int GetLanguageSize()
    {
        IDbConnection dbConnection = new SqliteConnection(dbURI);
        dbConnection.Open();
        string query = "SELECT COUNT(LangID) FROM LangIndex;";
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

    //Returns the total number of lines in a language table
    public static int GetLineSize()
    {
        IDbConnection dbConnection = new SqliteConnection(dbURI);
        dbConnection.Open();
        string query = "SELECT COUNT(LineID) FROM OrderTable;";
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
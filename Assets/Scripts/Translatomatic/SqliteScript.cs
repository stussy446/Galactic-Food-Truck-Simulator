using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using static UnityEngine.Rendering.DebugUI;

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

        query = $"SELECT LineValue FROM {language} WHERE LineID = {lineID};";
        command.CommandText = query;
        reader = command.ExecuteReader();
        reader.Read();
        returnString = reader.GetString(0);
        reader.Close();
        dbConnection.Close();
        return returnString;

    }

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

    public static int GetLineSize()
    {
        IDbConnection dbConnection = new SqliteConnection(dbURI);
        dbConnection.Open();
        string query = "SELECT COUNT(LineID) FROM English;";
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
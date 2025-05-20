
using MongoDB.Bson;
using Hama.Log.Dto;

public class LogResultDTO
{
    public ObjectId _id { get; set; }
    public DateTime Timestamp { get; set; }
    public string Level { get; set; }
    public string MessageTemplate { get; set; }
    public string RenderedMessage { get; set; }
    public Properties Properties { get; set; }
    public string UtcTimestamp { get; set; }
}

public class Properties
{
    public string logMessage { get; set; }
    public Logdto logDto { get; set; }
}

public class Logdto
{
    public string _typeTag { get; set; }
    public ClientResult Client { get; set; }
    public string CrudType { get; set; }
    public UserInformationResult UserInformation { get; set; }
    public object Entity { get; set; }
    public string logMessage { get; set; }
}

public class ClientResult :Client
{
    public string _typeTag { get; set; }
   
}

public class UserInformationResult : UserInformation
{
    public string _typeTag { get; set; }
}



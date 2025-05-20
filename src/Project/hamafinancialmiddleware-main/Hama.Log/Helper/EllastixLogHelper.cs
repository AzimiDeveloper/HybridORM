using Hama.Log.Dto;
using Serilog;

namespace Hama.Log.Helper;

public class EllastixLogHelper
{

    public EllastixLogHelper()
    {
        Serilog.Log.Logger = new LoggerConfiguration()
            .WriteTo.MongoDB(ClientInformation.MongoDBConnection + ClientInformation.MongoDBDataBase+ "?authSource=admin", collectionName: "CrudDB")
            .MinimumLevel.Debug()
            .CreateLogger();
    }
    private static void SetToExceptionDatabase()
    {
        Serilog.Log.Logger = new LoggerConfiguration()
         .WriteTo.MongoDB(ClientInformation.MongoDBConnection + ClientInformation.MongoDBDataBase + "?authSource=admin", collectionName: "ExceptionDB", batchPostingLimit: 88888)
         .CreateLogger();
    }
    private static void SetToExceptionHandleDatabase()
    {
        Serilog.Log.Logger = new LoggerConfiguration()
         .WriteTo.MongoDB(ClientInformation.MongoDBConnection + ClientInformation.MongoDBDataBase + "?authSource=admin", collectionName: "ExceptionHandleDB")
         .CreateLogger();
    }

    static Semaphore semaphore = new Semaphore(1, 1000000);
    public static void CommitLogCash(List<LogDto> LogDto)
    {

        try
        {
            if (ClientInformation.MongoDBIsOnline)
            {
                semaphore.WaitOne();

                Serilog.Log.Logger = new LoggerConfiguration()
                 .WriteTo.MongoDB(ClientInformation.MongoDBConnection + ClientInformation.MongoDBDataBase+ "?authSource=admin", collectionName: "CrudDB")
                 .MinimumLevel.Debug()
                 .CreateLogger();
                foreach (LogDto logDto in LogDto)
                {
                    Serilog.Log.Information("{@logMessage}, Detail: {@logDto}", logDto.logMessage, logDto);
                }
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            Serilog.Log.CloseAndFlush(); // ensure all logs written before app exits
            semaphore.Release();
        }
    }

    public static void CreateExceptionLog(LogDto logDto, Exception Exception, string PersianDateTime)
    {
        logDto.Client.PersianDateTime = PersianDateTime;

        SetToExceptionDatabase();
        Serilog.Log.Error("Exeption {ExceptionMessage} , {@Exception} , {@logDto}   :", Exception.Message, Exception, logDto);
        // Serilog.Log.CloseAndFlush();
    }


}
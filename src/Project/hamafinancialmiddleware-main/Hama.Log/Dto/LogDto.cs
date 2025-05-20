using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Hama.Log.Dto;

public class LogDto
{
    public Client Client { get; set; } = new Client();
    public CrudType? CrudType { get; set; }
    public UserInformation? UserInformation { get; set; } = new UserInformation();
    public dynamic Entity { get; set; }
    public string logMessage { get; set; }

}

public class UserInformation
{
    public Guid LogCompanyCode { get; set; } = ClientInformation.CompanyCode;
    public string LogCompanyName { get; set; } = ClientInformation.CompanyName;
    public Guid LogParentCompanyCode { get; set; } = ClientInformation.ParentCompanyCode;
    public string LogParentCompanyName { get; set; } = ClientInformation.ParentCompanyName;
    public Guid LogFinancialPeriodCode { get; set; } = ClientInformation.FinancialPeriodCode;
    public string LogFinancialPeriodName { get; set; } = ClientInformation.FinancialPeriodName;
    public Guid? LogUserCode { get; set; }
    public string LogUserName { get; set; }
    public Guid? LogCustomerInformationFileCode { get; set; }
    public string LogCustomerInformationFileName { get; set; }
    public string LogCustomerInformationFileFamily { get; set; }

    public UserInformation()
    {
        LogUserName = ClientInformation.LogUserName;
        LogUserCode = ClientInformation.LogUserCode;
        LogCustomerInformationFileCode = ClientInformation.LogCustomerInformationFileCode;
        LogCustomerInformationFileName = ClientInformation.LogCustomerInformationFileName;
        LogCustomerInformationFileFamily = ClientInformation.LogCustomerInformationFileFamily;

    }
}
public class Client
{
    public string? IP { get; set; } = GetIP();
    public string? ComputerName { get; set; } = ClientInformation.ComputerName;
    public string? DomainName { get; set; } = ClientInformation.DomainName;
    public string? BrowserName { get; set; }
    public string? MacAddress { get; set; } = GetNetworkNameAndMACAddress();
    public string? PersianDateTime { get; set; } 
    public string? FormName { get; set; } = ClientInformation.FormName;
    public string? FormMethod { get; set; } = ClientInformation.FormMethod;
    public string? DataBaseVersion { get; set; } = ClientInformation.DataBaseVersion;
    public string? ApplicationVersion { get; set; } = ClientInformation.ApplicationVersion;
    public string? ServerKey { get; set; } = ClientInformation.ServerKey;

    public static string GetIP()
    {
        try {
            string hostName = Dns.GetHostName();
            var myIPs = Dns.GetHostByName(hostName).AddressList;
            var myIP = myIPs.Where(a => a.ToString().Length > 10).FirstOrDefault().ToString();
            return myIP;
        } catch
        {
            return string.Empty;
        }

    }
    public static string GetNetworkNameAndMACAddress()
    {
        StringBuilder sb = new StringBuilder();

        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface adapter in nics)
        {
            IPInterfaceProperties properties = adapter.GetIPProperties();
            string mac = adapter.GetPhysicalAddress().ToString();
            sb.AppendLine($"AdpatorName : {adapter.Name}, Mac : {mac}");
        }
        return sb.ToString();
    }
}

public static class ClientInformation
{
    public static Guid CompanyCode { get; set; }
    public static Guid ParentCompanyCode { get; set; }
    public static string CompanyName { get; set; }
    public static string ParentCompanyName { get; set; }
    public static Guid FinancialPeriodCode { get; set; }
    public static string FinancialPeriodName { get; set; }
    //public static UsersUser User { get; set; }
    public static string ComputerName { get; set; }
    public static string DomainName { get; set; }
    public static string FormName { get; set; } = "";
    public static string FormMethod { get; set; } = "";
    public static bool MongoDBIsOnline { get; set; } = false;
    public static string MongoDBConnection { get; set; }
    public static string MongoDBDataBase { get; set; }
    public static string DataBaseVersion { get; set; }
    public static string ApplicationVersion { get; set; }
    public static string ServerKey { get; set; }
    public static string LogUserName { get; set; }
    public static Guid?  LogUserCode { get; set; }
    public static Guid? LogCustomerInformationFileCode { get; set; }
    public static string LogCustomerInformationFileName { get; set; }
    public static string LogCustomerInformationFileFamily { get; set; }


}

public enum CrudType
{
    Insert = 0,
    Read = 1,
    Edit = 2,
    Delete = 3,
}

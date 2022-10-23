using System.Runtime.Intrinsics.X86;

namespace mail_service;

public static class Constants
{
    /**###############################################
     *               Data Mgmt
     * ##############################################*/
    public static readonly string
        CSV_FILE = "C:\\Users\\imadc\\RiderProjects\\mailing\\mail-service\\data\\Friends.csv";

    public static readonly string FirstName = "first_name";
    public static readonly string LastName = "last_name";
    public static readonly string Email = "email";
    public static readonly string BirthDay = "date_of_birth";

    /**###############################################
     *               Message Mgmt
     * ##############################################*/
    public static readonly string CONFIG_FILE =
        "C:\\Users\\imadc\\RiderProjects\\mailing\\mail-service\\messagingMgmt\\mail.json";

    public static readonly string Info_From = "Info:From";
    public static readonly string Info_Subject = "Info:Subject";
    public static readonly string Reminder_Subject = "Reminder:Subject";
    public static readonly string Info_Body = "Info:Body";
    public static readonly string Smtp_Host = "Smtp:Host";
    public static readonly string Smtp_Port = "Smtp:Port";
    public static readonly string Stmp_User = "Smtp:Username";
    public static readonly string Stmp_Pass = "Smtp:Password";
}
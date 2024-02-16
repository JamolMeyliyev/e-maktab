using e_maktab.BizLogicLayer.HelperServices.JwtToken;

namespace e_maktab;

public class AppSettings
{
    public static AppSettings Instance { get; private set; }
    public JwtOptions JwtOptions { get; set; }
    public static void Init(AppSettings instance)
    {
        Instance = instance;
    }
}
public class JwtOptions
{
    public required string SigningKey { get; set; }
    public required string ValidAudience { get; set; }
    public required string ValidIssuer { get; set; }
    public int ExpiresInMinutes { get; set; }
}

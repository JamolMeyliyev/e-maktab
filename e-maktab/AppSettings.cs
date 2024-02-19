using e_maktab.BizLogicLayer.HelperServices.JwtToken;

namespace e_maktab;

public class AppSettings
{
    public static AppSettings Instance { get; private set; }
    public static void Init(AppSettings instance)
    {
        Instance = instance;
    }
}


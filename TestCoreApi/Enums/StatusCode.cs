using System.ComponentModel;

namespace TestCoreApi.Enums
{
    public enum StatusCode
    {
        [Description("Success")]
        Success = 0,

        //驗證or檢查失敗
        [Description("Data Not Found")]
        DataNotFound = 100,
        [Description("Validation Failed")]
        ValidationFailed = 101,

        //系統or流程錯誤
        [Description("Unknow Error")]
        UnknowError = 9999
    }
}

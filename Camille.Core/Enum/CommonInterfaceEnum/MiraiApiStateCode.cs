using System.ComponentModel;

namespace Camille.Core.Enum.CommonInterfaceEnum;

/// <summary>
/// Mirai通用接口返回的状态码 :"https://docs.mirai.mamoe.net/mirai-api-http/api/API.html#%E7%8A%B6%E6%80%81%E7%A0%81"
/// </summary>
public enum MiraiApiStateCode
{
    [Description("未知状态码")] Unknown,
    
    [Description("成功")] Success = 0,

    [Description("错误的验证秘钥")] IncorrectVerifyKey = 1,

    [Description("指定的Bot不存在")] TheBotNotExist = 2,

    [Description("Session失效或不存在")] SessionInvalidation = 3,

    [Description("Session未认证(未激活)")] SessionNotActivated = 4,

    [Description("发送消息目标不存在(指定对象不存在)")] MsgDestinationNotExist = 5,

    [Description("指定文件不存在，出现于发送本地图片")] SpecifiedFileNotExist = 6,

    [Description("无操作权限，指Bot没有对应操作的限权")] NoOperationPermissions = 10,

    [Description("Bot被禁言，指Bot当前无法向指定群发送消息")]
    TheBotWasBanned = 20,

    [Description("消息过长")] MsgTooLong = 30,

    [Description("错误的访问, 如参数错误等")] BadRequest = 400,
    
    [Description("上传文件出错")] UploadFileError = 500,
}
using Abp.Domain.Services;
using Senparc.NeuChar.MessageHandlers;
using Senparc.Weixin.MP.Entities.Request;
using System.IO;
using System.Threading.Tasks;

namespace WF.RetailCloud.Wechat.Messages.DomainService
{
    public interface IWechatMessageManager : IDomainService
    {
        Task<IMessageHandlerDocument> GetMessageHandlerAsync(Stream inputStream, PostModel postModel, int maxRecordCount = 0);

        Task<CustomMessages> GetCustomMessagesAsyncTest();
    }
}


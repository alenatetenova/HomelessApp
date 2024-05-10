using Homeless.Database.Models;

namespace Homeless.Repositories;

public interface IHomelessMessageRepository
{
    IList<HomelessMessageModel> GetAll();

    IList<DocumentTypeModel> GetAllDocumentTypes();

    IList<NeedTypeModel> GetAllNeedTypes();

    IList<HomelessStateModel> GetAllHomelessStates();

    IList<MessageProcessingStatusModel> GetAllMessageProcessingStatuses();

    HomelessMessageModel Add(HomelessMessageModel homeless);

    HomelessMessageModel GetById(Guid homelessMessageId);

    void Delete(Guid MessageId);
    void Update(HomelessMessageModel homelessMessage);


}
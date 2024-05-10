using Homeless.Database;
using Homeless.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homeless.Repositories
{
    public class HomelessMessageRepository : IHomelessMessageRepository
    {
        private readonly HomelessDbContext _dbContext;

        public HomelessMessageRepository(HomelessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<HomelessMessageModel> GetAll()
        {
            return _dbContext.HomelessMessage.ToList();
        }

        public IList<DocumentTypeModel> GetAllDocumentTypes()
        {
            return _dbContext.DocumentType.ToList();
        }

        public IList<NeedTypeModel> GetAllNeedTypes()
        {
            return _dbContext.NeedType.ToList();
        }

        public IList<HomelessStateModel> GetAllHomelessStates()
        {
            return _dbContext.HomelessState.ToList();
        }

        public IList<MessageProcessingStatusModel> GetAllMessageProcessingStatuses()
        {
            return _dbContext.MessageProcessingStatus.ToList();
        }

        public HomelessMessageModel Add(HomelessMessageModel homelessMessage)
        {
            try
            {
                var newHomelessMessage = _dbContext.HomelessMessage.Add(homelessMessage);
                _dbContext.SaveChanges();

                return newHomelessMessage.Entity;
            }
            catch (Exception ex)
            {
                // Handle exception
                return null;
            }
        }

        public HomelessMessageModel GetById(Guid homelessMessageId)
        {
            return _dbContext.HomelessMessage.FirstOrDefault(h => h.Id == homelessMessageId);
        }

        public void Update(HomelessMessageModel homelessMessage)
        {
            var existingHomelessMessage = _dbContext.HomelessMessage.FirstOrDefault(h => h.Id == homelessMessage.Id);

            if (existingHomelessMessage == null)
                throw new Exception("Homeless message not found");

            // Update properties
            existingHomelessMessage.DateTime = homelessMessage.DateTime;

            existingHomelessMessage.HomelessLocationX = homelessMessage.HomelessLocationX;
            existingHomelessMessage.HomelessLocationY = homelessMessage.HomelessLocationY;

            existingHomelessMessage.HomelessStatusId = homelessMessage.HomelessStatusId;
            existingHomelessMessage.MessageStatusId = homelessMessage.MessageStatusId;

            existingHomelessMessage.HomelessSurname = homelessMessage.HomelessSurname;
            existingHomelessMessage.HomelessName = homelessMessage.HomelessName;
            existingHomelessMessage.HomelessPatronymic = homelessMessage.HomelessPatronymic;
            existingHomelessMessage.HomelessBirthDate = homelessMessage.HomelessBirthDate;
            existingHomelessMessage.HomelessDescription = homelessMessage.HomelessDescription;

            existingHomelessMessage.DocumentType = homelessMessage.DocumentType;
            existingHomelessMessage.DocumentNumber = homelessMessage.DocumentNumber;
            existingHomelessMessage.OtherDocument = homelessMessage.OtherDocument;

            existingHomelessMessage.OtherNeed = homelessMessage.OtherNeed;
            existingHomelessMessage.NeedTypeId = homelessMessage.NeedTypeId;

            _dbContext.SaveChanges();
        }

        public void Delete(Guid messageId)
        {
            var homelessMessage = _dbContext.HomelessMessage.FirstOrDefault(message => message.Id == messageId);

            if (homelessMessage == null)
                throw new Exception("Homeless message not found");

            _dbContext.Remove(homelessMessage);
            _dbContext.SaveChanges();
        }
    }
}
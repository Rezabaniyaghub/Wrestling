using AutoMapper;
using DataAccess;
using DataAccess.Entity;
using Domain.Abstrct;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class WrestlingService : IWrestlingService
    {
        #region [Ctor]
        private readonly IWrestlingRepository _wrestlingRepository;

        private readonly IMapper _mapper;
        public WrestlingService(IWrestlingRepository wrestlingRepository, IMapper mapper)
        {
            _wrestlingRepository = wrestlingRepository;
            _mapper = mapper;
        }
        #endregion


        #region [Methods]
        public WrestlingModel GetById(int id) =>
          _mapper.Map<WrestlingModel>(_wrestlingRepository.GetById(id));


        public List<WrestlingModel> GetAll() =>
              _mapper.Map<List<WrestlingModel>>(_wrestlingRepository.GetAll());


        public (string Message, bool IsSuccess) Insert(WrestlingModel model)
        {
            var entity = _mapper.Map<WrestlingSchool>(model);
            entity.CreatedAt = DateTime.Now;
            return _wrestlingRepository.Insert(entity);
        }


        public (string Message, bool IsSuccess) Update(WrestlingModel model)
        {
            if (model.Id <= 0)
                return ("Id Is Not Fond!", false);
            var result = _wrestlingRepository.Update(_mapper.Map<WrestlingSchool>(model));
            return result;
        }

        public (string Message, bool IsSuccess) Delete(int Id) =>
            _wrestlingRepository.Delete(Id);
        #endregion

    }
}

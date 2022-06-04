using DataAccess.Entity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstrct
{
    public interface IWrestlingService
    {
        (string Message, bool IsSuccess) Insert(WrestlingModel model);
        (string Message, bool IsSuccess) Update(WrestlingModel model);
        (string Message, bool IsSuccess) Delete(int Id);
        List<WrestlingModel> GetAll();
        WrestlingModel GetById(int id);
    }
}

using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IWrestlingRepository
    {
        (string Message, bool IsSuccess) Insert(WrestlingSchool model);
        (string Message, bool IsSuccess) Update(WrestlingSchool model);
        (string Message, bool IsSuccess) Delete(int Id);
        List<WrestlingSchool> GetAll();
        WrestlingSchool GetById(int id);
    }
    public class WrestlingRepository : IWrestlingRepository
    {
        private readonly AppDbContext _appDbContext;
        public WrestlingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public WrestlingSchool GetById(int id)
        {
            return _appDbContext.WrestlingSchools.FirstOrDefault(x => x.Id == id);
        }

        public (string Message, bool IsSuccess) Delete(int Id)
        {
            try
            {
                var old = _appDbContext.WrestlingSchools.FirstOrDefault(x => x.Id == Id);
                if (old != null)
                {
                    _appDbContext.WrestlingSchools.Remove(old);
                    var SaveResult = _appDbContext.SaveChanges();
                    if (SaveResult > 0)
                        return ("Success Don!", true);
                }
                else
                {
                    return ("Entity Not Fond!", false);
                }

            }
            catch (Exception ex)
            {

            }
            return ("Faild!", false);
        }

        public List<WrestlingSchool> GetAll()
        {
            return _appDbContext.WrestlingSchools.ToList();
        }

        public (string Message, bool IsSuccess) Insert(WrestlingSchool model)
        {
            try
            {
                _appDbContext.WrestlingSchools.Add(model);
                var SaveResult = _appDbContext.SaveChanges();
                if (SaveResult > 0)
                    return ("Success Don!", true);
            }
            catch (Exception ex)
            {

            }
            return ("Faild!", false);
        }

        public (string Message, bool IsSuccess) Update(WrestlingSchool model)
        {
            try
            {
                var old = _appDbContext.WrestlingSchools.FirstOrDefault(x => x.Id == model.Id);
                if (old != null)
                {
                    old.Id = model.Id;
                    old.FirsName = model.FirsName;
                    old.LastName = model.LastName;
                    old.Tuition = model.Tuition;
                    old.NationalCode = model.NationalCode;
                    old.PhoneNumber = model.PhoneNumber;
                    old.DateOfBirth = model.DateOfBirth;
                    var SaveResult = _appDbContext.SaveChanges();
                    if (SaveResult > 0)
                        return ("Success Don!", true);
                }
                else
                {
                    return ("Entity Not Fond!", false);
                }

            }
            catch (Exception ex)
            {

            }
            return ("Faild!", false);
        }
    }
}

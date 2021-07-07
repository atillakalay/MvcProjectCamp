using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AbilityManager : IAbilityService
    {
        private IAbilityDal _abilityDal;

        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }

        public List<Ability> GetAll()
        {
            return _abilityDal.List();
        }
    }
}

using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using IReferenceService = SignalR.BusinessLayer.Abstract.IReferenceService;

namespace SignalR.BusinessLayer.Concrete
{
    public class ReferenceManager : IReferenceService
    {
        private readonly IReferenceDal _referenceDal;

        public ReferenceManager(IReferenceDal referenceDal)
        {
            _referenceDal = referenceDal;
        }

        public void TAdd(Reference entity)
        {
            _referenceDal.Add(entity);
        }

        public void TDelete(Reference entity)
        {
            _referenceDal.Delete(entity);
        }

        public Reference TGetById(int id)
        {
            return _referenceDal.GetById(id);
        }

        public List<Reference> TGetListAll()
        {
            return _referenceDal.GetListAll();
        }

        public void TUpdate(Reference entity)
        {
            _referenceDal.Update(entity);
        }
    }
}

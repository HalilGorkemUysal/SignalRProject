using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IMenuTableDal : IGenericDal<MenuTable>
    {
        int MenuTableCount();
        void ChangeMenuTableStatusToTrue(int id); // Masayı dolu yap
        void ChangeMenuTableStatusToFalse(int id);// Masayı boş yap
    }
}

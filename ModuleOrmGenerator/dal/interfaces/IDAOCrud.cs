using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleOrmGenerator.dal.interfaces
{
    interface IDAOCrud<E, ID>
    {

        void create(E obj);
        void delete(E obj);
        List<E> findAll();
        E findById(ID id);

    }
}

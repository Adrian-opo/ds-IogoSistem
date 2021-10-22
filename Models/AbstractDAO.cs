using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IogoSistem.Database;
using IogoSistem.Interfaces;

namespace IogoSistem.Models
{
    /// <summary>
    ///     Interface (contrato) para classes DAO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class AbstractDAO<T>
    {
        protected Conexao conn = new Conexao();

        public virtual void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(T t)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> List()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}

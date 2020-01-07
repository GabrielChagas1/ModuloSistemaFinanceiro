using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DAO
{
    public interface Obrigatorio<Classe>
    {
        //método para criar
        void Create(Classe obj);
        //método para deletar
        void Delete(Classe obj);
        //método para atualizar
        void Update(Classe obj);
        //método para recuperar um registro
        bool Find(Classe obj);
        //método para recuperar todos os registros
        List<Classe> FindAll();
    }
}

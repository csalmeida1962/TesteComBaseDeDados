using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class DropCreateBD : DropCreateDatabaseAlways<ContextoBD>
    {
        protected override void Seed(ContextoBD bd)
        {
            criarBaseDados(bd);
            base.Seed(bd);
        }

        private void criarBaseDados(ContextoBD bd)
        {
            #region Empreagdo

            // Emmpregados
                Produto pro = new Produto();
            pro.Descricao = "Produto 1";
            #endregion

            bd.SaveChanges();
        }


    }
    class CreateBDIfNotExist : CreateDatabaseIfNotExists<ContextoBD>
    {
        protected override void Seed(ContextoBD bd)
        {
            criarBaseDados(bd);
            base.Seed(bd);
        }
        private void criarBaseDados(ContextoBD bd)
        {
            #region Empreagdo
            // Emmpregados
            Produto pro = new Produto();
            pro.Descricao = "Produto 1";

            // Emmpregados
            //Empregado emp = new Empregado();
            //emp.Nome = "Carlos ";
            //emp.Perfil = "Admin";
            #endregion

            bd.SaveChanges();
        }

    }
    class DropCreateIfChange : DropCreateDatabaseIfModelChanges<ContextoBD>
    {
    }
}

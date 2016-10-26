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
            InicializaBD.criarRegistosIniciais(bd);   
            base.Seed(bd);
        }


    }
    class CreateBDIfNotExist : CreateDatabaseIfNotExists<ContextoBD>
    {
        protected override void Seed(ContextoBD bd)
        {
            InicializaBD.criarRegistosIniciais(bd);
            base.Seed(bd);
        }

    }
    class DropCreateIfChange : DropCreateDatabaseIfModelChanges<ContextoBD>
    {
    }
    public class InicializaBD
    {
        public static void criarRegistosIniciais(ContextoBD bd)
        {
            try
            {

                //Produto p = new Produto();
                //p.Descricao = "Produto 1";
                //p.PrVenda = 14.00M;
                //bd.Produtos.Add(p);

                Categoria c = new Categoria();
                c.Descricao = "Descricao 1";
                bd.Categorias.Add(c);
                bd.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
 

        }

    }
}


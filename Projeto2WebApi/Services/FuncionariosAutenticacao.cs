using Projeto2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto2WebApi.Services
{
    public class FuncionariosAutenticacao
    {
        public static bool Login(string login, string senha)
        {

            using (meuBanco db = new meuBanco())
            {
                return db.funcionarios.Any(user => user.Login.Equals(login, StringComparison.OrdinalIgnoreCase) && user.Senha == senha);
            }

        }
    }
}
using Jean_P2_AP2.DAL;
using Jean_P2_AP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Jean_P2_AP2.BLL
{
    public class ClientesBLL
    {
        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes cliente;

            try
            {
                cliente = contexto.Clientes
                    .Include(c => c.Ventas)
                    .Where(c => c.ClienteID == id)
                    .SingleOrDefault();
            }
            catch
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return cliente;
        }

        public static List<Clientes> ObtenerLista(Expression<Func<Clientes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Clientes> clientes = new List<Clientes>();

            try
            {
                clientes = contexto.Clientes.Where(criterio).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return clientes;
        }
    }
}

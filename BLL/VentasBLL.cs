using Jean_P2_AP2.DAL;
using Jean_P2_AP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jean_P2_AP2.BLL
{
    public class VentasBLL
    {
        public static Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas venta;

            try
            {
                venta = contexto.Ventas
                    .Where(v => v.VentaID == id)
                    .SingleOrDefault();

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return venta;
        }

        public static List<Ventas> ObtenerLista(Expression<Func<Ventas, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Ventas> ventas = new List<Ventas>();

            try
            {
                ventas = contexto.Ventas.Where(criterio).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ventas;
        }
    }
}

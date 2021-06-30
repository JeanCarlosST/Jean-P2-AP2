using Jean_P2_AP2.DAL;
using Jean_P2_AP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jean_P2_AP2.BLL
{
    public class VentasBLL
    {
        public static bool Guardar(Ventas venta)
        {
            if (!Existe(venta.VentaID))
                return Insertar(venta);
            else
                return Modificar(venta);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                found = contexto.Ventas.Any(v => v.VentaID == id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return found;
        }

        private static bool Insertar(Ventas venta)
        {
            Contexto contexto = new Contexto();
            bool insertado = false;

            try
            {
                contexto.Ventas.Add(venta);
                insertado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return insertado;
        }

        public static bool Modificar(Ventas venta)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                contexto.Entry(venta).State = EntityState.Modified;
                found = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return found;
        }

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

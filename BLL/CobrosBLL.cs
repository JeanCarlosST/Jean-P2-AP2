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
    public class CobrosBLL
    {
        public static bool Guardar(Cobros cobro)
        {
            if (!Existe(cobro.CobroID))
                return Insertar(cobro);
            else
                return Modificar(cobro);
        }

        private static bool Insertar(Cobros cobro)
        {
            Contexto contexto = new Contexto();
            bool insertado = false;

            try
            {
                contexto.Cobros.Add(cobro);

                List<CobrosDetalle> detalles = cobro.Detalle;
                foreach (CobrosDetalle d in detalles)
                {
                    Ventas venta = contexto.Ventas.Find(d.VentaID);
                    venta.Balance -= d.Cobrado;
                    contexto.Entry(venta).State = EntityState.Modified;
                }

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

        public static bool Modificar(Cobros cobro)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                List<CobrosDetalle> viejosDetalles = Buscar(cobro.CobroID).Detalle;
                foreach (CobrosDetalle d in viejosDetalles)
                {
                    Ventas venta = contexto.Ventas.Find(d.VentaID);
                    venta.Balance += d.Cobrado;
                    contexto.Entry(venta).State = EntityState.Modified;
                }

                contexto.Database.ExecuteSqlRaw($"delete from CobrosDetalle where CobroID = {cobro.CobroID}");
                foreach (var anterior in cobro.Detalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }

                List<CobrosDetalle> nuevosDetalles = cobro.Detalle;
                foreach (CobrosDetalle d in nuevosDetalles)
                {
                    Ventas venta = contexto.Ventas.Find(d.VentaID);
                    venta.Balance -= d.Cobrado;
                    contexto.Entry(venta).State = EntityState.Modified;
                }

                contexto.Entry(cobro).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                var cobro = Buscar(id);

                if (cobro != null)
                {
                    List<CobrosDetalle> viejosDetalles = Buscar(cobro.CobroID).Detalle;
                    foreach (CobrosDetalle d in viejosDetalles)
                    {
                        Ventas venta = contexto.Ventas.Find(d.VentaID);
                        venta.Balance += d.Cobrado;
                        contexto.Entry(venta).State = EntityState.Modified;
                    }

                    contexto.Cobros.Remove(cobro);
                    found = contexto.SaveChanges() > 0;
                }

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

        public static Cobros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cobros cobro;

            try
            {
                cobro = contexto.Cobros
                    .Include(c => c.Detalle)
                    .Where(c => c.CobroID == id)
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

            return cobro;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                found = contexto.Cobros.Any(c => c.CobroID == id);

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

        public static List<Cobros> ObtenerLista(Expression<Func<Cobros, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Cobros> cobros = new List<Cobros>();

            try
            {
                cobros = contexto.Cobros.Where(criterio)
                    .Include(c => c.Detalle)
                    .ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return cobros;
        }
    }
}

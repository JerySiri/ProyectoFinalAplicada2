using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinalAplicada2.Models;
using ProyectoFinalAplicada2.DAL;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada2.BLL
{
    public class RankingUsuariosBLL
    {
        public Contexto Contexto;

        public RankingUsuariosBLL(Contexto contexto)
        {
            Contexto = contexto;
        }
      
        public bool Existe(int id)
        {
            bool encontrado = false;

            try
            {
                encontrado = Contexto.RankingUsuarios.Any(e => e.id == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Contexto.Dispose();
            }

            return encontrado;
        }
        
        public bool Guardar(RankingUsuarios rankingUsuario)
        {
            bool paso = false;

            try
            {
                Contexto.RankingUsuarios.Add(rankingUsuario);
                paso = Contexto.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                string mensaje = e.ToString();
                throw;
            }
            finally
            {
                //Contexto.Dispose();
            }

            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                //buscar la entidad que se desea eliminar
                var rankingUsuario = Contexto.RankingUsuarios.Find(id);

                if (rankingUsuario != null)
                {
                    Contexto.RankingUsuarios.Remove(rankingUsuario);//remover la entidad
                    paso = Contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Contexto.Dispose();
            }

            return paso;
        }

        public List<RankingUsuarios> GetList(Expression<Func<RankingUsuarios, bool>> criterio)
        {
            List<RankingUsuarios> lista = new List<RankingUsuarios>();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = Contexto.RankingUsuarios.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Contexto.Dispose();
            }
            return lista;
        }
        public List<RankingUsuarios> ObtenerListaRankingOrganizada()
        {
            List<RankingUsuarios> ListaRanking = new List<RankingUsuarios>();
            try
            {
                var Consulta = from C in Contexto.RankingUsuarios
                               orderby C.puntos descending
                               select new RankingUsuarios()
                               {
                                   id = C.id,
                                   Nombre = C.Nombre,
                                   puntos = C.puntos,
                                   tiempo = C.tiempo

                               };

                ListaRanking = Consulta.ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
               // Contexto.Dispose();
            }

            return ListaRanking;
        }


    }
}

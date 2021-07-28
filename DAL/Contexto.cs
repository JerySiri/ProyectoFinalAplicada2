using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAplicada2.Models;
using System.Threading.Tasks;

namespace ProyectoFinalAplicada2.DAL
{
    public class Contexto : IdentityDbContext
    {

        public DbSet<RankingUsuarios> RankingUsuarios { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

    }
}

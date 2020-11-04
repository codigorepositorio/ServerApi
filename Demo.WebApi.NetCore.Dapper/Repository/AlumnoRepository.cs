using Dapper;
using Demo.WebApi.NetCore.Dapper.Interfaz;
using Demo.WebApi.NetCore.Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.Dapper.Repository
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly IDbConnection dbConection;
        public AlumnoRepository(IConfiguration configuration) =>        
            dbConection = new SqlConnection(configuration.GetConnectionString("cn-dapper"));                
        public async Task<Alumno> Create(Alumno alumno)
        {
            var sql = $"Insert into Alumno (Nombres,ExamenParcial,ExamenTrabajo,ExamenFinal,PromedioFinal) values(@Nombres,@ExamenParcial,@ExamenTrabajo,@ExamenFinal,@PromedioFinal);" +
            "Select CAST(SCOPE_IDENTITY() AS INT)";

            var queryResult = await dbConection.QueryAsync<int>(sql, alumno);

            alumno.AlumnoID = queryResult.FirstOrDefault();

            return alumno;
        }

      }
}

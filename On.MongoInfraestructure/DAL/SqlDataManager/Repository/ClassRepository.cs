using Dapper;
using Domain_Application.DTO.SqlDTO;
using Domain_Application.Models.SqlDbModels;
using Microsoft.Extensions.Configuration;
using On.MongoMigrations.DAL.Configs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UserDomain.Interfaces.Repositories;

namespace UserDAL.Repositories
{
    public class ClassRepository : IClassRepository
    {

        public ClassRepository()
        {

        }

        public IList<ClassDTO> GetClassByIdSchool(int schoolId)
        {

            IList<ClassDTO> GetClassByIdSchool = new List<ClassDTO>();
            var filter = "SELECT idClass as Id, idShiftType as shiftTypeId FROM dbo.tblClass (NOLOCK) WHERE idSchool = @idSchool AND idGrade = 1 OR idGrade > 12 ;";

            using (var connection = new SqlConnection(SqlSettingsConfig.UserConnectionString))
            {
                try
                {
                    connection.Open();
                    GetClassByIdSchool = connection.Query<ClassDTO>(filter, new { idSchool = schoolId }).ToList();
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    connection.Close();
                }

                return GetClassByIdSchool;
            }
        }


    }
}
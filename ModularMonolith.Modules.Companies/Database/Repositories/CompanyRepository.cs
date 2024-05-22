using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Entities;
using ModularMonolith.Framework.Database;
using ModularMonolith.Modules.Companies.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Companies.Database.Repositories;

public class CompanyRepository : GenericRepository<Company, int>, ICompanyRepository
{
    public CompanyRepository(CompanyDbContext context) : base(context)
    {

    }
    async Task<IReadOnlyCollection<Company>> ICompanyRepository.GetCompanies()
    {
        //TODO: refactor to use EF Core
        var companies = new List<Company>();

        using (var connection = new SqlConnection(Context.Database.GetConnectionString()))
        {
            await connection.OpenAsync();

            using (var command = new SqlCommand("SELECT * FROM Companies", connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var company = new Company();

                        var idColumnIndex = reader.GetOrdinal("Id");
                        if (idColumnIndex >= 0)
                        {
                            company.Id = reader.GetInt32(idColumnIndex);
                        }

                        var nameColumnIndex = reader.GetOrdinal("Name");
                        if (nameColumnIndex >= 0)
                        {
                            company.Name = reader.IsDBNull(nameColumnIndex) ? null : reader.GetString(nameColumnIndex);
                        }

                        companies.Add(company);
                    }
                }
            }
        }

        return companies;
    }

    async Task<Company?> ICompanyRepository.GetCompany(int id, CancellationToken cancellationToken)
    {
        //TODO: refactor to use EF Core
        Company company = null;

        using (var connection = new SqlConnection(Context.Database.GetConnectionString()))
        {
            await connection.OpenAsync(cancellationToken);

            using (var command = new SqlCommand("SELECT * FROM Companies WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    if (await reader.ReadAsync(cancellationToken))
                    {
                        company = new Company();

                        var idColumnIndex = reader.GetOrdinal("Id");
                        if (idColumnIndex >= 0)
                        {
                            company.Id = reader.GetInt32(idColumnIndex);
                        }

                        var nameColumnIndex = reader.GetOrdinal("Name");
                        if (nameColumnIndex >= 0)
                        {
                            company.Name = reader.IsDBNull(nameColumnIndex) ? null : reader.GetString(nameColumnIndex);
                        }
                    }
                }
            }

            if (company != null)
            {
                using (var command = new SqlCommand("SELECT * FROM Employees WHERE CompanyId = @CompanyId", connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", id);

                    using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                    {
                        company.Employees = new List<Employee>();

                        while (await reader.ReadAsync(cancellationToken))
                        {
                            var employee = new Employee();

                            var idColumnIndex = reader.GetOrdinal("Id");
                            if (idColumnIndex >= 0)
                            {
                                employee.Id = reader.GetInt32(idColumnIndex);
                            }

                            var nameColumnIndex = reader.GetOrdinal("Name");
                            if (nameColumnIndex >= 0)
                            {
                                employee.Name = reader.IsDBNull(nameColumnIndex) ? null : reader.GetString(nameColumnIndex);
                            }

                            var emailColumnIndex = reader.GetOrdinal("Email");
                            if (emailColumnIndex >= 0)
                            {
                                employee.Email = reader.IsDBNull(emailColumnIndex) ? null : reader.GetString(emailColumnIndex);
                            }
                            
                            var functionColumnIndex = reader.GetOrdinal("Function");
                            if (functionColumnIndex >= 0)
                            {
                                employee.Function = reader.IsDBNull(functionColumnIndex) ? null : reader.GetString(functionColumnIndex);
                            }
                            
                            company.Employees.Add(employee);
                        }
                    }
                }
            }
        }

        return company;
    }
}